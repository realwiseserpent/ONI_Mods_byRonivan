using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_Nutpie : IEntityConfig
    {
        public const string Id = "Nutpie";
        public static string Name = UI.FormatAsLink("Grubner Nusstorte", "Nutpie".ToUpper());
        public static string Description = "A gourmet pie with a nut filling of caramelised " + UI.FormatAsLink("Roast Grubfruit Nuts", "WORMBASICFOOD") + ", " + UI.FormatAsLink("Sleet Wheat Grain", "COLDWHEATSEED") + " and " + UI.FormatAsLink("Eggs", "RAWEGG") + " dough, and " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". The buttery crust remains fresh for a long time.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Grubner Nusstorte", "Nutpie");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Nutpie", Food_Nutpie.Name, Food_Nutpie.Description, 1f, false, Assets.GetAnim((HashedString)"food_nutpie_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("Nutpie", "EXPANSION1_ID", 6000000f, 6, 255.15f, 277.15f, 6000f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
            {
                new ComplexRecipe.RecipeElement((Tag) "WormBasicFood", 3f),
                new ComplexRecipe.RecipeElement((Tag) "ColdWheatSeed", 4f),
                new ComplexRecipe.RecipeElement((Tag) "RawEgg", 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement("Nutpie".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            Food_Nutpie.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME,
                description = Food_Nutpie.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "GourmetCookingStation"
                },
                sortOrder = 31
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
