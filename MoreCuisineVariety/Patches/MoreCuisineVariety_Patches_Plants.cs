using HarmonyLib;
using Klei;
using ProcGen;
using System;
using System.Collections.Generic;
using DupesCuisine.Crops;
using DupesCuisine.Foods;
using DupesCuisine.Plants;
using TUNING;
using UnityEngine;
using static ResearchTypes;

namespace DupesCuisine.Patches
{
    public class DupesCuisine_Patches_Plants
    {
        public static Dictionary<string, CuisinePlantsTuning.CropsTuning> CropsDictionary;
        public static Dictionary<string, CuisinePlantsTuning.SeedTuning> SeedDictionary;

        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public static class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                RegisterStrings.MakeFoodStrings(Crop_KakawaAcorn.Id, STRINGS.CROPS.KAKAWAACORN.NAME, STRINGS.CROPS.KAKAWAACORN.DESC, STRINGS.CROPS.RECIPEDESC);
                RegisterStrings.MakeSeedStrings(Crop_KakawaAcorn.Id, STRINGS.SEEDS.KAKAWATREE.SEED_NAME, STRINGS.SEEDS.KAKAWATREE.SEED_DESC);
                RegisterStrings.MakePlantSpeciesStrings(Plant_KakawaTreeConfig.Id, STRINGS.PLANTS.KAKAWATREE.NAME, STRINGS.PLANTS.KAKAWATREE.DESC);
                //RegisterStrings.MakePlantCodexStrings(Plant_KakawaTreeConfig.Id, STRINGS.PLANTS.KAKAWATREE.NAME, STRINGS.CODEX.SUBTITLE, STRINGS.CODEX.KAKAWATREE.BODY.CONTAINER1);
                CROPS.CROP_TYPES.Add(new Crop.CropVal(Crop_KakawaAcorn.Id, Plant_KakawaTreeConfig.GROW_TIME, Plant_KakawaTreeConfig.CROP_NUM, true));

                RegisterStrings.MakeFoodStrings(Crop_Creamcap.Id, STRINGS.CROPS.CREAMCAP.NAME, STRINGS.CROPS.CREAMCAP.DESC);
                RegisterStrings.MakeSeedStrings(Plant_CreamcapMushroomConfig.SeedId, STRINGS.SEEDS.CREAMCAPMUSHROOM.SEED_NAME, STRINGS.SEEDS.CREAMCAPMUSHROOM.SEED_DESC);
                RegisterStrings.MakePlantSpeciesStrings(Plant_CreamcapMushroomConfig.Id, STRINGS.PLANTS.CREAMCAPMUSHROOM.NAME, STRINGS.PLANTS.CREAMCAPMUSHROOM.DESC);
                //RegisterStrings.MakePlantCodexStrings(Plant_CreamcapMushroomConfig.Id, STRINGS.PLANTS.CREAMCAPMUSHROOM.NAME, STRINGS.CODEX.SUBTITLE, STRINGS.CODEX.CREAMCAPMUSHROOM.BODY.CONTAINER1);
                CROPS.CROP_TYPES.Add(new Crop.CropVal(Crop_Creamcap.Id, Plant_CreamcapMushroomConfig.GROW_TIME, Plant_CreamcapMushroomConfig.CROP_NUM, true));

                RegisterStrings.MakeFoodStrings(Crop_SunnyWheatGrain.Id, STRINGS.CROPS.SUNNYWHEATGRAIN.NAME, STRINGS.CROPS.SUNNYWHEATGRAIN.DESC, STRINGS.CROPS.RECIPEDESC);
                RegisterStrings.MakeSeedStrings(Crop_SunnyWheatGrain.Id, STRINGS.SEEDS.SUNNYWHEAT.SEED_NAME, STRINGS.SEEDS.SUNNYWHEAT.SEED_DESC);
                RegisterStrings.MakePlantSpeciesStrings(Plant_SunnyWheatConfig.Id, STRINGS.PLANTS.SUNNYWHEAT.NAME, STRINGS.PLANTS.SUNNYWHEAT.DESC);
                //RegisterStrings.MakePlantCodexStrings(Plant_SunnyWheatConfig.Id, STRINGS.PLANTS.SUNNYWHEAT.NAME, STRINGS.CODEX.SUBTITLE, STRINGS.CODEX.SUNNYWHEAT.BODY.CONTAINER1);
                CROPS.CROP_TYPES.Add(new Crop.CropVal(Crop_SunnyWheatGrain.Id, Plant_SunnyWheatConfig.GROW_TIME, Plant_SunnyWheatConfig.CROP_NUM, true));
            }
        }

        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref Immigration __instance)
            {
                var sucrose = ElementLoader.FindElementByHash(SimHashes.Sucrose).tag.ToString();

                Traverse traverse = Traverse.Create(__instance).Field("carePackages");
                List<CarePackageInfo> list = traverse.GetValue() as List<CarePackageInfo>;
                list.Add(new CarePackageInfo(Crop_KakawaAcorn.Id, 3f, null));
                list.Add(new CarePackageInfo(Plant_CreamcapMushroomConfig.SeedId, 3f, null));
                list.Add(new CarePackageInfo(Crop_SunnyWheatGrain.Id, 3f, null));
                list.Add(new CarePackageInfo(Food_KakawaBar.Id, 3f, null));
                list.Add(new CarePackageInfo(Food_FishWrap.Id, 3f, null));
                list.Add(new CarePackageInfo(Food_MeatWrap.Id, 3f, null));
                list.Add(new CarePackageInfo(Food_Cookie.Id, 3f, null));
                list.Add(new CarePackageInfo(Food_Nutcake.Id, 2f, null));

                if (list.FindIndex(x => x.id.ToUpper() == sucrose.ToUpper()) == -1)
                    list.Add(new CarePackageInfo(sucrose, 200f, null)); // add sucrose

                traverse.SetValue(list);
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadFiles", new Type[] { typeof(string), typeof(string), typeof(List<YamlIO.Error>) })]
        public static class SettingsCache_LoadFiles_Patch
        {
            public static void Postfix()
            {
                ComposableDictionary<string, Mob> mobLookupTable = SettingsCache.mobs.MobLookupTable;
                foreach (string key in CropsDictionary.Keys)
                {
                    if (!mobLookupTable.ContainsKey(key))
                    {
                        CuisinePlantsTuning.CropsTuning crops = CropsDictionary[key];
                        Mob mob1 = new Mob(crops.spawnLocation) { name = key };
                        Traverse traverse = Traverse.Create(mob1);
                        traverse.Property("width", (object[])null).SetValue(1);
                        traverse.Property("height", (object[])null).SetValue(1);
                        traverse.Property("density", (object[])null).SetValue(crops.density);
                        traverse.Property("selectMethod", null).SetValue(1);
                        mobLookupTable.Add(key, mob1);
                    }
                }
                foreach (string seedName in SeedDictionary.Keys)
                {
                    if (mobLookupTable.ContainsKey(seedName))
                        continue;
                    var tuning = SeedDictionary[seedName];
                    Mob plant = new Mob(Mob.Location.Solid) { name = seedName };
                    var p = Traverse.Create(plant);
                    p.Property("width").SetValue(1);
                    p.Property("height").SetValue(1);
                    p.Property("density").SetValue(tuning.density);
                    p.Property("selectMethod", null).SetValue(1);
                    mobLookupTable.Add(seedName, plant);
                }
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadSubworlds")]
        public static class SettingsCache_LoadSubworlds_Patch
        {
            public static void Postfix()
            {
                foreach (SubWorld subworld in SettingsCache.subworlds.Values)
                    foreach (WeightedBiome biome in subworld.biomes)
                    {
                        if (biome.tags == null)
                            Traverse.Create(biome).Property("tags", (object[])null).SetValue(new List<string>());

                        foreach (string key in DupesCuisine_Patches_Plants.CropsDictionary.Keys)
                            if (DupesCuisine_Patches_Plants.CropsDictionary[key].ValidBiome(subworld, biome.name))
                                if (!biome.tags.Contains(key))
                                    biome.tags.Add(key);

                        foreach (string seedName in SeedDictionary.Keys)
                            if (SeedDictionary[seedName].ValidBiome( biome.name))
                                if (!biome.tags.Contains(seedName))
                                    biome.tags.Add(seedName);
                    }
            }
        }

        [HarmonyPatch(typeof(CodexEntry))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] {
            typeof(string),
            typeof(List<ContentContainer>),
            typeof(string)
        })]
        public static class CodexEntry_Constructor_Patch
        {
            private static void Postfix(CodexEntry __instance)
            {
                if (__instance.category != "PLANTS")
                    return;

                GameObject kakawa = Assets.GetPrefab(Plant_KakawaTreeConfig.Id);
                GameObject mushroom = Assets.GetPrefab(Plant_CreamcapMushroomConfig.Id);
                GameObject sunny = Assets.GetPrefab(Plant_SunnyWheatConfig.Id);

                if (kakawa.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(Plant_KakawaTreeConfig.Id));
                else if (mushroom.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(Plant_CreamcapMushroomConfig.Id));
                else if (sunny.GetProperName() == __instance.name)
                    __instance.contentContainers.InsertRange(0, GetCodexContainers(Plant_SunnyWheatConfig.Id));
            }
        }

        //[HarmonyPatch(typeof(CodexEntryGenerator), "GeneratePlantEntries")]
        public class DupesCuisine_CodexEntryGenerator_GeneratePlantEntries_Patch
        {
            public static void Postfix(Dictionary<string, CodexEntry> __result)
            {
                foreach (var key in CropsDictionary.Keys)
                {
                    CodexEntry entry = CodexCache.FindEntry(key.ToUpperInvariant());

                    if (entry != null)
                        entry.contentContainers.InsertRange(0, GetCodexContainers(key));
                }
            }
        }

        private static List<ContentContainer> GetCodexContainers(string id)
        {
            return new List<ContentContainer>()
                {
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                        new CodexText() { stringKey = $"STRINGS.CREATURES.SPECIES.{id.ToUpperInvariant()}.NAME",
                        //new CodexText() {stringKey = $"STRINGS.CODEX.{id.ToUpperInvariant()}.TITLE",
                            style = CodexTextStyle.Title },
                        new CodexText() { stringKey = $"STRINGS.CODEX.MEALWOOD.SUBTITLE",
                            style = CodexTextStyle.Subtitle },
                        new CodexDividerLine() { preferredWidth = -1 }
                        }
                    },
                    new ContentContainer()
                    {
                        contentLayout = ContentContainer.ContentLayout.Vertical,
                        content = new List<ICodexWidget>()
                        {
                            new CodexText() { stringKey = $"STRINGS.CREATURES.SPECIES.{id.ToUpperInvariant()}.DESC",
                            //new CodexText() {stringKey = $"STRINGS.CODEX.{id.ToUpperInvariant()}.BODY.CONTAINER1",
                            style = CodexTextStyle.Body }
                        }
                    }
                };
        }
    }
}

