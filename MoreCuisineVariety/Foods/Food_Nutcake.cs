using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_Nutcake : IEntityConfig
    {
        public const string Id = "Nut_cake";
        public static string Name = UI.FormatAsLink("Nutcake", "Nut_cake".ToUpper());
        public static string Description = "A saborous " + UI.FormatAsLink("Nutcake", "Nut_cake") + " baked from bitter nuts, spieces and wheat. Brings warmth to the heart (and stomach).";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Nutcake", "Nut_cake") + " .";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Nut_cake", Food_Nutcake.Name, Food_Nutcake.Description, 1f, false, Assets.GetAnim((HashedString)"food_nutcake_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.5f, true), new EdiblesManager.FoodInfo("Nut_cake", "", 4600000f, 5, 255.15f, 277.15f, 3200f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "SunnyWheat_Grain", 8f),
                new ComplexRecipe.RecipeElement((Tag) "Roasted_Kakawa", 4f),
                new ComplexRecipe.RecipeElement((Tag) "KakawaButter", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Nut_cake", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_Nutcake.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
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
