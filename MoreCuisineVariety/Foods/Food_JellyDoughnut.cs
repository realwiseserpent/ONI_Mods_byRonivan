using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_JellyDoughnut : IEntityConfig
    {
        public const string Id = "JellyDoughnut";
        public static string Name = UI.FormatAsLink("Jelly Doughnut", "JellyDoughnut".ToUpper());
        public static string Description = "A leavened fried dough prepared from " + UI.FormatAsLink("Meal Lice Batter", "MealSlurry") + " and " + UI.FormatAsLink("Nosh Milk", "NoshMilk") + ". The interior is filled a hearty portion of " + UI.FormatAsLink("Bog Jelly", "SWAMPFRUIT") + ".";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Jelly Doughnut", "JellyDoughnut");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("JellyDoughnut", Food_JellyDoughnut.Name, Food_JellyDoughnut.Description, 1f, false, Assets.GetAnim((HashedString)"food_jellydoughnut_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("JellyDoughnut", "EXPANSION1_ID", 2800000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "MealSlurry", 0.3f),
                new ComplexRecipe.RecipeElement((Tag) "NoshMilk", 0.25f),
                new ComplexRecipe.RecipeElement((Tag) SwampFruitConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("JellyDoughnut".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_JellyDoughnut.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_JellyDoughnut.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
                },
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
