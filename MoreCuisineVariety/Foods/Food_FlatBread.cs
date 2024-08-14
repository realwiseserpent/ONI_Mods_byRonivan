using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_FlatBread : IEntityConfig
    {
        public const string Id = "FlatBread";
        public static string Name = UI.FormatAsLink("Warm Flat Bread", "FlatBread".ToUpper());
        public static string Description = "A simple flat bread baked from " + UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain") + ". Each bite leaves a mild warmth sensation in one's mouth, even when the bread itself is cold.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Warm Flat Bread", "FlatBread") + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("FlatBread", Food_FlatBread.Name, Food_FlatBread.Description, 1f, false, Assets.GetAnim((HashedString)"food_flat_bread_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("FlatBread", "", 900000f, 0, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "SunnyWheat_Grain", 3f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "FlatBread", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_FlatBread.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
                },
                sortOrder = 3,
            };
            return food;
        }

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
