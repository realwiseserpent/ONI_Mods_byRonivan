using DupesCuisine.Plants;
using UnityEngine;

namespace DupesCuisine.Crops
{
    public class Crop_KakawaAcorn //: IEntityConfig
    {
        public const string Id = Plant_KakawaTreeConfig.SeedId; //"Kakawa_Acorn";
        public const float CaloriesPerUnit = 0.0f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 283.15f;
        public const float RotTemperature = 308.15f;
        public const float SpoilTime = 9600f;
        public static EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Id, "", 0.0f, FoodQuality, PreserveTemperature, RotTemperature, SpoilTime, true);

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        //public GameObject CreatePrefab()
        //{
        //    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity(Crop_KakawaAcorn.Id, Crop_KakawaAcorn.Name, Crop_KakawaAcorn.Description, 1f, false, Assets.GetAnim(("crop_kakawaacorn_kanim")), "object", (Grid.SceneLayer)26, 1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null), new EdiblesManager.FoodInfo(Crop_KakawaAcorn.Id, "", 0.0f, -1, 255.15f, 277.15f, 4800f, true));
        //}

        //public void OnPrefabInit(GameObject inst)
        //{
        //}

        //public void OnSpawn(GameObject inst)
        //{
        //}
    }
}
