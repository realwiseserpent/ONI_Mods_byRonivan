using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_JellyDoughnut : IEntityConfig
    {
        public const string Id = "JellyDoughnut";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_JellyDoughnut.Id,
                    STRINGS.FOOD.JELLYDOUGHNUT.NAME,
                    STRINGS.FOOD.JELLYDOUGHNUT.DESC, 1f, false, Assets.GetAnim(("food_jellydoughnut_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                new EdiblesManager.FoodInfo(Food_JellyDoughnut.Id, "", 2940000f, 2, 255.15f, 277.15f, 4800f, true));


            ComplexRecipe.RecipeElement[] recipeElementArray1;
            if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
                recipeElementArray1 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f),
                    new ComplexRecipe.RecipeElement(SwampDelightsConfig.ID, 1f)
                };
            else
                recipeElementArray1 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 2f),
                    new ComplexRecipe.RecipeElement(GrilledPrickleFruitConfig.ID, 1f)
                };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_JellyDoughnut.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.JELLYDOUGHNUT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 32
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
