using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Food
{
    public class Food_NoshMilkConfig : IEntityConfig
    {
        public const string Id = "NoshMilk";
        public static string Name = UI.FormatAsLink("Nosh Milk", "NoshMilk".ToUpper());
        public static string Description = "A plant-based drink produced by soaking and pressing of " + UI.FormatAsLink("Nosh Bean", "BEAN") + ".";
        public static ComplexRecipe recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("NoshMilk", Food_NoshMilkConfig.Name, Food_NoshMilkConfig.Description, 1f, false, Assets.GetAnim((HashedString)"nosh_milk_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("NoshMilk", "", 0.0f, -1, 255.15f, 277.15f, 2400f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
