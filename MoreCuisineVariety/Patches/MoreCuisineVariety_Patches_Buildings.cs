using HarmonyLib;
using DupesCuisine.Buildings;

namespace DupesCuisine.Patches
{
    public class Grinder_Patches
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        public class ManualJuicerTechMod
        {
            public static void Postfix()
            {
                Tech tech1 = Db.Get().Techs.TryGet("FoodRepurposing");
                if (tech1 != null)
                    tech1.unlockedItemIDs.Add(ManualJuicerConfig.ID);
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings))]
        [HarmonyPatch(nameof(GeneratedBuildings.LoadGeneratedBuildings))]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                RegisterStrings.MakeBuildingStrings(ManualJuicerConfig.ID,
                        STRINGS.BUILDINGS.MANUALJUICER.NAME,
                        STRINGS.BUILDINGS.MANUALJUICER.DESC,
                        STRINGS.BUILDINGS.MANUALJUICER.EFFECT);

                ModUtil.AddBuildingToPlanScreen(new HashedString("Food"), ManualJuicerConfig.ID, "cooking");
            }
        }
    }
}
