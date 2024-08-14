using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_GrilledCreamtop : IEntityConfig
    {
        public const string Id = "Grilled_Creamtop";
        public static string Name = UI.FormatAsLink("Grilled Creamcap", "Grilled_Creamtop".ToUpper());
        public static string Description = "The grilled fruiting of a " + UI.FormatAsLink("Creamcap", "Creamtop_Cap") + ". It has a crispy texture and a soft, mildly sweet, earthy flavor.";
        public static string RecipeDescription = "Grills a " + UI.FormatAsLink("Creamtop Cap", "Creamtop_Cap") + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Grilled_Creamtop", Food_GrilledCreamtop.Name, Food_GrilledCreamtop.Description, 1f, false, Assets.GetAnim((HashedString)"food_grilled_creamtop_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("Grilled_Creamtop", "", 1800000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Creamtop_Cap", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "Grilled_Creamtop", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_GrilledCreamtop.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
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
