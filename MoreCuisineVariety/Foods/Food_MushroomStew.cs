using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_MushroomStew : IEntityConfig
    {
        public const string Id = "MushroomStew";
        public static string Name = UI.FormatAsLink("Mushroom Stew", "MushroomStew".ToUpper());
        public static string Description = "A thick, flavorful soup made by simmering mushroons and spices, placed within a hallowed Frost Bun and baked in a oven.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Mushroom Stew", "MushroomStew") + ".";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MushroomStew", Food_MushroomStew.Name, Food_MushroomStew.Description, 1f, false, Assets.GetAnim((HashedString)"food_mushroom_stew_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.5f, true), new EdiblesManager.FoodInfo("MushroomStew", "", 5000000f, 6, 255.15f, 277.15f, 1200f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
            {
                new ComplexRecipe.RecipeElement((Tag) "ColdWheatBread", 1f),
                new ComplexRecipe.RecipeElement((Tag) "SunnyWheat_Grain", 2f),
                new ComplexRecipe.RecipeElement((Tag) "Grilled_Creamtop", 2f),
                new ComplexRecipe.RecipeElement((Tag) SpiceNutConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "MushroomStew", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_MushroomStew.RecipeDescription,
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
