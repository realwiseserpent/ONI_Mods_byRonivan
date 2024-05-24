using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Plants
{
    public class Plant_KakawaTreeConfig : IEntityConfig
    {
        public const string Id = "KakawaTree";
        public const string SeedId = "KakawaTreeSeed";
        public const float DefaultTemperature = 305.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 313.15f;
        public const float TemperatureLethalHigh = 321.15f;
        public const float GROW_TIME = 14400f;
        public const byte CROP_NUM = 24;
        public const float Irrigation = 12 / 600f;             //   Irrigation Needed
        public const float Fertilization = 18 / 600f;         //   Fertilization Needed
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.OakTreeTuning;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject gameObject = EntityTemplates.CreatePlacedEntity(
                Plant_KakawaTreeConfig.Id,
                STRINGS.PLANTS.KAKAWATREE.NAME,
                STRINGS.PLANTS.KAKAWATREE.DESC, 1f, Assets.GetAnim("plant_kakawatree_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 3, 3, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, null, 305.15f);
            SimHashes[] hashesArray1 = new SimHashes[]
            {
                SimHashes.Oxygen,
                SimHashes.ContaminatedOxygen,
                SimHashes.CarbonDioxide,
            };
            EntityTemplates.ExtendEntityToBasicPlant(gameObject, 253.15f, 283.15f, 313.15f, 373.15f, hashesArray1, true, 0f, 0.15f, Crop_KakawaAcorn.Id, true, true, true, false, 2400f, 0f, TUNING.PLANTS.RADIATION_THRESHOLDS.TIER_5, "KakawaTreeOriginal", STRINGS.PLANTS.KAKAWATREE.NAME);

            EntityTemplates.ExtendPlantToIrrigated(gameObject, new PlantElementAbsorber.ConsumeInfo[]
                {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = GameTags.Water,
                        massConsumptionRate = Irrigation
                    }
                });

            EntityTemplates.ExtendPlantToFertilizable(gameObject, new PlantElementAbsorber.ConsumeInfo[]
                {
                    new PlantElementAbsorber.ConsumeInfo
                    {
                        tag = GameTags.Phosphorite,
                        massConsumptionRate = Fertilization
                    }
                });

            //PlantBranchGrower.Def def = gameObject.AddOrGetDef<PlantBranchGrower.Def>();
            //def.preventStartSMIOnSpawn = true;
            //def.BRANCH_PREFAB_NAME = "KakawaTreeBranch";
            //def.harvestOnDrown = true;
            //def.MAX_BRANCH_COUNT = 2;
            //def.BRANCH_OFFSETS = new CellOffset[]
            //{
            //    //new CellOffset(-1, 0),
            //    //new CellOffset(-1, 1),
            //    new CellOffset(-1, 2),
            //    //new CellOffset(0, 2),
            //    new CellOffset(1, 2),
            //    //new CellOffset(1, 1),
            //    //new CellOffset(1, 0)
            //};
            //gameObject.AddOrGet<BuddingTrunk>();
            ////gameObject.AddOrGet<DirectlyEdiblePlant_TreeBranches>();
            //gameObject.UpdateComponentRequirement<Harvestable>(false);
            //gameObject.AddComponent<StandardCropPlant>().wiltsOnReadyToHarvest = true;

            gameObject.AddOrGet<StandardCropPlant>();
            List<Tag> additionalTags = new List<Tag>
            {
                GameTags.CropSeed
            };
            Tag replantGroundTag = new Tag();

            gameObject.AddOrGet<BlightVulnerable>();

            GameObject seed = EntityTemplates.CreateAndRegisterSeedForPlant(gameObject, SeedProducer.ProductionType.Crop,
                Crop_KakawaAcorn.Id,
                STRINGS.SEEDS.KAKAWATREE.SEED_NAME,
                STRINGS.SEEDS.KAKAWATREE.SEED_DESC, Assets.GetAnim("crop_kakawaacorn_kanim"), "object", 1, additionalTags, SingleEntityReceptacle.ReceptacleDirection.Top, replantGroundTag, 2,
                STRINGS.PLANTS.KAKAWATREE.DOMESTICATED_DESC, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, ignoreDefaultSeedTag: true);

            EntityTemplates.CreateAndRegisterPreviewForPlant(seed, "KakawaTree_preview", Assets.GetAnim("plant_kakawatree_kanim"), "place", 3, 3);
            EntityTemplates.ExtendEntityToFood(seed, Crop_KakawaAcorn.foodInfo);


            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement("ForestTreeSeed", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 25f)
            };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(Crop_KakawaAcorn.Id, 1f) };
            string id = ComplexRecipeManager.MakeRecipeID(KilnConfig.ID, inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.CROPS.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>() { KilnConfig.ID },
                sortOrder = 2,
            };

            SoundEventVolumeCache.instance.AddVolume("bristleblossom", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);
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