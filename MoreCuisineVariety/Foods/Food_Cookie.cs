using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_Cookie : IEntityConfig
    {
        public const string Id = "KakawaCookie";
        public static string Name = UI.FormatAsLink("Frost Cookie", "KakawaCookie".ToUpper());
        public static string Description = "A buttery cookie with a subtle bittersweet, cold flavor.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Frost Cookie", "KakawaCookie") + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaCookie", Food_Cookie.Name, Food_Cookie.Description, 1f, false, Assets.GetAnim((HashedString)"food_cookie_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.5f, true), new EdiblesManager.FoodInfo("KakawaCookie", "", 4000000f, 4, 255.15f, 277.15f, 3200f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "ColdWheatSeed", 3f),
                new ComplexRecipe.RecipeElement((Tag) "Roasted_Kakawa", 4f),
                new ComplexRecipe.RecipeElement((Tag) "KakawaButter", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "KakawaCookie", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_Cookie.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
                },
                sortOrder = 3,
                requiredTech = (string)null
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
