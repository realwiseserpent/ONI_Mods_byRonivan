using STRINGS;
using System.Collections.Generic;
using UnityEngine;
using Dupes_Cuisine.Crops;

namespace Dupes_Cuisine.Food
{
    public class Food_RoastedKakawa : IEntityConfig
    {
        public const string Id = "Roasted_Kakawa";
        public static string Name = UI.FormatAsLink("Roasted Kakawa", "Roasted_Kakawa".ToUpper());
        public static string Description = "A fully roasted " + Crop_KakawaAcorn.Name + ". The roasting crack open its hard shell reaveling a edible nut, although the eating may be a bitter experience.";
        public static string RecipeDescription = "Roast a " + Crop_KakawaAcorn.Name + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Roasted_Kakawa", Food_RoastedKakawa.Name, Food_RoastedKakawa.Description, 1f, false, Assets.GetAnim((HashedString)"food_roasted_kakawa_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("Roasted_Kakawa", "", 300000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Kakawa_Acorn", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Roasted_Kakawa", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_RoastedKakawa.RecipeDescription,
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
