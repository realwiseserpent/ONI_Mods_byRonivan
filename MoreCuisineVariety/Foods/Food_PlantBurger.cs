using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_PlantBurger : IEntityConfig
    {
        public const string Id = "PlantBurger";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_PlantBurger.Id, "", 6000000f, 6, 255.15f, 277.15f, 2400f, true);

            foodInfo.AddEffects(new List<string>
            {
                "GoodEats"
            }, DlcManager.AVAILABLE_ALL_VERSIONS);

            foodInfo.AddEffects(new List<string>
            {
                "SeafoodRadiationResistance"
            }, DlcManager.AVAILABLE_EXPANSION1_ONLY);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_PlantBurger.Id,
                    STRINGS.FOOD.PLANTBURGER.NAME,
                    STRINGS.FOOD.PLANTBURGER.DESC, 1f, false, Assets.GetAnim(("food_plantburger_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);
            
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_MealBread.Id, 1f),
                new ComplexRecipe.RecipeElement("Lettuce", 2f),
                new ComplexRecipe.RecipeElement(Food_GrilledPlantMeat.Id, 1.5f),
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_PlantBurger.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.PLANTBURGER.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 33
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
