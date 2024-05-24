using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Plants
{
    public class Plant_CreamcapMushroomConfig : IEntityConfig
    {
        public const string Id = "Creamcap";
        public const string SeedId = "CreamcapSeed";
        public const float DefaultTemperature = 298.15f;
        public const float TemperatureLethalLow = 277.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 309.15f;
        public const float TemperatureLethalHigh = 313.15f;
        public const float GROW_TIME = 3600f;
        public const byte CROP_NUM = 1;
        public const float Irrigation = 20/600f;             //   Irrigation Needed
        public const float Fertilization = 15 / 600f;         //   Fertilization Needed
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.CreamcapTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues effectorValues = new EffectorValues();
            GameObject placedEntity = EntityTemplates.CreatePlacedEntity(
                Plant_CreamcapMushroomConfig.Id,
                STRINGS.PLANTS.CREAMCAPMUSHROOM.NAME,
                STRINGS.PLANTS.CREAMCAPMUSHROOM.DESC, 1f, Assets.GetAnim(("plant_creamcap_kanim")), "idle_empty", (Grid.SceneLayer)21, 1, 2, DECOR.BONUS.TIER1, effectorValues, (SimHashes)976099455, null, 298.15f);
            SimHashes[] simHashesArray = new SimHashes[2]
            {
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide
            };
            EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 253.15f, 283.15f, 308.15f, 323.15f, simHashesArray, true, 0.0f, 0.15f, Crop_Creamcap.Id, true, true, true, true, 2400f, 0.0f, 4600f, "CreamcapOriginal", "Creamcap Mushroom");
            //EntityTemplates.ExtendPlantToFertilizable(placedEntity, new PlantElementAbsorber.ConsumeInfo[]
            //    {
            //        new PlantElementAbsorber.ConsumeInfo()
            //        {
            //            tag = SimHashes.ToxicSand.CreateTag(),
            //            massConsumptionRate = Fertilization
            //        }
            //    });

            EntityTemplates.ExtendPlantToIrrigated(placedEntity, new PlantElementAbsorber.ConsumeInfo[]
                {
                    new PlantElementAbsorber.ConsumeInfo()
                    {
                        tag = SimHashes.DirtyWater.CreateTag(),
                        massConsumptionRate = Irrigation
                    }
                });

            EntityTemplateExtensions.AddOrGet<IlluminationVulnerable>(placedEntity).SetPrefersDarkness(true);
            EntityTemplateExtensions.AddOrGet<StandardCropPlant>(placedEntity);
            List<Tag> tagList = new List<Tag>
            {
                GameTags.CropSeed
            };
            Tag tag = new Tag();

            placedEntity.AddOrGet<BlightVulnerable>();

            EntityTemplates.CreateAndRegisterPreviewForPlant(
                EntityTemplates.CreateAndRegisterSeedForPlant(placedEntity, SeedProducer.ProductionType.Harvest, Plant_CreamcapMushroomConfig.SeedId,
                STRINGS.SEEDS.CREAMCAPMUSHROOM.SEED_NAME,
                STRINGS.SEEDS.CREAMCAPMUSHROOM.SEED_DESC, Assets.GetAnim(("seed_creamcap_kanim")), "object", 1, tagList, 0, tag, 2,
                STRINGS.PLANTS.CREAMCAPMUSHROOM.DOMESTICATED_DESC, 0, 0.2f, 0.2f), "Creamcap_preview", Assets.GetAnim(("plant_creamcap_kanim")), "place", 1, 1);
            SoundEventVolumeCache.instance.AddVolume("bristleblossom", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);

            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement("MushroomSeed", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 25f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(SeedId, 1f) };
            string id = ComplexRecipeManager.MakeRecipeID(KilnConfig.ID, inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.CROPS.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>() { KilnConfig.ID },
                sortOrder = 2,
            };

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