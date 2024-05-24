using ProcGen;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DupesCuisine
{
    public class CuisinePlantsTuning
    {
        public static bool DebugMode = false;
        public static string[] SupportedVersions = DlcManager.AVAILABLE_ALL_VERSIONS;

        public static CropsTuning OakTreeTuning = new CropsTuning
        {
            density = new MinMax(0.1f, 0.2f),
            biomeTemperatures = new HashSet<Temperature.Range>()
                {
                    Temperature.Range.Mild,
                    Temperature.Range.Room,
                    Temperature.Range.HumanWarm,
                    Temperature.Range.HumanHot,
                    Temperature.Range.Hot
                },
            biomes = new HashSet<string>()
                {
                    BIOMES_STRINGS.FOREST,
                    BAATOR_BIOME_STRINGS.MINAUROS,
                    BAATOR_BIOME_STRINGS.SHADOWFEL,
                    EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                    EARTH_BIOME_STRINGS.SURFACE,
                    EMPTY_WORLDS_BIOME_STRINGS.CUSTOMFOREST,
                },
            spawnLocation = Mob.Location.Floor
        };

        public static CropsTuning CreamcapTuning = new CropsTuning
        {
            density = new MinMax(0.15f, 0.3f),
            biomeTemperatures = new HashSet<Temperature.Range>()
                {
                    Temperature.Range.Cool,
                    Temperature.Range.Mild,
                    Temperature.Range.Room,
                    Temperature.Range.HumanWarm,
                    Temperature.Range.HumanHot,
                    Temperature.Range.Hot
                },
            biomes = new HashSet<string>()
                {
                    BIOMES_STRINGS.MARSH,
                    BIOMES_STRINGS.SWAMP,
                    BAATOR_BIOME_STRINGS.AVERNUS,
                    BAATOR_BIOME_STRINGS.SHADOWFEL,
                    EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                    EARTH_BIOME_STRINGS.SURFACE,
                },
            spawnLocation = Mob.Location.Floor
        };

        public static CropsTuning SunnyWheatTuning = new CropsTuning
        {
            density = new MinMax(0.25f, 0.3f),
            biomeTemperatures = new HashSet<Temperature.Range>()
                {
                    Temperature.Range.Mild,
                    Temperature.Range.Room,
                    Temperature.Range.HumanWarm,
                    Temperature.Range.HumanHot,
                    Temperature.Range.Hot
                },
            biomes = new HashSet<string>()
                {
                    BIOMES_STRINGS.JUNGLE,
                    BIOMES_STRINGS.WASTELAND,
                    BAATOR_BIOME_STRINGS.NESSUS,
                    BAATOR_BIOME_STRINGS.DIS,
                    "Desert", //SEDIMENTARY desert + TestDesert from RollerSnake
                    EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                    EARTH_BIOME_STRINGS.SURFACE,
                },
            spawnLocation = Mob.Location.Floor
        };

        public class BIOMES_STRINGS
        {
            public static string PREFIX = "biomes/";
            public static string BARREN = "Barren";
            public static string DEFAULT = (PREFIX + "Default");
            public static string FOREST = (PREFIX + "Forest");
            public static string FROZEN = (PREFIX + "Frozen");
            public static string MARSH = (PREFIX + "HotMarsh");
            public static string JUNGLE = (PREFIX + "Jungle");
            public static string MAGMA = (PREFIX + "Magma");
            public static string MISC = (PREFIX + "Misc");
            public static string EMPTY = (PREFIX + "Misc/Empty");
            public static string OCEAN = (PREFIX + "Ocean");
            public static string OIL = (PREFIX + "Oil");
            public static string RUST = (PREFIX + "Rust");
            public static string SEDIMENTARY = (PREFIX + "Sedimentary");
            public static string AQUATIC = (PREFIX + "Aquatic");
            public static string METALLIC = (PREFIX + "Metallic");
            public static string MOO = (PREFIX + "Moo");
            public static string NIOBIUM = (PREFIX + "Niobium");
            public static string RADIOACTIVE = (PREFIX + "Radioactive");
            public static string SWAMP = (PREFIX + "Swamp");
            public static string WASTELAND = (PREFIX + "Wasteland");
        }
        public class EARTH_BIOME_STRINGS //Earth mod
        {
            public static string PREFIX = @"biomes/Earth/";
            public static string
                ASTHENOSPHERE = PREFIX + "Asthenosphere",
                CORE = PREFIX + "Core",
                MANTLE = PREFIX + "Mantle",
                MANTLE2 = PREFIX + "Mantle2",
                OCEAN = PREFIX + "Ocean",
                SKY = PREFIX + "Sky",
                SURFACE = PREFIX + "Surface";
        }
        public class BAATOR_BIOME_STRINGS //Baator mod
        {
            public static string PREFIX = @"biomes/";
            public static string
                SURFACECRAGS = PREFIX + "Baator_SurfaceCrags",
                SHADOWFEL = PREFIX + "Baator_Shadowfel",
                AVERNUS = PREFIX + "Baator_Avernus",
                DIS = PREFIX + "Baator_Dis",
                MINAUROS = PREFIX + "Baator_Minauros",
                PHLEGETHOS = PREFIX + "Baator_Phlegethos",
                STYGIA = PREFIX + "Baator_Stygia",
                MALBOLGE = PREFIX + "Baator_Malbolge",
                MALADOMINI = PREFIX + "Baator_Maladomini",
                CANIA = PREFIX + "Baator_Cania",
                NESSUS = PREFIX + "Baator_Nessus";
        }
        public class EMPTY_WORLDS_BIOME_STRINGS //EmptyWorlds mod
        {
            public static string CUSTOMFOREST = "CustomForest";
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CropsTuning
        {
            public MinMax density;
            public ISet<Temperature.Range> biomeTemperatures;
            public ISet<string> biomes;
            public ISet<string> biomesExcluded;
            public Mob.Location spawnLocation;
            // Check that the subworld temperature and current biome are appropriate for the plant
            public bool ValidBiome(SubWorld subworld, string biome)
            {
                return biomeTemperatures.Contains(subworld.temperatureRange) && (biomesExcluded == null || !biomesExcluded.Any(b => biome.Contains(b))) && biomes.Any(b => biome.Contains(b));
            }
        }

        public struct SeedTuning
        {
            public MinMax density;
            public ISet<string> biomes;
            public ISet<string> biomesExcluded;

            // Check that the subworld temperature and current biome are appropriate for the plant
            public bool ValidBiome(string biome)
            {
                return (biomesExcluded == null || !biomesExcluded.Any(b => biome.Contains(b))) && biomes.Any(b => biome.Contains(b));
            }
        }
        public static SeedTuning OakTreeSeedTuning = new SeedTuning
        {
            density = new MinMax(0.005f, 0.01f),
            biomes = OakTreeTuning.biomes,
            biomesExcluded = new HashSet<string>() { EARTH_BIOME_STRINGS.ASTHENOSPHERE, },
        };
        public static SeedTuning CreamcapSeedTuning = new SeedTuning
        {
            density = new MinMax(0.03f, 0.04f),
            biomes = new HashSet<string>(CreamcapTuning.biomes) { },
            biomesExcluded = new HashSet<string>() {     
                EARTH_BIOME_STRINGS.ASTHENOSPHERE,
                EARTH_BIOME_STRINGS.MANTLE2
            },
        };
        public static SeedTuning SunnyWheatSeedTuning = new SeedTuning
        {
            density = new MinMax(0.005f, 0.01f),
            biomes = SunnyWheatTuning.biomes,
            biomesExcluded = new HashSet<string>() { EARTH_BIOME_STRINGS.SURFACE, },
        };
    }
}

