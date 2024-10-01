using Database;
using HarmonyLib;
using Mono.Cecil;
using System.Collections.Generic;
using System;
using DupesCuisine.Foods;
using UnityEngine;
using static EdiblesManager;
using System.Linq;

namespace DupesCuisine.Patches
{
    public class DupesCuisine_Patches_Food
    {
        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public static class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                RegisterStrings.MakeFoodStrings(Food_BreadedPacu.Id, STRINGS.FOOD.BREADEDPACU.NAME, STRINGS.FOOD.BREADEDPACU.DESC, STRINGS.FOOD.BREADEDPACU.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_CookedMuckroot.Id, STRINGS.FOOD.COOKEDMUCKROOT.NAME, STRINGS.FOOD.COOKEDMUCKROOT.DESC, STRINGS.FOOD.COOKEDMUCKROOT.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_CookedShard.Id, STRINGS.FOOD.COOKEDSHARD.NAME, STRINGS.FOOD.COOKEDSHARD.DESC, STRINGS.FOOD.COOKEDSHARD.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_Cookie.Id, STRINGS.FOOD.COOKIE.NAME, STRINGS.FOOD.COOKIE.DESC, STRINGS.FOOD.COOKIE.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_DuskOmelette.Id, STRINGS.FOOD.DUSKOMELETTE.NAME, STRINGS.FOOD.DUSKOMELETTE.DESC, STRINGS.FOOD.DUSKOMELETTE.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_FishWrap.Id, STRINGS.FOOD.FISHWRAP.NAME, STRINGS.FOOD.FISHWRAP.DESC, STRINGS.FOOD.FISHWRAP.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_FlatBread.Id, STRINGS.FOOD.FLATBREAD.NAME, STRINGS.FOOD.FLATBREAD.DESC, STRINGS.FOOD.FLATBREAD.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_GrilledCreamtop.Id, STRINGS.FOOD.GRILLEDCREAMTOP.NAME, STRINGS.FOOD.GRILLEDCREAMTOP.DESC, STRINGS.FOOD.GRILLEDCREAMTOP.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_GrilledPlantMeat.Id, STRINGS.FOOD.GRILLEDPLANTMEAT.NAME, STRINGS.FOOD.GRILLEDPLANTMEAT.DESC, STRINGS.FOOD.GRILLEDPLANTMEAT.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_JellyDoughnut.Id, STRINGS.FOOD.JELLYDOUGHNUT.NAME, STRINGS.FOOD.JELLYDOUGHNUT.DESC, STRINGS.FOOD.JELLYDOUGHNUT.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_KakawaBar.Id, STRINGS.FOOD.KAKAWABAR.NAME, STRINGS.FOOD.KAKAWABAR.DESC, STRINGS.FOOD.KAKAWABAR.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_KakawaButter.Id, STRINGS.FOOD.KAKAWABUTTER.NAME, STRINGS.FOOD.KAKAWABUTTER.DESC, STRINGS.FOOD.KAKAWABUTTER.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_LiceWrap.Id, STRINGS.FOOD.LICEWRAP.NAME, STRINGS.FOOD.LICEWRAP.DESC, STRINGS.FOOD.LICEWRAP.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MealBread.Id, STRINGS.FOOD.MEALBREAD.NAME, STRINGS.FOOD.MEALBREAD.DESC, STRINGS.FOOD.MEALBREAD.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MealSlurryConfig.Id, STRINGS.FOOD.MEALSLURRY.NAME, STRINGS.FOOD.MEALSLURRY.DESC, STRINGS.FOOD.MEALSLURRY.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MeatTaco.Id, STRINGS.FOOD.MEATTACO.NAME, STRINGS.FOOD.MEATTACO.DESC, STRINGS.FOOD.MEATTACO.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MeatWrap.Id, STRINGS.FOOD.MEATWRAP.NAME, STRINGS.FOOD.MEATWRAP.DESC, STRINGS.FOOD.MEATWRAP.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MilkBun.Id, STRINGS.FOOD.MILKBUN.NAME, STRINGS.FOOD.MILKBUN.DESC, STRINGS.FOOD.MILKBUN.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_MushroomStew.Id, STRINGS.FOOD.MUSHROOMSTEW.NAME, STRINGS.FOOD.MUSHROOMSTEW.DESC, STRINGS.FOOD.MUSHROOMSTEW.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_NoshMilkConfig.Id, STRINGS.FOOD.NOSHMILK.NAME, STRINGS.FOOD.NOSHMILK.DESC, STRINGS.FOOD.NOSHMILK.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_NoshPudding.Id, STRINGS.FOOD.NOSHPUDDING.NAME, STRINGS.FOOD.NOSHPUDDING.DESC, STRINGS.FOOD.NOSHPUDDING.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_Nutcake.Id, STRINGS.FOOD.NUTCAKE.NAME, STRINGS.FOOD.NUTCAKE.DESC, STRINGS.FOOD.NUTCAKE.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_Nutpie.Id, STRINGS.FOOD.NUTPIE.NAME, STRINGS.FOOD.NUTPIE.DESC, STRINGS.FOOD.NUTPIE.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_PlantBurger.Id, STRINGS.FOOD.PLANTBURGER.NAME, STRINGS.FOOD.PLANTBURGER.DESC, STRINGS.FOOD.PLANTBURGER.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_RoastedKakawa.Id, STRINGS.FOOD.ROASTEDKAKAWA.NAME, STRINGS.FOOD.ROASTEDKAKAWA.DESC, STRINGS.FOOD.ROASTEDKAKAWA.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_SaltedMeat.Id, STRINGS.FOOD.SALTEDMEAT.NAME, STRINGS.FOOD.SALTEDMEAT.DESC, STRINGS.FOOD.SALTEDMEAT.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_SeaTaco.Id, STRINGS.FOOD.SEATACO.NAME, STRINGS.FOOD.SEATACO.DESC, STRINGS.FOOD.SEATACO.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_SpicedOmelette.Id, STRINGS.FOOD.SPICEDOMELETTE.NAME, STRINGS.FOOD.SPICEDOMELETTE.DESC, STRINGS.FOOD.SPICEDOMELETTE.RECIPEDESC);

                RegisterStrings.MakeFoodStrings(Food_CandyPikeapple.Id, STRINGS.FOOD.CANDYPIKEAPPLE.NAME, STRINGS.FOOD.CANDYPIKEAPPLE.DESC, STRINGS.FOOD.CANDYPIKEAPPLE.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_CookedHexalent.Id, STRINGS.FOOD.COOKEDHEXALENT.NAME, STRINGS.FOOD.COOKEDHEXALENT.DESC, STRINGS.FOOD.COOKEDHEXALENT.RECIPEDESC);
                RegisterStrings.MakeFoodStrings(Food_CookedSherberry.Id, STRINGS.FOOD.COOKEDSHERBERRY.NAME, STRINGS.FOOD.COOKEDSHERBERRY.DESC, STRINGS.FOOD.COOKEDSHERBERRY.RECIPEDESC);

                RegisterStrings.MakeDublicantsModifiersStrings(Effects.ChocolateTasteId, STRINGS.EFFECTS.CHOCOLATETASTE.NAME, STRINGS.EFFECTS.CHOCOLATETASTE.TOOLTIP,
                    STRINGS.EFFECTS.CHOCOLATETASTE.CAUSE, STRINGS.EFFECTS.CHOCOLATETASTE.DESCRIPTION);
                RegisterStrings.MakeDublicantsModifiersStrings(Effects.SugarRushId, STRINGS.EFFECTS.SUGARRUSH.NAME, STRINGS.EFFECTS.SUGARRUSH.TOOLTIP,
                    STRINGS.EFFECTS.SUGARRUSH.CAUSE, STRINGS.EFFECTS.SUGARRUSH.DESCRIPTION);
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public static class Db_Initialize_Patch
        {
            public static void Postfix()
            {
                Db.Get().effects.Add(Effects.ChocolateTasteEffect());
                Db.Get().effects.Add(Effects.SugarRushEffect());
            }
        }

        [HarmonyPatch(typeof(EatXCaloriesFromY))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] {
            typeof(int),
            typeof(List<string>)})]
        public static class EatXCaloriesFromY_Constructor_Patch
        {
            public static void Prefix(ref List<string> fromFoodType)
            {
                fromFoodType.Add(Food_BreadedPacu.Id);
                fromFoodType.Add(Food_FishWrap.Id);
                fromFoodType.Add(Food_MeatTaco.Id);
                fromFoodType.Add(Food_MeatWrap.Id);
                fromFoodType.Add(Food_SaltedMeat.Id);
                fromFoodType.Add(Food_SeaTaco.Id);
            }
        }

        [HarmonyPatch(typeof(FoodInfo))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] {
            typeof(string),
            typeof(string),
            typeof(float),
            typeof(int),
            typeof(float),
            typeof(float),
            typeof(float),
            typeof(bool),
        })]
        public static class FoodInfo_Constructor_Patch
        {
            private static void Postfix(FoodInfo __instance)
            {
                string[] sweets = new string[] { "WormSuperFood", "SpinosaCake", "SpinosaSyrup", "Duskbun", "Duskjam", "CandyPikeapple" };
                if (sweets.Contains(__instance.Id))
                    __instance.Effects.Add(Effects.SugarRushId);
                //else if (__instance.Id == "Salsa" && !__instance.Effects.Contains("WarmTouchFood"))
                //    __instance.Effects.Add("WarmTouchFood");
            }
        }

        //[HarmonyPatch(typeof(ManualGeneratorConfig), "CreateBuildingDef")]
        //public static class ManualGeneratorConfig_CreateBuildingDef
        //{
        //    private static void Postfix(BuildingDef __result)
        //    {
        //        __result.GeneratorWattageRating = 50000f;
        //        __result.GeneratorBaseCapacity = 50000f;
        //    }
        //}

        //[HarmonyPatch(typeof(MineralDeoxidizerConfig))]
        //[HarmonyPatch("DoPostConfigureComplete")]
        //public static class MineralDeoxidizerConfig_ConfigureBuildingTemplate_Patch
        //{
        //    public static void Postfix(GameObject go)
        //    {
        //        var elementConverter = go.GetComponent<ElementConverter>();
        //        elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
        //        {
        //            new ElementConverter.ConsumedElement(SimHashes.Snow.CreateTag(), 0.001f)
        //        };
        //        elementConverter.outputElements = new ElementConverter.OutputElement[1]
        //        {
        //            new ElementConverter.OutputElement(2f, SimHashes.Oxygen, 293.15f)//, outputElementOffsetx: (float) cellOffset.x, outputElementOffsety: (float) cellOffset.y)
        //        };

        //        ManualDeliveryKG manualDeliveryKg = go.GetComponent<ManualDeliveryKG>();
        //        manualDeliveryKg.RequestedItemTag = SimHashes.Snow.CreateTag();


        //        ComplexRecipe.RecipeElement[] recipeElement1 = new ComplexRecipe.RecipeElement[]
        //        {
        //            new ComplexRecipe.RecipeElement(SimHashes.Snow.CreateTag(), 0.001f),
        //        };
        //        ComplexRecipe.RecipeElement[] recipeElement2 = new ComplexRecipe.RecipeElement[1]
        //        {
        //            new ComplexRecipe.RecipeElement(CookedMeatConfig.ID, 20f)
        //        };
        //        var ecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElement1, recipeElement2), recipeElement1, recipeElement2, 0)
        //        {
        //            time = 1f,
        //            description = STRINGS.FOOD.MEATTACO.RECIPEDESC,
        //            nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
        //            fabricators = new List<Tag>() { CookingStationConfig.ID },
        //            sortOrder = 3
        //        };
        //    }
        //}
    }
}
