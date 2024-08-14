using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace Dupes_Cuisine.Plants
{
    public class Plant_CreamtopConfig : IEntityConfig
    {
        public const string Id = "Creamcap";
        public const string Name = "Creamcap Mushroom";
        public static string Description = "A soft white mushroom with a creamie texture on its cap. Despite growing in filthy dark spots, it is edible.";
        public static string DomesticatedDescription = Plant_CreamtopConfig.Description + "This domesticated Creamcap requires " + UI.FormatAsLink("Polluted Dirty", "TOXICSAND") + " as fertilizer.";
        public const string SeedId = "CreamcapSeed";
        public const string SeedName = "Creamcap Mushroom Spore";
        public static string SeedDescription = "A small spore from the " + UI.FormatAsLink("Creamcap Mushroom", "Creamcap") + ". Plant it in a dark place and its surely to flourish.";
        public const float DefaultTemperature = 298.15f;
        public const float TemperatureLethalLow = 277.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 309.15f;
        public const float TemperatureLethalHigh = 313.15f;
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.CreamcapTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject placedEntity = EntityTemplates.CreatePlacedEntity("Creamcap", "Creamcap Mushroom", Plant_CreamtopConfig.Description, 1f, Assets.GetAnim((HashedString)"plant_creamcap_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 1, 2, TUNING.DECOR.BONUS.TIER1, noise, defaultTemperature: 298.15f);
            SimHashes[] safe_elements = new SimHashes[2]
            {
                SimHashes.Oxygen,
                SimHashes.CarbonDioxide
            };
            EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 277.15f, temperature_warning_high: 309.15f, temperature_lethal_high: 313.15f, safe_elements: safe_elements, crop_id: "Creamtop_Cap", max_radiation: 220f, baseTraitId: "CreamcapOriginal", baseTraitName: "Creamcap Mushroom");
            PlantElementAbsorber.ConsumeInfo info = new PlantElementAbsorber.ConsumeInfo()
            {
                tag = SimHashes.DirtyWater.CreateTag(),
                massConsumptionRate = 0.03333334f
            };
            EntityTemplates.ExtendPlantToIrrigated(placedEntity, info);
            placedEntity.AddOrGet<IlluminationVulnerable>().SetPrefersDarkness(true);
            placedEntity.AddOrGet<StandardCropPlant>();
            List<Tag> tagList = new List<Tag>();
            tagList.Add(GameTags.CropSeed);
            Tag tag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(placedEntity, SeedProducer.ProductionType.Harvest, "CreamcapSeed", "Creamcap Mushroom Spore", Plant_CreamtopConfig.SeedDescription, Assets.GetAnim((HashedString)"seed_creamcap_kanim"), "object", 1, tagList, SingleEntityReceptacle.ReceptacleDirection.Top, tag, 2, Plant_CreamtopConfig.DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, (Recipe.Ingredient[])null, "", false), "Creamcap_preview", Assets.GetAnim((HashedString)"plant_creamcap_kanim"), "place", 1, 1);
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
