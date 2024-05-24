using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_BreadedPacu : IEntityConfig
    {
        public const string Id = "BreadedPacu";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_BreadedPacu.Id, "", 2300000f, 3, 255.15f, 277.15f, 2400f, true);

            foodInfo.AddEffects(new List<string>
            {
                "SeafoodRadiationResistance"
            }, 
            DlcManager.AVAILABLE_EXPANSION1_ONLY);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_BreadedPacu.Id,
                    STRINGS.FOOD.BREADEDPACU.NAME,
                    STRINGS.FOOD.BREADEDPACU.DESC, 1f, false, Assets.GetAnim(("food_breaded_pacu_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f),
                new ComplexRecipe.RecipeElement(CookedFishConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_BreadedPacu.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_BreadedPacu.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.BREADEDPACU.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 23
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
