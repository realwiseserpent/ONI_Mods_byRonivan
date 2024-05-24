using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_SaltedMeat : IEntityConfig
    {
        public const string Id = "SaltedMeat";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_SaltedMeat.Id,
                    STRINGS.FOOD.SALTEDMEAT.NAME,
                    STRINGS.FOOD.SALTEDMEAT.DESC, 1f, false, Assets.GetAnim(("food_saltedmeat_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_SaltedMeat.Id, "", 2000000f, 1, 275.15f, 303.15f, 9600f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement("Meat", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_SaltedMeat.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.SALTEDMEAT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 26
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
