using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Crops
{
    public class Crop_SunnyWheatGrain : IEntityConfig
    {
        public const string Id = "SunnyWheat_Grain";
        public static string Name = UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain".ToUpper());
        public static string Description = "The edible grain of a " + UI.FormatAsLink("Sunny Wheat", "SunnyWheat") + ". This edible grain leaves a warm taste on the tongue.";
        public const float CaloriesPerUnit = 0.0f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 255.15f;
        public const float RotTemperature = 277.15f;
        public const float SpoilTime = 3000f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SunnyWheat_Grain", Crop_SunnyWheatGrain.Name, Crop_SunnyWheatGrain.Description, 1f, false, Assets.GetAnim((HashedString)"crop_sunnygrain_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("SunnyWheat_Grain", "", 0.0f, -1, 255.15f, 277.15f, 3000f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
