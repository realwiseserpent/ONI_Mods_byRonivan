using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_NoshPudding : IEntityConfig
    {
        public const string Id = "NoshPudding";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_NoshPudding.Id, "", 6000000f, 6, 255.15f, 277.15f, 2400f, true);
            foodInfo.AddEffects(new List<string>
            {
                "GoodEats",
                Effects.SugarRushId
            },
            DlcManager.AVAILABLE_ALL_VERSIONS);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_NoshPudding.Id,
                    STRINGS.FOOD.NOSHPUDDING.NAME,
                    STRINGS.FOOD.NOSHPUDDING.DESC, 1f, false, Assets.GetAnim(("food_noshpudding_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
            {
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 2f),
                new ComplexRecipe.RecipeElement("ColdWheatSeed", 1f),
                new ComplexRecipe.RecipeElement("RawEgg", 1.5f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_NoshPudding.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.NOSHPUDDING.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 30
            };
            return food;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
