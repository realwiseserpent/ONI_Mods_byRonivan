using Dupes_Cuisine.Buildings;
using HarmonyLib;

namespace Dupes_Cuisine
{
    public class Grinder_Patches
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class ManualJuicerTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("FoodRepurposing").unlockedItemIDs.Add("ManualJuicer");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class ManualJuicerUI
        {
            private static void Prefix()
            {
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MANUALJUICER.NAME", "Food Grinder");
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MANUALJUICER.DESC", "A cooking appliance used to grind down food in to liquids.");
                Strings.Add("STRINGS.BUILDINGS.PREFABS.MANUALJUICER.EFFECT", ManualJuicerConfig.Effect);
                ModUtil.AddBuildingToPlanScreen((HashedString)"Food", "ManualJuicer");
            }
        }
    }
}
