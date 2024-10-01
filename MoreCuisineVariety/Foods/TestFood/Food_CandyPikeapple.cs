using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    internal class Food_CandyPikeapple : IEntityConfig
    {
        public const string Id = "CandyPikeapple";
        public static ComplexRecipe recipe; 

        public string[] GetDlcIds() => DlcManager.AVAILABLE_DLC_2;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo info = new EdiblesManager.FoodInfo(Id, "DLC2_ID", 1600000f, 2, 255.15f, 277.15f, 4800f, true);
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(Id, STRINGS.FOOD.CANDYPIKEAPPLE.NAME, STRINGS.FOOD.CANDYPIKEAPPLE.DESC, 
                1f, true, Assets.GetAnim("iceberry_cooked_kanim"),
                "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true);

            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement(CookedPikeappleConfig.ID, 1f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 2f)
            };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
            };
            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, ingredients, results), ingredients, results)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.CANDYPIKEAPPLE.DESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 1
            };
            return EntityTemplates.ExtendEntityToFood(looseEntity, info);
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
 