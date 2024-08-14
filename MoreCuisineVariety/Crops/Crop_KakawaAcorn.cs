using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Crops
{
    public class Crop_KakawaAcorn : IEntityConfig
    {
        public const string Id = "Kakawa_Acorn";
        public static string Name = UI.FormatAsLink("Kakawa Acorn", "Kakawa_Acorn".ToUpper());
        public static string Description = "The fruits of a " + UI.FormatAsLink("Kakawa Tree", "KakawaTree") + ". Differently from other nuts, this one is so hard that can't be eat raw. The edible inside is also very bitter.";
        public const float CaloriesPerUnit = 0.0f;
        public const int FoodQuality = -1;
        public const float PreserveTemperature = 255.15f;
        public const float RotTemperature = 277.15f;
        public const float SpoilTime = 4800f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Kakawa_Acorn", Crop_KakawaAcorn.Name, Crop_KakawaAcorn.Description, 1f, false, Assets.GetAnim((HashedString)"crop_kakawaacorn_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), new EdiblesManager.FoodInfo("Kakawa_Acorn", "", 0.0f, -1, 255.15f, 277.15f, 4800f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
