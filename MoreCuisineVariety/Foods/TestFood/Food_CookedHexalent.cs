using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    internal class Food_CookedHexalent : IEntityConfig
    {
        public const string Id = "CookedHexalent";
        public static ComplexRecipe Recipe; 

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_CookedHexalent.Id,
                    STRINGS.FOOD.COOKEDHEXALENT.NAME,
                    STRINGS.FOOD.COOKEDHEXALENT.DESC, 1f, false, Assets.GetAnim(("podmelon_fruit_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)0, 0.3f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_CookedHexalent.Id, "", 1050000f, 0, 275.15f, 303.15f, 4800f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("ForestForagePlant", 1/8f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_CookedHexalent.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_CookedHexalent.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.COOKEDHEXALENT.RECIPEDESC,
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
