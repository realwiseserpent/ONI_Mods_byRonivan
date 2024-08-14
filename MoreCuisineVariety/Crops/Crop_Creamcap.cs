using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Crops
{
    public class Crop_Creamcap : IEntityConfig
    {
        public const string Id = "Creamtop_Cap";
        public static string Name = UI.FormatAsLink("Creamcap", "Creamtop_Cap".ToUpper());
        public static string Description = "The fruiting body of a Creamcap Mushroom. Has a rich earthy flavor and a pungent, mildly sweet aroma";
        public const float CaloriesPerUnit = 1200000f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 255.15f;
        public const float RotTemperature = 277.15f;
        public const float SpoilTime = 3200f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Creamtop_Cap", Crop_Creamcap.Name, Crop_Creamcap.Description, 1f, false, Assets.GetAnim((HashedString)"crop_creamcap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("Creamtop_Cap", "", 1200000f, -1, 255.15f, 277.15f, 3200f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
