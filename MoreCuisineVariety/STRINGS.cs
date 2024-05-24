using STRINGS;
using DupesCuisine.Buildings;
using DupesCuisine.Crops;
using DupesCuisine.Plants;
using DupesCuisine.Foods;

namespace DupesCuisine
{
    class STRINGS
    {
        public class BUILDINGS
        {
            public class MANUALJUICER
            {
                public static LocString NAME = UI.FormatAsLink("Food Grinder", ManualJuicerConfig.ID);
                public static LocString DESC = $"A cooking appliance used to grind down Food in to liquids.";
                public static LocString EFFECT = "The grinder uses a mixture of " + UI.FormatAsLink("Water", "WATER") + " and other " + UI.FormatAsLink("Food","FOOD")+ " to make special ingredients used in culinary.\n\nDuplicants will not fabricate items unless recipes queued.";
            }
        }
        public class FOOD
        {
            public class BREADEDPACU
            {
                public static LocString NAME = UI.FormatAsLink("Battered Pacu", Food_BreadedPacu.Id.ToUpper());
                public static LocString DESC = "A crispy " + UI.FormatAsLink("Battered Pacu", Food_BreadedPacu.Id) + " made with " + UI.FormatAsLink("Cooked Seafood", CookedFishConfig.ID) + " and " + UI.FormatAsLink("Meal Lice Batter", Food_MealSlurryConfig.Id) + ". Gives off cruchy noises as one eats them.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Battered Pacu", Food_BreadedPacu.Id);
            }
            public class COOKEDMUCKROOT
            {
                public static LocString NAME = UI.FormatAsLink("Baked Muckroot", Food_CookedMuckroot.Id.ToUpper());
                public static LocString DESC = "The highlight point of a " + UI.FormatAsLink("Muckroot", "BASICFORAGEPLANT") + ", or at least as far as it can get through cooking. The baking process renders it aftertaste less bland.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Muckroot", Food_CookedMuckroot.Id);
            }
            public class COOKEDSHARD
            {
                public static LocString NAME = UI.FormatAsLink("Baked Chard", Food_CookedShard.Id.ToUpper());
                public static LocString DESC = "A baked " + UI.FormatAsLink("Swamp Chard Heart", "SWAMPFORAGEPLANT") + ". It don't taste as bad as it looks, but it does smell as bad as it taste.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Baked Chard", Food_CookedShard.Id);
            }
            public class COOKIE
            {
                public static LocString NAME = UI.FormatAsLink("Frost Cookie", Food_Cookie.Id.ToUpper());
                public static LocString DESC = "A buttery cookie with a subtle bittersweet, cold flavor.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Frost Cookie", Food_Cookie.Id) + ".";
            }
            public class DUSKOMELETTE
            {
                public static LocString NAME = UI.FormatAsLink("Dusk Omelette", Food_DuskOmelette.Id.ToUpper());
                public static LocString DESC = "A fluffy dish made from beaten " + UI.FormatAsLink("Eggs", "RAWEGG") + " and folded over nice " + UI.FormatAsLink("Fried Mushroom", FriedMushroomConfig.ID) + ". The savory flavors of the mushroons get along well with the omelette soft texture.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Dusk Omelette", Food_DuskOmelette.Id);
            }
            public class FISHWRAP
            {
                public static LocString NAME = UI.FormatAsLink("Pacu Wrap", Food_FishWrap.Id.ToUpper());
                public static LocString DESC = "A tasty snack made by wrapping " + UI.FormatAsLink("Cooked Seafood", CookedFishConfig.ID) + " with " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ". Each bite leaves a mild warm sensation in one's mouth, even when the snack itself is served cold.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Pacu Wrap", Food_FishWrap.Id);
            }
            public class FLATBREAD
            {
                public static LocString NAME = UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id.ToUpper());
                public static LocString DESC = "A simple flat bread baked from " + UI.FormatAsLink("Sunny Wheat Grain", Crop_SunnyWheatGrain.Id) + ". Each bite leaves a mild warmth sensation in one's mouth, even when the bread itself is cold.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ".";
            }
            public class GRILLEDCREAMTOP
            {
                public static LocString NAME = UI.FormatAsLink("Grilled Creamcap", Food_GrilledCreamtop.Id.ToUpper());
                public static LocString DESC = "The grilled fruiting of a " + UI.FormatAsLink(Plant_CreamcapMushroomConfig.Id, Crop_Creamcap.Id) + ". It has a crispy texture and a soft, mildly sweet, earthy flavor.";
                public static LocString RECIPEDESC = DESC; //"Grills a " + UI.FormatAsLink("Creamtop Cap", Crop_Creamcap.Id) + ".";
            }
            public class GRILLEDPLANTMEAT
            {
                public static LocString NAME = UI.FormatAsLink("Grilled Plant Meat", Food_GrilledPlantMeat.Id.ToUpper());
                public static LocString DESC = "A delightful grilled " + UI.FormatAsLink("Plant Meat", "PLANTMEAT") + ". It don't taste like meat, nor it taste like plant, but it really does taste good.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Grilled Plant Meat", Food_GrilledPlantMeat.Id);
            }
            public class JELLYDOUGHNUT
            {
                public static LocString NAME = UI.FormatAsLink("Jelly Doughnut", Food_JellyDoughnut.Id.ToUpper());
                public static LocString DESC = "A leavened fried dough prepared from " + UI.FormatAsLink("Meal Lice Batter", Food_MealSlurryConfig.Id) + ". The interior is filled a hearty portion of dried " + UI.FormatAsLink("Bog Jelly", "SWAMPFRUIT") + ".";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Jelly Doughnut", Food_JellyDoughnut.Id);
            }
            public class KAKAWABAR
            {
                public static LocString NAME = UI.FormatAsLink("Kakawa Bar", Food_KakawaBar.Id.ToUpper());
                public static LocString DESC = UI.FormatAsLink("Roasted Kakawa", Food_RoastedKakawa.Id) + " compressed to a dense, buttery mass. Further cooking remove most of Kakawa bitterness, rendering this bar incredible tasty.";
                public static LocString RECIPEDESC = DESC; //"Compress a " + UI.FormatAsLink("kakawa Bar", Food_KakawaBar.Id);
            }
            public class KAKAWABUTTER
            {
                public static LocString NAME = UI.FormatAsLink("Kakawa Butter", Food_KakawaButter.Id.ToUpper());
                public static LocString DESC = "An oily butter extracted from " + UI.FormatAsLink("Kakawa Acorn",Crop_KakawaAcorn.Id) + ". This butter has a tasty aroma, although one must like bitterness to actually eat it in this form.";
                public static LocString RECIPEDESC = DESC; //"Extract oil from " + UI.FormatAsLink("Kakawa Acorn",Crop_KakawaAcorn.Id) + ".";
            }
            public class LICEWRAP
            {
                public static LocString NAME = UI.FormatAsLink("Lice Wrap", Food_LiceWrap.Id.ToUpper());
                public static LocString DESC = "A dubious snack made by wrapping fresh " + UI.FormatAsLink("Meal Lice", "BasicPlantFood") + " with " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ". The warm flavor from the bread mitigates regretable texture of filling.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Lice Wrap", Food_LiceWrap.Id);
            }
            public class MEALBREAD
            {
                public static LocString NAME = UI.FormatAsLink("Mealbrot", Food_MealBread.Id.ToUpper());
                public static LocString DESC = "A loaf of " + UI.FormatAsLink("Bread", Food_MealBread.Id) + " baked from a mixture of " + UI.FormatAsLink("Meal Batter", Food_MealSlurryConfig.Id) + ", " + UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id) + " and " + UI.FormatAsLink("Eggs", "RAWEGG") + ". Despite its hard crust, this bread is actually tasty, and has a long shelf life.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Mealbrot", Food_MealBread.Id);
            }
            public class MEALSLURRY
            {
                public static LocString NAME = UI.FormatAsLink("Meal Batter", Food_MealSlurryConfig.Id.ToUpper());
                public static LocString DESC = "A fearsome sticky slurry made from " + UI.FormatAsLink("Meal Lice", "BasicPlantFood") + ". Used as a basic ingredient in many recipes.";
                public static LocString RECIPEDESC = DESC; //"Grind down " + UI.FormatAsLink("Meal Lice", "BASICPLANTFOOD") + " to a pulp, and produce sticky Meal Batter.";
            }
            public class MEATTACO
            {
                public static LocString NAME = UI.FormatAsLink("Meat Taco", Food_MeatTaco.Id.ToUpper());
                public static LocString DESC = "A filling meal made with slowly " + UI.FormatAsLink("Grilled Meat", "CookedMeat") + " with " + UI.FormatAsLink("Omellete", "CookedEgg") + ", all served within a " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ". It promptly leaves a warm sensation while it goes inside, as well when it leaves.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Meat Taco", Food_MeatTaco.Id);
            }
            public class MEATWRAP
            {
                public static LocString NAME = UI.FormatAsLink("Meat Wrap", Food_MeatWrap.Id.ToUpper());
                public static LocString DESC = "A tasty snack made by wrapping " + UI.FormatAsLink("Grilled Meat", "CookedMeat") + " with " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ". Each bite leaves a mild warm sensation in one's mouth, even when the snack itself is served cold.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Meat Wrap", Food_MeatWrap.Id);
            }
            public class MILKBUN
            {
                public static LocString NAME = UI.FormatAsLink("Milk Bun", Food_MilkBun.Id.ToUpper());
                public static LocString DESC = "A soft bun baked from " + UI.FormatAsLink("Meal Batter", Food_MealSlurryConfig.Id) + ", " + UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id) + " and " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". It gives the duplicants who eats it a happy face, and a quite unhappy face to others who will have to endure the farts.";//+", " + UI.FormatAsLink("Sunny Grains", Crop_SunnyWheatGrain.Id)+ 
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Milk Bun", Food_MealBread.Id);
            }
            public class MUSHROOMSTEW
            {
                public static LocString NAME = UI.FormatAsLink("Mushroom Stew", Food_MushroomStew.Id.ToUpper());
                public static LocString DESC = $"A thick, flavorful soup made by simmering {UI.FormatAsLink("mushrooms", Food_GrilledCreamtop.Id)} and {UI.FormatAsLink("spices", SpiceNutConfig.ID)}, placed within a hallowed {UI.FormatAsLink("Frost Bun", ColdWheatBreadConfig.ID)} and baked in a oven.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Mushroom Stew", Food_MushroomStew.Id) + ".";
            }
            public class NOSHMILK
            {
                public static LocString NAME = UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id.ToUpper());
                public static LocString DESC = "A plant-based drink produced by soaking and pressing of " + UI.FormatAsLink("Nosh Bean", "BEAN") + ".";
                public static LocString RECIPEDESC = DESC; //"Grind down " + UI.FormatAsLink("Nosh Beans", "BEAN") + " to a pulp, and produce fresh Nosh Milk.";
            }
            public class NOSHPUDDING
            {
                public static LocString NAME = UI.FormatAsLink("Nosh Custard Flan", Food_NoshPudding.Id.ToUpper());
                public static LocString DESC = "A fancy sweet dessert made with " + UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id) + ", " + UI.FormatAsLink("Sleet Wheat Grain", "ColdWheatSeed") + ", whisked " + UI.FormatAsLink("Eggs", "RAWEGG") + " and quite a lot of " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". Has a fine rimmed pastry that prevents it from breaking apart as one holds it (for a short time).";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Nosh Custard Flan", Food_NoshPudding.Id);
            }
            public class NUTCAKE
            {
                public static LocString NAME = UI.FormatAsLink("Nutcake", Food_Nutcake.Id.ToUpper());
                public static LocString DESC = $"A saborous {UI.FormatAsLink("Nutcake", Food_Nutcake.Id)} baked from bitter { UI.FormatAsLink("Roasted Kakawa", Food_RoastedKakawa.Id.ToUpper())}"
                    + $", {UI.FormatAsLink("Kakawa Butter", Food_KakawaButter.Id.ToUpper())} and { UI.FormatAsLink("Sunny Grains", Crop_SunnyWheatGrain.Id)}. Brings warmth to the heart (and stomach).";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Nutcake", Food_Nutcake.Id) + " .";
            }
            public class NUTPIE
            {
                public static LocString NAME = UI.FormatAsLink("Grubner Nusstorte", Food_Nutpie.Id.ToUpper());
                public static LocString DESC = "A gourmet pie with a nut filling of caramelised " + UI.FormatAsLink("Roast Grubfruit Nuts", "WORMBASICFOOD") + ", " + UI.FormatAsLink("Sleet Wheat Grain", "COLDWHEATSEED") + " and " + UI.FormatAsLink("Eggs", "RAWEGG") + " dough, and " + UI.FormatAsLink("Sucrose", "SUCROSE") + ". The buttery crust remains fresh for a long time.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Grubner Nusstorte", Food_Nutpie.Id);
            }
            public class PLANTBURGER
            {
                public static LocString NAME = UI.FormatAsLink("Plant Burger", Food_PlantBurger.Id.ToUpper());
                public static LocString DESC = "Tasty " + UI.FormatAsLink("Grilled Plant Meat", Food_GrilledPlantMeat.Id) + " and " + UI.FormatAsLink("Lettuce", "LETTUCE") + " pressed together inside a split " + UI.FormatAsLink("Mealbrot", Food_MealBread.Id) + ". Can cause shivers and shakes after consumption.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Plant Burger", Food_PlantBurger.Id);
            }
            public class ROASTEDKAKAWA
            {
                public static LocString NAME = UI.FormatAsLink("Roasted Kakawa", Food_RoastedKakawa.Id.ToUpper());
                public static LocString DESC = "A fully roasted " + UI.FormatAsLink("Kakawa Acorn",Crop_KakawaAcorn.Id) + ". The roasting crack open its hard shell reaveling a edible nut, although the eating may be a bitter experience.";
                public static LocString RECIPEDESC = DESC; //"Roast a " + UI.FormatAsLink("Kakawa Acorn",Crop_KakawaAcorn.Id) + ".";
            }
            public class SALTEDMEAT
            {
                public static LocString NAME = UI.FormatAsLink("Salt-cured Meat", Food_SaltedMeat.Id.ToUpper());
                public static LocString DESC = "A shunk of " + UI.FormatAsLink("Meat", "MEAT") + " dried with a lot of " + UI.FormatAsLink("Salt", "SALT") + ". The large amount of salt present in this meat made it completely resistant to microorganisms that would spoil it under normal conditions.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Salt-cured Meat", Food_SaltedMeat.Id);
            }
            public class SEATACO
            {
                public static LocString NAME = UI.FormatAsLink("Sea Taco", Food_SeaTaco.Id.ToUpper());
                public static LocString DESC = "A filling meal made with slowly " + UI.FormatAsLink("Cooked Seafood", CookedFishConfig.ID) + " with " + UI.FormatAsLink("Lettuce", "Lettuce") + ", and a pinch of " + UI.FormatAsLink("Pepper Nut", SpiceNutConfig.ID) + ", all served with a " + UI.FormatAsLink("Warm Flat Bread", Food_FlatBread.Id) + ". It promptly leaves a warm sensation while it goes inside, as well when it leaves.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Sea Taco", Food_SeaTaco.Id);
            }
            public class SPICEDOMELETTE
            {
                public static LocString NAME = UI.FormatAsLink("Spiced Omelette", Food_SpicedOmelette.Id.ToUpper());
                public static LocString DESC = "A fluffy dish made from beaten " + UI.FormatAsLink("Eggs", "RAWEGG") + " and served with generous pinch of " + UI.FormatAsLink("Pincha Peppernut", "SPICENUT") + ". Has a deep spiced flavour that sticks to the mouth.";
                public static LocString RECIPEDESC = DESC; //"Bake a " + UI.FormatAsLink("Spiced Omelette", Food_SpicedOmelette.Id);
            }
        }
        public class SEEDS
        {
            public class CREAMCAPMUSHROOM
            {
                public static LocString SEED_NAME = UI.FormatAsLink("Creamcap Mushroom Spore", Plant_CreamcapMushroomConfig.Id);
                public static LocString SEED_DESC = $"The small {UI.FormatAsLink("Spore", "PLANTS")} from a { UI.FormatAsLink("Creamcap Mushroom", Plant_CreamcapMushroomConfig.Id)}. Plant it in a dark place and its surely to flourish.";
            }
            public class KAKAWATREE
            {
                public static LocString SEED_NAME = UI.FormatAsLink("Kakawa Acorn", Plant_KakawaTreeConfig.Id);//UI.FormatAsLink("Kakawa Tree Sprout", Plant_KakawaTreeConfig.Id);
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("Sprout", "PLANTS")} of a { UI.FormatAsLink("Kakawa Tree", Plant_KakawaTreeConfig.Id)}.";
            }
            public class SUNNYWHEAT
            {
                public static LocString SEED_NAME = UI.FormatAsLink("Sunny Wheat Grain", Plant_SunnyWheatConfig.Id); //UI.FormatAsLink("Sunny Wheat Seed", Plant_SunnyWheatConfig.Id);
                public static LocString SEED_DESC = $"The {UI.FormatAsLink("Seed", "PLANTS")} of a { UI.FormatAsLink("Sunny Wheat", Plant_SunnyWheatConfig.Id)} plant.";
            }
        }
        public class PLANTS
        {
            public class CREAMCAPMUSHROOM
            {
                public static LocString NAME = UI.FormatAsLink("Creamcap Mushroom", Plant_CreamcapMushroomConfig.Id);
                public static LocString DESC = $"A soft white mushroom with a creamie texture on its cap. Despite growing in filthy dark spots, it has edible {UI.FormatAsLink("cream cap", Crop_Creamcap.Id)}.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class KAKAWATREE
            {
                public static LocString NAME = UI.FormatAsLink("Kakawa Tree", Plant_KakawaTreeConfig.Id);
                public static LocString DESC = $"A lush, golden leafed tree that grows in temperate forest biomes. It produces a rock hard edible {UI.FormatAsLink("Kakawa Acorn", Crop_KakawaAcorn.Id)}.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
            public class SUNNYWHEAT
            {
                public static LocString NAME = UI.FormatAsLink("Sunny Wheat", Plant_SunnyWheatConfig.Id);
                public static LocString DESC = $"A vibrant wheat that grows in temperate and hot biomes. It produces {UI.FormatAsLink("Sunny Wheat Grain", Crop_SunnyWheatGrain.Id)}, a warm grain that can be processed in to food.";
                public static LocString DOMESTICATED_DESC = DESC;
            }
        }
        public class CROPS
        {
            public static LocString RECIPEDESC = "Science works in mysterious ways.";
            public class KAKAWAACORN
            {
                public static LocString NAME = UI.FormatAsLink("Kakawa Acorn", Crop_KakawaAcorn.Id.ToUpper());
                public static LocString DESC = "The fruits of a " + UI.FormatAsLink("Kakawa Tree", Plant_KakawaTreeConfig.Id) + ". Differently from other nuts, this one is so hard that can't be eat raw. The edible inside is also very bitter.";
            }
            public class SUNNYWHEATGRAIN
            {
                public static LocString NAME = UI.FormatAsLink("Sunny Wheat Grain", Crop_SunnyWheatGrain.Id.ToUpper());
                public static LocString DESC = "The edible grain of a " + UI.FormatAsLink("Sunny Wheat", Plant_SunnyWheatConfig.Id) + ". This edible grain leaves a warm taste on the tongue.";
            }
            public class CREAMCAP
            {
                public static LocString NAME = UI.FormatAsLink(Plant_CreamcapMushroomConfig.Id, Crop_Creamcap.Id.ToUpper());
                public static LocString DESC = "The fruiting body of a " + UI.FormatAsLink("Creamcap Mushroom", Plant_CreamcapMushroomConfig.Id) + ". Has a rich earthy flavor and a pungent, mildly sweet aroma";
            }
        }

        public class EFFECTS
        {
            public class CHOCOLATETASTE
            {
                public static LocString NAME = (LocString)"Chocolate taste";
                public static LocString TOOLTIP = (LocString)"This duplicant just ate some chocolate";
                public static LocString CAUSE = (LocString)"Obtained by eating a kakawa meal";
                public static LocString DESCRIPTION = (LocString)"Duplicants find this kakawa meal tasty";
            }

            public class SUGARRUSH
            {
                public static LocString NAME = (LocString)"Sugar rush";
                public static LocString TOOLTIP = (LocString)"This duplicant just ate some sucrose";
                public static LocString CAUSE = (LocString)"Obtained by eating a sucrose meal";
                public static LocString DESCRIPTION = (LocString)"Duplicants find this sucrose meal energizing";
            }
        }


        public class CODEX
        {
            public static LocString SUBTITLE = "Edible Plant";
            public class CREAMCAPMUSHROOM
            {
                //public static LocString TITLE = (LocString)"Balm Lily Flower";
                //public static LocString SUBTITLE = (LocString)"Medicinal Herb";

                public class BODY
                {
                    public static LocString CONTAINER1 = PLANTS.CREAMCAPMUSHROOM.DESC;
                }
            }
            public class KAKAWATREE
            {
                public class BODY
                {
                    public static LocString CONTAINER1 = PLANTS.KAKAWATREE.DESC;
                }
            }
            public class SUNNYWHEAT
            {
                public class BODY
                {
                    public static LocString CONTAINER1 = PLANTS.SUNNYWHEAT.DESC;
                }
            }
        }


        public class TRANSLATION
        {
            public class AUTHOR
            {
                public static LocString NAME = "Ronivan";
            }
        }
    }
}
