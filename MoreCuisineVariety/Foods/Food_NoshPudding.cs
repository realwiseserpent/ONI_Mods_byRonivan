using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_NoshPudding : IEntityConfig
    {
        public const string Id = "NoshPudding";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => null;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_NoshPudding.Id, 4000000f, 5, 255.15f, 277.15f, 2400f, true);
            foodInfo.AddEffects(new List<string>
            {
                Effects.SugarRushId
            });

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_NoshPudding.Id,
                    STRINGS.FOOD.NOSHPUDDING.NAME,
                    STRINGS.FOOD.NOSHPUDDING.DESC, 1f, false, Assets.GetAnim(("food_noshpudding_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
            {
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    "ColdWheatSeed",
                    FernFoodConfig.ID
                }, 1f),
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 1f),
                new ComplexRecipe.RecipeElement("RawEgg", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 8f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_NoshPudding.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.NOSHPUDDING.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 30
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
