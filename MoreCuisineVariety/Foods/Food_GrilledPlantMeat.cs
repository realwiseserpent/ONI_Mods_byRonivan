using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_GrilledPlantMeat : IEntityConfig
    {
        public const string Id = "GrilledPlantMeat";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_GrilledPlantMeat.Id,
                    STRINGS.FOOD.GRILLEDPLANTMEAT.NAME,
                    STRINGS.FOOD.GRILLEDPLANTMEAT.DESC, 1f, false, Assets.GetAnim(("food_grilled_plantmeat_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                new EdiblesManager.FoodInfo(Food_GrilledPlantMeat.Id, "", 1600000f, 2, 255.15f, 277.15f, 2400f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1;
            if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
                recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement("PlantMeat", 1f)
                };
            else
                recipeElementArray1 = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement("BasicPlantFood", 8/3f),
                    new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f),
                };

            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_GrilledPlantMeat.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.GRILLEDPLANTMEAT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 27
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
