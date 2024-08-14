using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_MealBread : IEntityConfig
    {
        public const string Id = "MealBread";
        public static string Name = UI.FormatAsLink("Mealbrot", "MealBread".ToUpper());
        public static string Description = "A loaf of " + UI.FormatAsLink("Bread", "MealBread") + " baked from a mixture of " + UI.FormatAsLink("Meal Batter", "MealSlurry") + ", " + UI.FormatAsLink("Nosh Milk", "NoshMilk") + " and " + UI.FormatAsLink("Eggs", "RAWEGG") + ". Despite its hard crust, this bread is actually tasty, and has a long shelf life.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Mealbrot", "MealBread");
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MealBread", Food_MealBread.Name, Food_MealBread.Description, 1f, false, Assets.GetAnim((HashedString)"food_mealbread_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("MealBread", "", 2800000f, 2, 267.15f, 315.15f, 7600f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "MealSlurry", 1f),
                new ComplexRecipe.RecipeElement((Tag) "NoshMilk", 0.5f),
                new ComplexRecipe.RecipeElement((Tag) "RawEgg", 0.5f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("MealBread".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_MealBread.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_MealBread.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
                },
                sortOrder = 28
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
