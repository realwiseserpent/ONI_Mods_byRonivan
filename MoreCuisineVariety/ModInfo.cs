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
        public static bool IsFragrantFlowersEnabled { get; private set; }
        public static string Namespace { get; private set; }

        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            Namespace = GetType().Namespace;
            Debug.Log($"{Namespace}: Loaded from: {this.mod.ContentPath}");
            Debug.Log($"{Namespace}: DLL version: {GetType().Assembly.GetName().Version} " +
                        $"supporting game build {this.mod.packagedModInfo.minimumSupportedBuild} (requiredDlc {this.mod.packagedModInfo.requiredDlcIds}) (forbiddenDlc {this.mod.packagedModInfo.forbiddenDlcIds})");

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

        public override void OnAllModsLoaded(Harmony harmony, IReadOnlyList<Mod> mods)
        {
            base.OnAllModsLoaded(harmony, mods);
            //CheckForRelatedMods(mods);
        }

        private void CheckForRelatedMods(IReadOnlyList<Mod> mods)
        {
            //if (Settings.Instance.AutoDetectRelatedMods)
            {
                foreach (Mod mod in mods)
                    if (mod.staticID == "pether-pg.FragrantFlowers")
                    {
                        IsFragrantFlowersEnabled = mod.IsActive();
                        string activeString = mod.IsActive() ? "Active" : "NOT Active";
                        Debug.Log($"{Namespace}: Mod Id = \"{mod.staticID}\", Title = \"{mod.title}\", detected to be {activeString}.");
                    }
            }
        }
    }
}