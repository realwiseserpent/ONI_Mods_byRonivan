using UnityEngine;
using System.Collections.Generic;
using TUNING;
using DupesCuisine.Crops;

namespace DupesCuisine.Plants
{
    public class Plant_SunnyWheatConfig : IEntityConfig
    {
        public const string Id = "SunnyWheat";
        public const string SeedId = "SunnyWheatSeed";
        public const float DefaultTemperature = 321.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 313.15f;
        public const float TemperatureWarningHigh = 343.15f;
        public const float TemperatureLethalHigh = 348.15f;
        public const float GROW_TIME = 10800f;
        public const byte CROP_NUM = 18;
        public const float Irrigation = 12 / 600f;             //   Irrigation Needed
        public const float Fertilization = 15 / 600f;         //   Fertilization Needed
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.SunnyWheatTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject template = EntityTemplates.CreatePlacedEntity(
                Plant_SunnyWheatConfig.Id,
                STRINGS.PLANTS.SUNNYWHEAT.NAME,
                STRINGS.PLANTS.SUNNYWHEAT.DESC, 1f, Assets.GetAnim("plant_sunnywheat_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 1, 1, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, null, 321.15f);
            SimHashes[] hashesArray1 = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
                SimHashes.ChlorineGas
            };
            EntityTemplates.ExtendEntityToBasicPlant(template, 273.15f, 313.15f, 343.15f, 373.15f, hashesArray1, true, 0f, 0.15f, Crop_SunnyWheatGrain.Id, true, true, true, true, 2400f, 0f, 9800f, "SunnyWheatOriginal", STRINGS.PLANTS.SUNNYWHEAT.NAME);

            EntityTemplates.ExtendPlantToIrrigated(template, new PlantElementAbsorber.ConsumeInfo[]
            {
                new PlantElementAbsorber.ConsumeInfo
                {
                    tag = GameTags.DirtyWater,
                    massConsumptionRate = Irrigation
                }
            });

            EntityTemplates.ExtendPlantToFertilizable(template, new PlantElementAbsorber.ConsumeInfo[]
            {
                new PlantElementAbsorber.ConsumeInfo
                {
                    tag = SimHashes.Sand.CreateTag(),
                    massConsumptionRate = Fertilization
                }
            });

            template.AddOrGet<BlightVulnerable>();
            template.AddOrGet<StandardCropPlant>();

            List<Tag> additionalTags = new List<Tag>
            {
                GameTags.CropSeed
            };
            Tag replantGroundTag = new Tag();


            GameObject seed = EntityTemplates.CreateAndRegisterSeedForPlant(template, SeedProducer.ProductionType.Crop,
                Crop_SunnyWheatGrain.Id,
                STRINGS.SEEDS.SUNNYWHEAT.SEED_NAME,
                STRINGS.SEEDS.SUNNYWHEAT.SEED_DESC, Assets.GetAnim("crop_sunnygrain_kanim"),
            "object", 1, additionalTags, SingleEntityReceptacle.ReceptacleDirection.Top, replantGroundTag, 2,
            STRINGS.PLANTS.SUNNYWHEAT.DOMESTICATED_DESC, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, ignoreDefaultSeedTag: true);

            EntityTemplates.ExtendEntityToFood(seed, Crop_SunnyWheatGrain.foodInfo);

            EntityTemplates.CreateAndRegisterPreviewForPlant(seed, "SunnyWheat_preview", Assets.GetAnim("plant_sunnywheat_kanim"), "place", 1, 1);


            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement("ColdWheatSeed", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 25f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(Crop_SunnyWheatGrain.Id, 1f) };
            string id = ComplexRecipeManager.MakeRecipeID(KilnConfig.ID, inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.CROPS.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>() { KilnConfig.ID },
                sortOrder = 2
            };

            SoundEventVolumeCache.instance.AddVolume("bristleblossom", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);
            return template;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
