using Dupes_Cuisine.Food;
using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace Dupes_Cuisine.Buildings
{
    public class ManualJuicerConfig : IBuildingConfig
    {
        public const string ID = "ManualJuicer";
        public const string DisplayName = "Food Grinder";
        public const string Description = "A cooking appliance used to grind down food in to liquids.";
        public static string Effect = "The grinder uses a mixture of " + UI.FormatAsLink("Water", "WATER") + " and other food to make special ingredients used in culinary.";

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
            this.ConfigureRecipes();
            go.AddOrGetDef<PoweredController.Def>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, (ComplexFabricator)fabricator);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CookTop);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("ManualJuicer", 2, 3, "food_grinder_kanim", 100, 10f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, TUNING.MATERIALS.RAW_MINERALS, 1600f, BuildLocationRule.OnFloor, TUNING.BUILDINGS.DECOR.NONE, none);
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
            string str1 = UI.FormatAsLink("Nosh Beans", "BEAN");
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement((Tag) "BeanPlantSeed", 2f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("NoshMilk".ToTag(), 3f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
            };
            ComplexRecipe complexRecipe1 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("ManualJuicer", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = 25f
            };
            string[] strArray1 = new string[3]
            {
                "Grind down ",
                str1,
                " to a pulp, and produce fresh Nosh Milk."
            };
            complexRecipe1.description = string.Format(string.Concat(strArray1), (object)str1);
            complexRecipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> tagList1 = new List<Tag>()
            {
                (Tag) "ManualJuicer"
            };
            complexRecipe1.fabricators = tagList1;
            complexRecipe1.sortOrder = 1;
            Food_NoshMilkConfig.recipe = complexRecipe1;
            string str2 = UI.FormatAsLink("Meal Lice", "BASICPLANTFOOD");
            ComplexRecipe.RecipeElement[] recipeElementArray3 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement((Tag) "BasicPlantFood", 2f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray4 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("MealSlurry".ToTag(), 3f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
            };
            ComplexRecipe complexRecipe2 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("ManualJuicer", (IList<ComplexRecipe.RecipeElement>)recipeElementArray3, (IList<ComplexRecipe.RecipeElement>)recipeElementArray4), recipeElementArray3, recipeElementArray4, 0)
            {
                time = 25f
            };
            string[] strArray2 = new string[3]
            {
                "Grind down ",
                str2,
                " to a pulp, and produce sticky Meal Batter."
            };
            complexRecipe2.description = string.Format(string.Concat(strArray2), (object)str2);
            complexRecipe2.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> tagList2 = new List<Tag>()
            {
                (Tag) "ManualJuicer"
            };
            complexRecipe2.fabricators = tagList2;
            complexRecipe2.sortOrder = 2;
            Food_NoshMilkConfig.recipe = complexRecipe2;
        }
    }
}
