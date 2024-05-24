using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_MealBread : IEntityConfig
    {
        public const string Id = "MealBread";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_MealBread.Id,
                    STRINGS.FOOD.MEALBREAD.NAME,
                    STRINGS.FOOD.MEALBREAD.DESC, 1f, false, Assets.GetAnim(("food_mealbread_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_MealBread.Id, "", 2400000f, 3, 275.15f, 298.15f, 7200f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f),
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 1f),
                new ComplexRecipe.RecipeElement("RawEgg", 0.5f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_MealBread.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.MEALBREAD.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 28
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
