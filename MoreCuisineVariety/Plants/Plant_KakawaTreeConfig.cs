using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace Dupes_Cuisine.Plants
{
    public class Plant_KakawaTreeConfig : IEntityConfig
    {
        public const string Id = "KakawaTree";
        public const string Name = "Kakawa Tree";
        public static string Description = "A lush, golden leafed tree that grows in temperate forest biomes. It produces a rock hard edible " + UI.FormatAsLink("Kakawa Acorn", "Kakawa_Acorn") + ".";
        public static string DomesticatedDescription = "/n/n This domesticated tree requires copious amounts of " + UI.FormatAsLink("Water", "WATER") + ", and " + UI.FormatAsLink("Dirt", "DIRT") + " as fertilizer.";
        public const string SeedId = "KakawaTreeSeed";
        public const string SeedName = "Kakawa Tree Sprout";
        public static string SeedDescription = "The Sprout of a " + UI.FormatAsLink("Kakawa Tree", "KakawaTree") + ".";
        public const float DefaultTemperature = 305.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 313.15f;
        public const float TemperatureLethalHigh = 321.15f;
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.OakTreeTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject placedEntity = EntityTemplates.CreatePlacedEntity("KakawaTree", "Kakawa Tree", Plant_KakawaTreeConfig.Description, 1f, Assets.GetAnim((HashedString)"plant_kakawatree_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 3, 3, TUNING.DECOR.BONUS.TIER1, noise, defaultTemperature: 305.15f);
            SimHashes[] safe_elements = new SimHashes[3]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.ContaminatedOxygen
            };
            EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 273.15f, temperature_warning_high: 313.15f, temperature_lethal_high: 321.15f, safe_elements: safe_elements, crop_id: "Kakawa_Acorn", baseTraitId: "KakawaTreeOriginal", baseTraitName: "Kakawa Tree");
            PlantElementAbsorber.ConsumeInfo info = new PlantElementAbsorber.ConsumeInfo()
            {
                tag = GameTags.Water,
                massConsumptionRate = 0.04f
            };
            EntityTemplates.ExtendPlantToIrrigated(placedEntity, info);
            PlantElementAbsorber.ConsumeInfo[] fertilizers = new PlantElementAbsorber.ConsumeInfo[1]
            {
                new PlantElementAbsorber.ConsumeInfo()
                {
                    tag = SimHashes.Dirt.CreateTag(),
                    massConsumptionRate = 0.02f
                }
            };
            EntityTemplates.ExtendPlantToFertilizable(placedEntity, fertilizers);
            placedEntity.AddOrGet<StandardCropPlant>();
            List<Tag> tagList = new List<Tag>();
            tagList.Add(GameTags.CropSeed);
            Tag tag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(placedEntity, SeedProducer.ProductionType.Harvest, "KakawaTreeSeed", "Kakawa Tree Sprout", Plant_KakawaTreeConfig.SeedDescription, Assets.GetAnim((HashedString)"seed_kakawatree_kanim"), "object", 1, tagList, SingleEntityReceptacle.ReceptacleDirection.Top, tag, 2, Plant_KakawaTreeConfig.DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, (Recipe.Ingredient[])null, "", false), "KakawaTree_preview", Assets.GetAnim((HashedString)"plant_kakawatree_kanim"), "place", 3, 3);
            SoundEventVolumeCache.instance.AddVolume("bristleblossom_kanim", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);
            return placedEntity;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
