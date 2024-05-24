using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_MeatTaco : IEntityConfig
    {
        public const string Id = "MeatTaco";
        public static ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_MeatTaco.Id, "", 6000000f, 6, 255.15f, 277.15f, 2400f, true);
            foodInfo.AddEffects(new List<string>
            {
                "GoodEats"
            }, 
            DlcManager.AVAILABLE_ALL_VERSIONS);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_MeatTaco.Id,
                    STRINGS.FOOD.MEATTACO.NAME,
                    STRINGS.FOOD.MEATTACO.DESC, 1f, false, Assets.GetAnim(("food_meat_taco_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement(Food_FlatBread.Id, 1f),
                new ComplexRecipe.RecipeElement("CookedMeat", 0.5f),
                new ComplexRecipe.RecipeElement("CookedEgg", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_MeatTaco.Id, 1f)
            };
            Food_MeatTaco.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.FOOD.MEATTACO.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 3
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
