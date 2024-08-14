using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_MilkBun : IEntityConfig
    {
        public const string Id = "MilkBun";
        public static string Name = UI.FormatAsLink("Milk Bun", "MilkBun".ToUpper());
        public static string Description = "A soft bun baked from " + UI.FormatAsLink("Meal Batter", "MealSlurry") + ", " + UI.FormatAsLink("Nosh Milk", "NoshMilk") + " and " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". It gives the duplicants who eats it a happy face, and a quite unhappy face to others who will have to endure the farts.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Milk Bun", "MealBread");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MilkBun", Food_MilkBun.Name, Food_MilkBun.Description, 1f, false, Assets.GetAnim((HashedString)"food_milkbun_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("MilkBun", "EXPANSION1_ID", 2200000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "MealSlurry", 1f),
                new ComplexRecipe.RecipeElement((Tag) "NoshMilk", 0.25f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 4f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("MilkBun".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_BreadedPacu.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_MilkBun.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
                },
                sortOrder = 29
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
