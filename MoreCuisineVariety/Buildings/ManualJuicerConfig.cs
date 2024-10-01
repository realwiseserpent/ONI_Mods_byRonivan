using BUILDINGS = STRINGS.BUILDINGS;
using ITEMS = STRINGS.ITEMS;
using System.Collections.Generic;
using TUNING;
using UnityEngine; 

namespace DupesCuisine.Buildings
{
    public class ManualJuicerConfig : IBuildingConfig
    {
        public const string ID = "ManualJuicer";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
            MicrobeMusher fabricator = go.AddOrGet<MicrobeMusher>();
            fabricator.heatedTemperature = 300.15f;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            go.AddOrGet<ComplexFabricatorWorkable>().overrideAnims = new KAnimFile[1]
            {
                Assets.GetAnim((HashedString) "anim_interacts_musher_kanim")
            };
            fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            Prioritizable.AddRef(go);
            go.AddOrGet<DropAllWorkable>();
            ConfigureRecipes();

            go.AddOrGetDef<PoweredController.Def>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CookTop);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(ID, 2, 3, "food_grinder_kanim", 100, 10f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.RAW_MINERALS, 1600f, (BuildLocationRule)1, TUNING.BUILDINGS.DECOR.NONE, none, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.Floodable = false;
            buildingDef.Entombable = true;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 90f;
            buildingDef.ExhaustKilowattsWhenActive = 0.5f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.ShowInBuildMenu = true;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
        private void ConfigureRecipes()
        {
            if (!DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID) && !DlcManager.IsContentSubscribed(DlcManager.DLC2_ID))
            {
                ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(PrickleFruitConfig.ID, 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10)
                };
                ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 10f)
                };

                ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, inputs, outputs), inputs, outputs, 0)
                {
                    time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                    description = STRINGS.CROPS.RECIPEDESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag> { ManualJuicerConfig.ID },
                    sortOrder = 6
                };
            }
        }
    }
}
