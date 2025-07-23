using System.Collections.Generic;
using TUNING;
using UnityEngine;
using static EdiblesManager;

namespace DupesCuisine.Foods
{
    public class Food_MeatWrap : IEntityConfig
    {
        public const string Id = "MeatWrap";
        public static ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_MeatWrap.Id, 3200000f, 3, 255.15f, 277.15f, 2400f, true);

            //foodInfo.AddEffects(new List<string>
            //{
            //    Effects.WrapWarmthId
            //});

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_MeatWrap.Id,
                    STRINGS.FOOD.MEATWRAP.NAME,
                    STRINGS.FOOD.MEATWRAP.DESC, 1f, false, Assets.GetAnim(("food_meat_wrap_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                    foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement(Food_FlatBread.Id, 1f),
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    CookedMeatConfig.ID,
                    (Tag)"SmokedDinosaurMeat"
                }, new float[]{ 0.5f, 0.4f })
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_MeatWrap.Id, 1f)
            };
            Food_MeatWrap.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.FOOD.MEATWRAP.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
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
