using ProcGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dupes_Cuisine
{
    public class CuisinePlantsTuning
    {
        public static bool DebugMode = false;
        public static string[] SupportedVersions = DlcManager.AVAILABLE_ALL_VERSIONS;
        public static CuisinePlantsTuning.CropsTuning OakTreeTuning;
        public static CuisinePlantsTuning.CropsTuning CreamcapTuning;
        public static CuisinePlantsTuning.CropsTuning SunnyWheatTuning;

        static CuisinePlantsTuning()
        {
            CuisinePlantsTuning.CropsTuning cropsTuning1 = new CuisinePlantsTuning.CropsTuning()
            {
                density = new ProcGen.MinMax(0.08f, 0.14f)
            };
            cropsTuning1.biomeTemperatures = (ISet<ProcGen.Temperature.Range>)new HashSet<ProcGen.Temperature.Range>()
            {
                ProcGen.Temperature.Range.Cool,
                ProcGen.Temperature.Range.Mild,
                ProcGen.Temperature.Range.Room,
                ProcGen.Temperature.Range.HumanWarm,
                ProcGen.Temperature.Range.HumanHot
            };
            cropsTuning1.biomes = (ISet<string>)new HashSet<string>()
            {
                CuisinePlantsTuning.BIOMES_STRINGS.FOREST
            };
            cropsTuning1.spawnLocation = Mob.Location.Floor;
            CuisinePlantsTuning.OakTreeTuning = cropsTuning1;
            CuisinePlantsTuning.CropsTuning cropsTuning2 = new CuisinePlantsTuning.CropsTuning()
            {
                density = new ProcGen.MinMax(0.08f, 0.14f)
            };
            cropsTuning2.biomeTemperatures = (ISet<ProcGen.Temperature.Range>)new HashSet<ProcGen.Temperature.Range>()
            {
                ProcGen.Temperature.Range.Cool,
                ProcGen.Temperature.Range.Mild,
                ProcGen.Temperature.Range.Room,
                ProcGen.Temperature.Range.HumanWarm,
                ProcGen.Temperature.Range.HumanHot
            };
            cropsTuning2.biomes = (ISet<string>)new HashSet<string>()
            {
                CuisinePlantsTuning.BIOMES_STRINGS.MARSH,
                CuisinePlantsTuning.BIOMES_STRINGS.SWAMP
            };
            cropsTuning2.spawnLocation = Mob.Location.Floor;
            CuisinePlantsTuning.CreamcapTuning = cropsTuning2;
            CuisinePlantsTuning.CropsTuning cropsTuning3 = new CuisinePlantsTuning.CropsTuning()
            {
                density = new ProcGen.MinMax(0.08f, 0.14f)
            };
            cropsTuning3.biomeTemperatures = (ISet<ProcGen.Temperature.Range>)new HashSet<ProcGen.Temperature.Range>()
            {
                ProcGen.Temperature.Range.Cool,
                ProcGen.Temperature.Range.Mild,
                ProcGen.Temperature.Range.Room,
                ProcGen.Temperature.Range.HumanWarm,
                ProcGen.Temperature.Range.HumanHot
            };
            cropsTuning3.biomes = (ISet<string>)new HashSet<string>()
            {
                CuisinePlantsTuning.BIOMES_STRINGS.JUNGLE,
                CuisinePlantsTuning.BIOMES_STRINGS.WASTELAND
            };
            cropsTuning3.spawnLocation = Mob.Location.Floor;
            CuisinePlantsTuning.SunnyWheatTuning = cropsTuning3;
        }

        public class BIOMES_STRINGS
        {
            public static string PREFIX = "biomes/";
            public static string BARREN = "Barren";
            public static string DEFAULT = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Default";
            public static string FOREST = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Forest";
            public static string FROZEN = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Frozen";
            public static string MARSH = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "HotMarsh";
            public static string JUNGLE = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Jungle";
            public static string MAGMA = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Magma";
            public static string MISC = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Misc";
            public static string EMPTY = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Misc/Empty";
            public static string OCEAN = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Ocean";
            public static string OIL = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Oil";
            public static string RUST = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Rust";
            public static string SEDIMENTARY = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Sedimentary";
            public static string AQUATIC = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Aquatic";
            public static string METALLIC = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Metallic";
            public static string MOO = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Moo";
            public static string NIOBIUM = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Niobium";
            public static string RADIOACTIVE = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Radioactive";
            public static string SWAMP = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Swamp";
            public static string WASTELAND = CuisinePlantsTuning.BIOMES_STRINGS.PREFIX + "Wasteland";
        }

        public struct CropsTuning
        {
            public ProcGen.MinMax density;
            public ISet<ProcGen.Temperature.Range> biomeTemperatures;
            public ISet<string> biomes;
            public ISet<string> biomesExcluded;
            public Mob.Location spawnLocation;

            public bool ValidBiome(SubWorld subworld, string biome)
            {
                return this.biomeTemperatures.Contains(subworld.temperatureRange) && (this.biomesExcluded == null || !this.biomesExcluded.Any<string>((Func<string, bool>)(b => biome.Contains(b)))) && this.biomes.Any<string>((Func<string, bool>)(b => biome.Contains(b)));
            }
        }
    }
}
