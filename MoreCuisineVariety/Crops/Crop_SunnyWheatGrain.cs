using UnityEngine;

namespace DupesCuisine.Crops
{
    public class Crop_SunnyWheatGrain //: IEntityConfig
    {
        public const string Id = "SunnyWheat_Grain";
        public const float CaloriesPerUnit = 0.0f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 283.15f;
        public const float RotTemperature = 308.15f;
        public const float SpoilTime = 9600f;
        public static EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Id, "", CaloriesPerUnit, FoodQuality, PreserveTemperature, RotTemperature, SpoilTime, true);

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        //public GameObject CreatePrefab()
        //{
        //    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity(Crop_SunnyWheatGrain.Id, Crop_SunnyWheatGrain.Name, Crop_SunnyWheatGrain.Description, 1f, false, Assets.GetAnim(("crop_sunnygrain_kanim")), "object", (Grid.SceneLayer)26, 1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null), 
        //        new EdiblesManager.FoodInfo(Crop_SunnyWheatGrain.Id, "", 0.0f, -1, 255.15f, 277.15f, 3000f, true));
        //}

        //public void OnPrefabInit(GameObject inst)
        //{
        //}

        //public void OnSpawn(GameObject inst)
        //{
        //}
    }
}
