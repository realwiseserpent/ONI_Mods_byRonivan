﻿using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_FishWrap : IEntityConfig
    {
        public const string Id = "FishWrap";
        public static string Name = UI.FormatAsLink("Pacu Wrap", "FishWrap".ToUpper());
        public static string Description = "A tasty snack made by wrapping grilled " + UI.FormatAsLink("Pacu Fillet", "FishMeat") + " with " + UI.FormatAsLink("Warm Flat Bread", "FlatBread") + ". Each bite leaves a mild warm sensation in one's mouth, even when the snack itself is served cold.";
        public static string RecipeDescription = "Bake a " + UI.FormatAsLink("Pacu Wrap", "FishWrap");
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
            GameObject food = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("FishWrap", Food_FishWrap.Name, Food_FishWrap.Description, 1f, false, Assets.GetAnim((HashedString)"food_fish_wrap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("FishWrap", "", 2200000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement((Tag) "FlatBread", 1f),
                new ComplexRecipe.RecipeElement((Tag) "FishMeat", 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Tag) "FishWrap", 1f)
            };
            Food_FishWrap.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", (IList<ComplexRecipe.RecipeElement>)recipeElementArray1, (IList<ComplexRecipe.RecipeElement>)recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                description = Food_FishWrap.RecipeDescription,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>()
                {
                    (Tag) "CookingStation"
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
