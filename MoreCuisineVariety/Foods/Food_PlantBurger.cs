using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_PlantBurger : IEntityConfig
    {
        public const string Id = "PlantBurger";
        public static string Name = UI.FormatAsLink("Plant Burger", "PlantBurger".ToUpper());
        public static string Description = "Tasty " + UI.FormatAsLink("Grilled Plant Meat", "GrilledPlantMeat") + " and " + UI.FormatAsLink("Lettuce", "LETTUCE") + " pressed together inside a split " + UI.FormatAsLink("Mealbrot", "MealBread") + ". Can cause shivers and shakes after consumption.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Plant Burger", "PlantBurger");
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_EXPANSION1_ONLY;

        public static GameObject CreateFabricationVisualizer(GameObject result)
        {
            KBatchedAnimController component = result.GetComponent<KBatchedAnimController>();
            GameObject target = new GameObject();
            target.name = result.name + "Visualizer";
            target.SetActive(false);
            target.transform.SetLocalPosition(Vector3.zero);
            KBatchedAnimController kbatchedAnimController = target.AddComponent<KBatchedAnimController>();
            kbatchedAnimController.AnimFiles = component.AnimFiles;
            kbatchedAnimController.initialAnim = "fabricating";
            kbatchedAnimController.isMovable = true;
            KBatchedAnimTracker kbatchedAnimTracker = target.AddComponent<KBatchedAnimTracker>();
            kbatchedAnimTracker.symbol = new HashedString("meter_ration");
            kbatchedAnimTracker.offset = Vector3.zero;
            Object.DontDestroyOnLoad((Object)target);
            return target;
        }

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("PlantBurger", Food_PlantBurger.Name, Food_PlantBurger.Description, 1f, false, Assets.GetAnim((HashedString)"food_plantburger_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("PlantBurger", "EXPANSION1_ID", 6000000f, 6, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "GrilledPlantMeat", 1f),
                new ComplexRecipe.RecipeElement((Tag) "Lettuce", 1f),
                new ComplexRecipe.RecipeElement((Tag) "MealBread", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("PlantBurger".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_PlantBurger.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_PlantBurger.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
                },
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
