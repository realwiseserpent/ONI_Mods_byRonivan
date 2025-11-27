using System.Collections.Generic;
using TUNING;
using UnityEngine;
using static STRINGS.ITEMS.FOOD;

namespace DupesCuisine.Foods
{
    public class Food_SeaTaco : IEntityConfig
    {
        public const string Id = "SeaTaco";
        public static ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_SeaTaco.Id, 6000000f, 6, 255.15f, 277.15f, 2400f, true);

            foodInfo.AddEffects(new List<string>
            {
                "GoodEats",
            });

            foodInfo.AddEffects(new List<string>
            {
                "SeafoodRadiationResistance"
            }, DlcManager.EXPANSION1);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_SeaTaco.Id,
                    STRINGS.FOOD.SEATACO.NAME,
                    STRINGS.FOOD.SEATACO.DESC, 1f, false, Assets.GetAnim(("food_sea_taco_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_FlatBread.Id, 2f),
                new ComplexRecipe.RecipeElement("Lettuce", 1.5f),
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    "CookedFish",
                    "SmokedFish"
                }, new float[]{ 2f, 8/7f }),
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_SeaTaco.Id, 1f)
            };
            Food_SeaTaco.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.SEATACO.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 3
            };
            return food;
        }

        public string[] GetDlcIds() => null;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
