using UnityEngine;

namespace DupesCuisine.Crops
{
    public class Crop_Creamcap : IEntityConfig
    {
        public const string Id = "Creamtop_Cap";
        public const float CaloriesPerUnit = 1400000f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 255.15f;
        public const float RotTemperature = 277.15f;
        public const float SpoilTime = 4800f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood
                (EntityTemplates.CreateLooseEntity(
                    Crop_Creamcap.Id,
                    STRINGS.CROPS.CREAMCAP.NAME,
                    STRINGS.CROPS.CREAMCAP.DESC, 1f, false, Assets.GetAnim(("crop_creamcap_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                    new EdiblesManager.FoodInfo(Crop_Creamcap.Id, "", CaloriesPerUnit, FoodQuality, PreserveTemperature, RotTemperature, SpoilTime, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
