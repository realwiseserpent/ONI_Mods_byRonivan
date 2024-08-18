using Dupes_Cuisine.Crops;
using Dupes_Cuisine.Food;
using Dupes_Cuisine.Plants;
using HarmonyLib;
using Klei;
using KMod;
using ProcGen;
using System;
using System.Collections.Generic;
using System.Linq;
using TUNING;

namespace Dupes_Cuisine
{
    public class Dupes_Cuisine_Patches
    {
        public static Dictionary<string, CuisinePlantsTuning.CropsTuning> CropsDictionary;
        public const float CyclesForGrowth = 4f;

        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public static class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                Strings.Add("STRINGS.ITEMS.FOOD." + "Kakawa_Acorn".ToUpperInvariant() + ".NAME", Crop_KakawaAcorn.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Kakawa_Acorn".ToUpperInvariant() + ".DESC", Crop_KakawaAcorn.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "KakawaTreeSeed".ToUpperInvariant() + ".NAME", "Kakawa Tree Sprout");
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "KakawaTreeSeed".ToUpperInvariant() + ".DESC", Plant_KakawaTreeConfig.SeedDescription);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".NAME", "Kakawa Tree");
                Strings.Add("STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".DESC", Plant_KakawaTreeConfig.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_KakawaTreeConfig.DomesticatedDescription);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("Kakawa_Acorn", 12600f, 24));
                Strings.Add("STRINGS.ITEMS.FOOD." + "Creamtop_Cap".ToUpperInvariant() + ".NAME", Crop_Creamcap.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Creamtop_Cap".ToUpperInvariant() + ".DESC", Crop_Creamcap.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "CreamcapSeed".ToUpperInvariant() + ".NAME", "Creamcap Mushroom Spore");
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "CreamcapSeed".ToUpperInvariant() + ".DESC", Plant_CreamtopConfig.SeedDescription);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".NAME", "Creamcap Mushroom");
                Strings.Add("STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".DESC", Plant_CreamtopConfig.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_CreamtopConfig.DomesticatedDescription);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("Creamtop_Cap", 3440f));
                Strings.Add("STRINGS.ITEMS.FOOD." + "SunnyWheat_Grain".ToUpperInvariant() + ".NAME", Crop_SunnyWheatGrain.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SunnyWheat_Grain".ToUpperInvariant() + ".DESC", Crop_SunnyWheatGrain.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "SunnyWheatSeed".ToUpperInvariant() + ".NAME", "Sunny Wheat Bulb");
                Strings.Add("STRINGS.CREATURES.SPECIES.SEEDS." + "SunnyWheatSeed".ToUpperInvariant() + ".DESC", Plant_SunnyWheatConfig.SeedDescription);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".NAME", "Sunny Wheat");
                Strings.Add("STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".DESC", Plant_SunnyWheatConfig.Description);
                Strings.Add("STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_SunnyWheatConfig.DomesticatedDescription);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("SunnyWheat_Grain", 10800f, 18));
                Strings.Add("STRINGS.ITEMS.FOOD." + "Roasted_Kakawa".ToUpperInvariant() + ".NAME", Food_RoastedKakawa.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Roasted_Kakawa".ToUpperInvariant() + ".DESC", Food_RoastedKakawa.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "FlatBread".ToUpperInvariant() + ".NAME", Food_FlatBread.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "FlatBread".ToUpperInvariant() + ".DESC", Food_FlatBread.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Grilled_Creamtop".ToUpperInvariant() + ".NAME", Food_GrilledCreamtop.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Grilled_Creamtop".ToUpperInvariant() + ".DESC", Food_GrilledCreamtop.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaButter".ToUpperInvariant() + ".NAME", Food_KakawaButter.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaButter".ToUpperInvariant() + ".DESC", Food_KakawaButter.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaBar".ToUpperInvariant() + ".NAME", Food_KakawaBar.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaBar".ToUpperInvariant() + ".DESC", Food_KakawaBar.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "LiceWrap".ToUpperInvariant() + ".NAME", Food_LiceWrap.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "LiceWrap".ToUpperInvariant() + ".DESC", Food_LiceWrap.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "FishWrap".ToUpperInvariant() + ".NAME", Food_FishWrap.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "FishWrap".ToUpperInvariant() + ".DESC", Food_FishWrap.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MeatWrap".ToUpperInvariant() + ".NAME", Food_MeatWrap.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MeatWrap".ToUpperInvariant() + ".DESC", Food_MeatWrap.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaCookie".ToUpperInvariant() + ".NAME", Food_Cookie.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "KakawaCookie".ToUpperInvariant() + ".DESC", Food_Cookie.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Nut_cake".ToUpperInvariant() + ".NAME", Food_Nutcake.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Nut_cake".ToUpperInvariant() + ".DESC", Food_Nutcake.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SeaTaco".ToUpperInvariant() + ".NAME", Food_SeaTaco.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SeaTaco".ToUpperInvariant() + ".DESC", Food_SeaTaco.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MeatTaco".ToUpperInvariant() + ".NAME", Food_MeatTaco.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MeatTaco".ToUpperInvariant() + ".DESC", Food_MeatTaco.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MushroomStew".ToUpperInvariant() + ".NAME", Food_MushroomStew.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MushroomStew".ToUpperInvariant() + ".DESC", Food_MushroomStew.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "NoshMilk".ToUpperInvariant() + ".NAME", Food_NoshMilkConfig.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "NoshMilk".ToUpperInvariant() + ".DESC", Food_NoshMilkConfig.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MealSlurry".ToUpperInvariant() + ".NAME", Food_MealSlurryConfig.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MealSlurry".ToUpperInvariant() + ".DESC", Food_MealSlurryConfig.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "BreadedPacu".ToUpperInvariant() + ".NAME", Food_BreadedPacu.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "BreadedPacu".ToUpperInvariant() + ".DESC", Food_BreadedPacu.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "CookedMuckroot".ToUpperInvariant() + ".NAME", Food_CookedMuckroot.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "CookedMuckroot".ToUpperInvariant() + ".DESC", Food_CookedMuckroot.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "CookedShard".ToUpperInvariant() + ".NAME", Food_CookedShard.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "CookedShard".ToUpperInvariant() + ".DESC", Food_CookedShard.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "GrilledPlantMeat".ToUpperInvariant() + ".NAME", Food_GrilledPlantMeat.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "GrilledPlantMeat".ToUpperInvariant() + ".DESC", Food_GrilledPlantMeat.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MealBread".ToUpperInvariant() + ".NAME", Food_MealBread.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MealBread".ToUpperInvariant() + ".DESC", Food_MealBread.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MilkBun".ToUpperInvariant() + ".NAME", Food_MilkBun.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "MilkBun".ToUpperInvariant() + ".DESC", Food_MilkBun.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "NoshPudding".ToUpperInvariant() + ".NAME", Food_NoshPudding.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "NoshPudding".ToUpperInvariant() + ".DESC", Food_NoshPudding.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Nutpie".ToUpperInvariant() + ".NAME", Food_Nutpie.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "Nutpie".ToUpperInvariant() + ".DESC", Food_Nutpie.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "JellyDoughnut".ToUpperInvariant() + ".NAME", Food_JellyDoughnut.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "JellyDoughnut".ToUpperInvariant() + ".DESC", Food_JellyDoughnut.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "PlantBurger".ToUpperInvariant() + ".NAME", Food_PlantBurger.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "PlantBurger".ToUpperInvariant() + ".DESC", Food_PlantBurger.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SaltedMeat".ToUpperInvariant() + ".NAME", Food_SaltedMeat.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SaltedMeat".ToUpperInvariant() + ".DESC", Food_SaltedMeat.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SpicedOmelette".ToUpperInvariant() + ".NAME", Food_SpicedOmelette.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "SpicedOmelette".ToUpperInvariant() + ".DESC", Food_SpicedOmelette.Description);
                Strings.Add("STRINGS.ITEMS.FOOD." + "DuskOmelette".ToUpperInvariant() + ".NAME", Food_DuskOmelette.Name);
                Strings.Add("STRINGS.ITEMS.FOOD." + "DuskOmelette".ToUpperInvariant() + ".DESC", Food_DuskOmelette.Description);
            }
        }

        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref Immigration __instance)
            {
                Traverse traverse = Traverse.Create((object)__instance).Field("carePackages");
                List<CarePackageInfo> list = traverse.GetValue<List<CarePackageInfo>>();
                list.Add(new CarePackageInfo("KakawaTreeSeed", 3f, (Func<bool>)null));
                list.Add(new CarePackageInfo("CreamcapSeed", 3f, (Func<bool>)null));
                list.Add(new CarePackageInfo("SunnyWheatSeed", 3f, (Func<bool>)null));
                list.Add(new CarePackageInfo("KakawaBar", 5f, (Func<bool>)null));
                list.Add(new CarePackageInfo("FishWrap", 8f, (Func<bool>)null));
                list.Add(new CarePackageInfo("MeatWrap", 8f, (Func<bool>)null));
                list.Add(new CarePackageInfo("KakawaCookie", 8f, (Func<bool>)null));
                list.Add(new CarePackageInfo("Nut_cake", 6f, (Func<bool>)null));
                traverse.SetValue(list);
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadFiles", new System.Type[] { typeof(string), typeof(string), typeof(List<YamlIO.Error>) })]
        public static class SettingsCache_LoadFiles_Patch
        {
            public static void Postfix()
            {
                ComposableDictionary<string, Mob> mobLookupTable = SettingsCache.mobs.MobLookupTable;
                foreach (string key in Dupes_Cuisine_Patches.CropsDictionary.Keys)
                {
                    if (!mobLookupTable.ContainsKey(key))
                    {
                        CuisinePlantsTuning.CropsTuning crops = Dupes_Cuisine_Patches.CropsDictionary[key];
                        Mob mob = new Mob(crops.spawnLocation) { name = key };
                        Traverse traverse = Traverse.Create((object)mob);
                        traverse.Property("width").SetValue((object)1);
                        traverse.Property("height").SetValue((object)1);
                        traverse.Property("density").SetValue((object)crops.density);
                        mobLookupTable.Add(key, mob);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadSubworlds")]
        public static class SettingsCache_LoadSubworlds_Patch
        {
            public static void Postfix()
            {
                foreach (SubWorld subworld in SettingsCache.subworlds.Values)
                {
                    foreach (WeightedBiome biome in subworld.biomes)
                    {
                        foreach (string key in Dupes_Cuisine_Patches.CropsDictionary.Keys)
                        {
                            if (Dupes_Cuisine_Patches.CropsDictionary[key].ValidBiome(subworld, biome.name))
                            {
                                if (biome.tags == null)
                                    Traverse.Create((object)biome).Property("tags").SetValue((object)new List<string>());
                                biome.tags.Add(key);
                            }
                        }
                    }
                }
            }
        }
    }
}
