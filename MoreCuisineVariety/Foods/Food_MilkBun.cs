using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Foods
{
    public class Food_MilkBun : IEntityConfig
    {
        public const string Id = "MilkBun";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_MilkBun.Id, "", 2400000f, 3, 255.15f, 277.15f, 4800f, true);
            foodInfo.AddEffects(new List<string>
            {
                Effects.SugarRushId
            },
            DlcManager.AVAILABLE_ALL_VERSIONS);
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_MilkBun.Id,
                    STRINGS.FOOD.MILKBUN.NAME,
                    STRINGS.FOOD.MILKBUN.DESC, 1f, false, Assets.GetAnim(("food_milkbun_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 2f),
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 2f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 4f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_BreadedPacu.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.MILKBUN.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 29
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
