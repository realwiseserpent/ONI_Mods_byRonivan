using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_BreadedPacu : IEntityConfig
    {
        public const string Id = "BreadedPacu";
        public static ComplexRecipe originalRecipe;
        public static ComplexRecipe extendedRecipe;

        public string[] GetDlcIds() => null;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_BreadedPacu.Id, 2200000f, 3, 255.15f, 277.15f, 9600f, true);

            foodInfo.AddEffects(new List<string>
            {
                "SeafoodRadiationResistance"
            },
            DlcManager.EXPANSION1);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_BreadedPacu.Id,
                    STRINGS.FOOD.BREADEDPACU.NAME,
                    STRINGS.FOOD.BREADEDPACU.DESC, 1f, false, Assets.GetAnim(("food_breaded_pacu_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                foodInfo);

            ComplexRecipe.RecipeElement[] originalIngredients = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    "FishMeat",
                    "ShellfishMeat",
                    "PrehistoricPacuFillet"
                }, 1f),
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f)
            };
            ComplexRecipe.RecipeElement[] originalResult = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_BreadedPacu.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_BreadedPacu.originalRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, originalIngredients, originalResult), originalIngredients, originalResult)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.BREADEDPACU.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 23
            };
            //------------------------------

            ComplexRecipe.RecipeElement[] extendedIngredients = new ComplexRecipe.RecipeElement[2]
{
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    "FishMeat",
                    "ShellfishMeat",
                    "PrehistoricPacuFillet"
                }, 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Tallow.CreateTag(), 0.6f)
};
            ComplexRecipe.RecipeElement[] extendedResult = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_BreadedPacu.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_BreadedPacu.extendedRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(DeepfryerConfig.ID, extendedIngredients, extendedResult), extendedIngredients, extendedResult, DlcManager.DLC2)
            {
                time = FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.FOOD.BREADEDPACU.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { DeepfryerConfig.ID },
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
