using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_DuskOmelette : IEntityConfig
    {
        public const string Id = "DuskOmelette";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => null;


        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_DuskOmelette.Id,
                    STRINGS.FOOD.DUSKOMELETTE.NAME,
                    STRINGS.FOOD.DUSKOMELETTE.DESC, 1f, false, Assets.GetAnim(("food_duskomelette_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_DuskOmelette.Id, 3000000f, 3, 255.15f, 277.15f, 2400f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement("RawEgg", 0.5f),
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    FriedMushroomConfig.ID,
                    "Grilled_Creamtop"
                }, new float[]{ 8/14f, 1f })
                //}, new float[]{ 0.5f, 7/9f })
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(TagExtensions.ToTag(Food_DuskOmelette.Id), 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_DuskOmelette.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.DUSKOMELETTE.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 24
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
