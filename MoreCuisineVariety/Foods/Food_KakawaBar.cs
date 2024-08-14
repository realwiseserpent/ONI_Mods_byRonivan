using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_KakawaBar : IEntityConfig
    {
        public const string Id = "KakawaBar";
        public static string Name = UI.FormatAsLink("Kakawa Bar", "KakawaBar".ToUpper());
        public static string Description = UI.FormatAsLink("Roasted Kakawa", "Roasted_Kakawa") + " compressed to a dense, buttery mass. Further cooking remove most of Kakawa bitterness, rendering this bar incredible tasty.";
        public static string RecipeDescription = "Compress a " + UI.FormatAsLink("kakawa Bar", "KakawaBar");
        public ComplexRecipe Recipe;

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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaBar", Food_KakawaBar.Name, Food_KakawaBar.Description, 1f, false, Assets.GetAnim((HashedString)"food_kakawa_bar_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("KakawaBar", "", 2000000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement((Tag) "Roasted_Kakawa", 3f),
                new ComplexRecipe.RecipeElement((Tag) "KakawaButter", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "KakawaBar", 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("MicrobeMusher", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_KakawaBar.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "MicrobeMusher"
                },
                sortOrder = 3,
                requiredTech = (string)null
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
