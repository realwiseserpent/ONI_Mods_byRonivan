using HarmonyLib;
using KMod;
using System.Collections.Generic;

namespace Dupes_Cuisine
{
    class ModInfo : KMod.UserMod2
    {
        public static string Namespace { get; private set; }

        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            Dictionary<string, CuisinePlantsTuning.CropsTuning> dictionary1 = new Dictionary<string, CuisinePlantsTuning.CropsTuning>();
            dictionary1.Add("KakawaTree", CuisinePlantsTuning.OakTreeTuning);
            dictionary1.Add("Creamcap", CuisinePlantsTuning.CreamcapTuning);
            dictionary1.Add("SunnyWheat", CuisinePlantsTuning.SunnyWheatTuning);
            Dupes_Cuisine_Patches.CropsDictionary = dictionary1;

            //Manager.Dialog(title: "Warning!", text: $"{this.mod.title}:\n This mod will be removed from Steam soon. Please visit mod page on Steam Workshop for more info.");

            Namespace = GetType().Namespace;
            Debug.Log($"{Namespace}: Loaded from: {this.mod.ContentPath}");
            Debug.Log($"{Namespace}: DLL version: {GetType().Assembly.GetName().Version} " +
                        $"supporting game build {this.mod.packagedModInfo.minimumSupportedBuild} ({this.mod.packagedModInfo.supportedContent})");
        }
    }
}