using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_MealSlurryConfig : IEntityConfig
    {
        public const string Id = "MealSlurry";
        public static string Name = UI.FormatAsLink("Meal Batter", "MealSlurry".ToUpper());
        public static string Description = "A fearsome sticky slurry made from " + UI.FormatAsLink("Meal Lice", "BasicPlantFood") + " and Water. Used as a basic ingredient in many recipes.";
        public static ComplexRecipe recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MealSlurry", Food_MealSlurryConfig.Name, Food_MealSlurryConfig.Description, 1f, false, Assets.GetAnim((HashedString)"meal_slurry_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("MealSlurry", "", 0.0f, -1, 255.15f, 277.15f, 2400f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
