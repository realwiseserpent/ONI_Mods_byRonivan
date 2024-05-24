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
            EntityTemplateExtensions.AddOrGet<BuildingComplete>(go).isManuallyOperated = true;
            MicrobeMusher microbeMusher = EntityTemplateExtensions.AddOrGet<MicrobeMusher>(go);
            ((ComplexFabricator)microbeMusher).heatedTemperature = 300.15f;
            EntityTemplateExtensions.AddOrGet<FabricatorIngredientStatusManager>(go);
            EntityTemplateExtensions.AddOrGet<CopyBuildingSettings>(go);
            ((Workable)EntityTemplateExtensions.AddOrGet<ComplexFabricatorWorkable>(go)).overrideAnims = new KAnimFile[1]
            {
                Assets.GetAnim(("anim_interacts_musher_kanim"))
            };
            ((ComplexFabricator)microbeMusher).sideScreenStyle = (ComplexFabricatorSideScreen.StyleSetting)7;
            Prioritizable.AddRef(go);
            EntityTemplateExtensions.AddOrGet<DropAllWorkable>(go);

            ConfigureRecipes();

            EntityTemplateExtensions.AddOrGetDef<PoweredController.Def>(go);
            BuildingTemplates.CreateComplexFabricatorStorage(go, (ComplexFabricator)microbeMusher);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CookTop, false);
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


                //ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
                //{
                //    new ComplexRecipe.RecipeElement(PrickleFruitConfig.ID, 2f),
                //    new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 18f)
                //};
                //ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
                //{
                //    new ComplexRecipe.RecipeElement(SimHashes.SugarWater.CreateTag(), 20f)
                //};
                //ComplexRecipe complexRecipe1 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("MilkPress", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0, 0)
                //{
                //    time = 40f,
                //    description = string.Format((string)BUILDINGS.PREFABS.MILKPRESS.WHEAT_MILK_RECIPE_DESCRIPTION, (object)ITEMS.FOOD.PRICKLEFRUIT.NAME, (object)SimHashes.SugarWater.CreateTag().ProperName()),
                //    nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult,
                //    fabricators = new List<Tag>()
                //    {
                //        TagManager.Create("MilkPress")
                //    },
                //    sortOrder = 6
                //};
            }
        }
    }
}
