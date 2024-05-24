using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Plants
{
    class Plant_KakawaTreeBranchConfig //: IEntityConfig
    {
        public const string Id = "KakawaTreeBranch";
        public const string Name = "Kakawa Tree Branch";
        public static string Description = "A lush, golden leafed tree that grows in temperate forest biomes. It produces a rock hard edible " + UI.FormatAsLink("Kakawa Acorn", Crop_KakawaAcorn.Id) + ".";
        public static string DomesticatedDescription = "/n/n This domesticated tree requires copious amounts of " + UI.FormatAsLink("Water", "WATER") + ", and " + UI.FormatAsLink("Dirt", "DIRT") + " as fertilizer.";
        public const string SeedId = Crop_KakawaAcorn.Id;
        public const string SeedName = "Kakawa Tree Sprout";
        public static string SeedDescription = "The Sprout of a " + UI.FormatAsLink("Kakawa Tree", Plant_KakawaTreeConfig.Id) + ".";
        public const float DefaultTemperature = 305.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 313.15f;
        public const float TemperatureLethalHigh = 321.15f;
        public const int KAKAWA_AMOUT = 24;
        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject gameObject = EntityTemplates.CreatePlacedEntity(Id, Name, Description, 1f, Assets.GetAnim("crop_kakawaacorn_kanim"), "idle_empty", 
                Grid.SceneLayer.BuildingFront, 1, 1, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, new List<Tag>()
                {
                    GameTags.HideFromSpawnTool,
                    GameTags.PlantBranch 
                },
                305.15f);
            SimHashes[] hashesArray1 = new SimHashes[] { SimHashes.Oxygen, SimHashes.CarbonDioxide, SimHashes.ContaminatedOxygen };
            EntityTemplates.ExtendEntityToBasicPlant(gameObject, 253.15f, 283.15f, 313.15f, 373.15f, null, true, 0f, 0.15f, Crop_KakawaAcorn.Id, true, true, false, true, 2400f, 0f, TUNING.PLANTS.RADIATION_THRESHOLDS.TIER_5, "KakawaTreeBranchOriginal", STRINGS.PLANTS.KAKAWATREE.NAME);

            gameObject.AddOrGet<StandardCropPlant>();
            List<Tag> additionalTags = new List<Tag>();
            additionalTags.Add(GameTags.CropSeed);
            Tag replantGroundTag = new Tag();

            gameObject.AddOrGet<TreeBud>();
            gameObject.AddOrGet<StandardCropPlant>();
            gameObject.AddOrGet<BudUprootedMonitor>();

            PlantBranch.Def def = gameObject.AddOrGetDef<PlantBranch.Def>();
            def.preventStartSMIOnSpawn = true;

            return gameObject;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
