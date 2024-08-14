using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_LiceWrap : IEntityConfig
    {
        public const string Id = "LiceWrap";
        public static string Name = UI.FormatAsLink("Lice Wrap", "LiceWrap".ToUpper());
        public static string Description = "A dubious snack made by wrapping fresh " + UI.FormatAsLink("Meal Lice", "BasicPlantFood") + " with " + UI.FormatAsLink("Warm Flat Bread", "FlatBread") + ". The warm flavor from the bread mitigates regretable texture of filling.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Lice Wrap", "LiceWrap");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("LiceWrap", Food_LiceWrap.Name, Food_LiceWrap.Description, 1f, false, Assets.GetAnim((HashedString)"food_lice_wrap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("LiceWrap", "", 2400000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement((Tag) "FlatBread", 1f),
                new ComplexRecipe.RecipeElement((Tag) "BasicPlantFood", 2f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "LiceWrap", 1f)
            };
            Food_LiceWrap.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_LiceWrap.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
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
