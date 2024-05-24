using HarmonyLib;
using KMod;
using System.Collections.Generic;
using DupesCuisine.Plants;
using DupesCuisine.Patches;
using DupesCuisine.Crops;

namespace DupesCuisine
{
    class ModInfo : KMod.UserMod2
    {
        public static string Namespace { get; private set; }

        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            Namespace = GetType().Namespace;
            Debug.Log($"{Namespace}: Loaded from: {this.mod.ContentPath}");
            Debug.Log($"{Namespace}: DLL version: {GetType().Assembly.GetName().Version} " +
                        $"supporting game build {this.mod.packagedModInfo.minimumSupportedBuild} ({this.mod.packagedModInfo.supportedContent})");

            //PUtil.InitLibrary();
            //new POptions().RegisterOptions(this, typeof(Settings));
            //Settings.PLib_Initalize();

            DupesCuisine_Patches_Plants.CropsDictionary = new Dictionary<string, CuisinePlantsTuning.CropsTuning>
            {
                { Plant_KakawaTreeConfig.Id, CuisinePlantsTuning.OakTreeTuning },
                { Plant_CreamcapMushroomConfig.Id, CuisinePlantsTuning.CreamcapTuning },
                { Plant_SunnyWheatConfig.Id, CuisinePlantsTuning.SunnyWheatTuning }
            };

            DupesCuisine_Patches_Plants.SeedDictionary = new Dictionary<string, CuisinePlantsTuning.SeedTuning>()
                {
                    { Crop_KakawaAcorn.Id, CuisinePlantsTuning.OakTreeSeedTuning },
                    { Plant_CreamcapMushroomConfig.SeedId, CuisinePlantsTuning.CreamcapSeedTuning },
                    { Crop_SunnyWheatGrain.Id, CuisinePlantsTuning.SunnyWheatSeedTuning },
                };
        }
    }
}