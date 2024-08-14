using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_MeatTaco : IEntityConfig
    {
        public const string Id = "MeatTaco";
        public static string Name = UI.FormatAsLink("Meat Taco", "MeatTaco".ToUpper());
        public static string Description = "A filling meal made with slowly baked " + UI.FormatAsLink("Meat", "Meat") + " with " + UI.FormatAsLink("Omellete", "CookedEgg") + ", all served within a " + UI.FormatAsLink("Warm Flat Bread", "FlatBread") + ". It promptly leaves a warm sensation while it goes inside, as well when it leaves.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Meat Taco", "MeatTaco");
        public static ComplexRecipe Recipe;

        public static GameObject CreateFabricationVisualizer(GameObject result)
        {
            GameObject gameObject = new GameObject();
            gameObject.name = result.name + "Visualizer";
            GameObject target = gameObject;
            target.SetActive(false);
            target.transform.SetLocalPosition(Vector3.zero);
            KBatchedAnimController kbatchedAnimController = target.AddComponent<KBatchedAnimController>();
            kbatchedAnimController.AnimFiles = result.GetComponent<KBatchedAnimController>().AnimFiles;
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MeatTaco", Food_MeatTaco.Name, Food_MeatTaco.Description, 1f, false, Assets.GetAnim((HashedString)"food_meat_taco_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("MeatTaco", "", 6000000f, 6, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement((Tag) "FlatBread", 1f),
                new ComplexRecipe.RecipeElement((Tag) "CookedMeat", 0.5f),
                new ComplexRecipe.RecipeElement((Tag) "CookedEgg", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "MeatTaco", 1f)
            };
            Food_MeatTaco.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_MeatTaco.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
                },
                sortOrder = 3,
            };
            return food;
        }

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
