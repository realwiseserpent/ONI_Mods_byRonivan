using System.Collections.Generic;
using UnityEngine;
using TUNING;
using DupesCuisine.Buildings;

namespace DupesCuisine.Foods
{
    public class Food_MealSlurryConfig : IEntityConfig
    {
        public const string Id = "MealSlurry";
        public static ComplexRecipe recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            ConfigureRecipes();

            return EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_MealSlurryConfig.Id,
                    STRINGS.FOOD.MEALSLURRY.NAME,
                    STRINGS.FOOD.MEALSLURRY.DESC, 1f, true, Assets.GetAnim(("meal_slurry_kanim")), "object", (Grid.SceneLayer)26, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_MealSlurryConfig.Id, "", 0.0f, -1, 255.15f, 277.15f, 4800f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }

        private void ConfigureRecipes()
        {
            ComplexRecipe.RecipeElement[] recipeElementArray3 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement("BasicPlantFood", 5f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray4 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 10f, 0, false)
            };

            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, recipeElementArray3, recipeElementArray4), recipeElementArray3, recipeElementArray4, 0)
            {
                time = FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.FOOD.MEALSLURRY.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag> { ManualJuicerConfig.ID },
                sortOrder = 2
            };
        }
    }
}
