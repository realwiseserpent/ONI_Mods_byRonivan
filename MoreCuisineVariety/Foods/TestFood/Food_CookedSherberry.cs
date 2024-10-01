using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    internal class Food_CookedSherberry : IEntityConfig
    {
        public const string Id = "CookedSherberry";
        public static ComplexRecipe Recipe; 

        public string[] GetDlcIds() => DlcManager.AVAILABLE_DLC_2;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_CookedSherberry.Id,
                    STRINGS.FOOD.COOKEDSHERBERRY.NAME,
                    STRINGS.FOOD.COOKEDSHERBERRY.DESC, 1f, false, Assets.GetAnim("frozenberries_fruit_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true),
                new EdiblesManager.FoodInfo(Food_CookedSherberry.Id, "DLC2_ID", 1050000f, 0, 275.15f, 303.15f, 4800f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("IceCavesForagePlant", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_CookedSherberry.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_CookedSherberry.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.COOKEDSHERBERRY.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 22
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
