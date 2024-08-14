using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_NoshPudding : IEntityConfig
    {
        public const string Id = "NoshPudding";
        public static string Name = UI.FormatAsLink("Nosh Custard Flan", "NoshPudding".ToUpper());
        public static string Description = "A fancy sweet dessert made with " + UI.FormatAsLink("Nosh Milk", "NoshMilk") + ", " + UI.FormatAsLink("Sleet Wheat Grain", "COLDWHEATSEED") + ", whisked " + UI.FormatAsLink("Eggs", "RAWEGG") + " and quite a lot of " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". Has a fine rimmed pastry that prevents it from breaking apart as one holds it (for a short time).";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Nosh Custard Flan", "NoshPudding");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("NoshPudding", Food_NoshPudding.Name, Food_NoshPudding.Description, 1f, false, Assets.GetAnim((HashedString)"food_noshpudding_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("NoshPudding", "EXPANSION1_ID", 4000000f, 4, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
            {
                new ComplexRecipe.RecipeElement((Tag) "NoshMilk", 1f),
                new ComplexRecipe.RecipeElement((Tag) "ColdWheatSeed", 1f),
                new ComplexRecipe.RecipeElement((Tag) "RawEgg", 2f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("NoshPudding".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_NoshPudding.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_NoshPudding.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
                },
                sortOrder = 30
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
