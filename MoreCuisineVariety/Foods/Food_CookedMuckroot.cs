using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_CookedMuckroot : IEntityConfig
    {
        public const string Id = "CookedMuckroot";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity(
                Food_CookedMuckroot.Id, 
                STRINGS.FOOD.COOKEDMUCKROOT.NAME,
                STRINGS.FOOD.COOKEDMUCKROOT.DESC, 1f, false, Assets.GetAnim(("food_cooked_muckroot_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true), 
                new EdiblesManager.FoodInfo(Food_CookedMuckroot.Id, "", 1050000f, 0, 275.15f, 303.15f, 4800f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("BasicForagePlant", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_CookedMuckroot.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_CookedMuckroot.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.COOKEDMUCKROOT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 21
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
