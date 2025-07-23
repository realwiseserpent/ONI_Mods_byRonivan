using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_JellyDoughnut : IEntityConfig
    {
        public const string Id = "JellyDoughnut";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => null;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_JellyDoughnut.Id,
                    STRINGS.FOOD.JELLYDOUGHNUT.NAME,
                    STRINGS.FOOD.JELLYDOUGHNUT.DESC, 1f, false, Assets.GetAnim(("food_jellydoughnut_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                new EdiblesManager.FoodInfo(Food_JellyDoughnut.Id, 2500000f, 3, 255.15f, 277.15f, 4800f, true));

            List<Tag> fruits = new List<Tag>()
                {
                    SwampDelightsConfig.ID,
                    VineFruitConfig.ID
                };

            List<float> fruitAmount = new List<float>() { 2 / 3f, 1500 / 325f };

            if (!DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
            {
                fruits.Add(GrilledPrickleFruitConfig.ID);
                fruits.Add("CookedPikeapple");

                fruitAmount.Add(3 / 4f);
                fruitAmount.Add(5 / 4f);
            } 

            if (false)//(ModInfo.IsFragrantFlowersEnabled)
            {
                //FoodInfo duskberryFoodInfo = duskberry.AddOrGet<Edible>().FoodInfo;
                fruits.Add("Duskberry");
                fruitAmount.Add(2f);// 2300f/duskberryFoodInfo.CaloriesPerUnit);

                //FoodInfo spinosaHipsFoodInfo = spinosaHips.AddOrGet<Edible>().FoodInfo;
                fruits.Add("SpinosaHips");
                fruitAmount.Add(2f);// 2300f / spinosaHipsFoodInfo.CaloriesPerUnit);
            }

            ComplexRecipe.RecipeElement[] recipeElementArray1;

            recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(fruits.ToArray(), fruitAmount.ToArray()),
                new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f),
            };

            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_JellyDoughnut.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.JELLYDOUGHNUT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 32
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
