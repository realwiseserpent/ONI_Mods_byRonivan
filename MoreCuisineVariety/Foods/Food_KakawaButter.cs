using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using Dupes_Cuisine.Crops;

namespace Dupes_Cuisine.Food
{
    public class Food_KakawaButter : IEntityConfig
    {
        public const string Id = "KakawaButter";
        public static string Name = UI.FormatAsLink("Kakawa Butter", "KakawaButter".ToUpper());
        public static string Description = "An oily butter extracted from " + Crop_KakawaAcorn.Name + ". This butter has a tasty aroma, although one must like bitterness to actually eat it in this form.";
        public static string RecipeDescription = "Extract oil from " + Crop_KakawaAcorn.Name + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaButter", Food_KakawaButter.Name, Food_KakawaButter.Description, 1f, false, Assets.GetAnim((HashedString)"food_kakawa_butter_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("KakawaButter", "", 0.0f, -1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Kakawa_Acorn", 4f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "KakawaButter", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_KakawaButter.RecipeDescription,
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
