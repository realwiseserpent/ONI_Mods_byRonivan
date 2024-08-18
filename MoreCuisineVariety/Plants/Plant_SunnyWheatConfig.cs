using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace Dupes_Cuisine.Plants
{
    public class Plant_SunnyWheatConfig : IEntityConfig
    {
        public const string Id = "SunnyWheat";
        public const string Name = "Sunny Wheat";
        public static string Description = "A vibrant wheat that grows in temperate and hot biomes. It produces " + UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain") + ", a warm grain that can be processed in to food.";
        public static string DomesticatedDescription = "/n/n This domesticated wheat require little " + UI.FormatAsLink("Water", "WATER") + ". Also require " + UI.FormatAsLink("Sand", "SAND") + " as fertilizer.";
        public const string SeedId = "SunnyWheatSeed";
        public const string SeedName = "Sunny Wheat Bulb";
        public static string SeedDescription = "The bulb of a " + UI.FormatAsLink("Sunny Wheat", "SunnyWheat") + ".";
        public const float DefaultTemperature = 321.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 313.15f;
        public const float TemperatureWarningHigh = 343.15f;
        public const float TemperatureLethalHigh = 348.15f;
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.SunnyWheatTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject placedEntity = EntityTemplates.CreatePlacedEntity("SunnyWheat", "Sunny Wheat", Plant_SunnyWheatConfig.Description, 1f, Assets.GetAnim((HashedString)"plant_sunnywheat_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 1, 1, TUNING.DECOR.BONUS.TIER1, noise, defaultTemperature: 321.15f);
            SimHashes[] safe_elements = new SimHashes[4]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide,
                SimHashes.ContaminatedOxygen,
                SimHashes.ChlorineGas
            };
            EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 273.15f, 313.15f, 343.15f, 348.15f, safe_elements, crop_id: "SunnyWheat_Grain", baseTraitId: "SunnyWheatOriginal", baseTraitName: "Sunny Wheat");
            PlantElementAbsorber.ConsumeInfo info = new PlantElementAbsorber.ConsumeInfo()
            {
                tag = GameTags.Water,
                massConsumptionRate = 0.015f
            };
            EntityTemplates.ExtendPlantToIrrigated(placedEntity, info);
            PlantElementAbsorber.ConsumeInfo[] fertilizers = new PlantElementAbsorber.ConsumeInfo[1]
            {
                new PlantElementAbsorber.ConsumeInfo()
                {
                    tag = SimHashes.Sand.CreateTag(),
                    massConsumptionRate = 0.04f
                }
            };
            EntityTemplates.ExtendPlantToFertilizable(placedEntity, fertilizers);
            placedEntity.AddOrGet<StandardCropPlant>();
            List<Tag> tagList = new List<Tag>();
            tagList.Add(GameTags.CropSeed);
            Tag tag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(placedEntity, SeedProducer.ProductionType.Harvest, "SunnyWheatSeed", "Sunny Wheat Bulb", Plant_SunnyWheatConfig.SeedDescription, Assets.GetAnim((HashedString)"seed_sunnywheat_kanim"), "object", 1, tagList, SingleEntityReceptacle.ReceptacleDirection.Top, tag, 2, Plant_SunnyWheatConfig.DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, (Recipe.Ingredient[])null, "", false), "SunnyWheat_preview", Assets.GetAnim((HashedString)"plant_sunnywheat_kanim"), "place", 1, 1);
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
