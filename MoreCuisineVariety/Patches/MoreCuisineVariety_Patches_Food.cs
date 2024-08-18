using Database;
using Dupes_Cuisine.Food;
using HarmonyLib;
using System.Collections.Generic;
using System;

namespace MoreCuisineVariety
{
    public class MoreCuisineVariety_Patches_Food
    {
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
        ////[HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        //public class EntityConfigManager_LoadGeneratedEntities_Patch
        //{
        //    private static void Prefix()
        //    {
        //        //===> NOSH MILK <=================================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_NoshMilkConfig.Id.ToUpperInvariant()}.NAME", Food_NoshMilkConfig.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_NoshMilkConfig.Id.ToUpperInvariant()}.DESC", Food_NoshMilkConfig.Description);

        //        //===> MEAL SLURRY <===============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MealSlurryConfig.Id.ToUpperInvariant()}.NAME", Food_MealSlurryConfig.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MealSlurryConfig.Id.ToUpperInvariant()}.DESC", Food_MealSlurryConfig.Description);

        //        //===> BREADED PACU <==============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_BreadedPacu.Id.ToUpperInvariant()}.NAME", Food_BreadedPacu.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_BreadedPacu.Id.ToUpperInvariant()}.DESC", Food_BreadedPacu.Description);

        //        //===> COOKED MUCKROOT <===========================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_CookedMuckroot.Id.ToUpperInvariant()}.NAME", Food_CookedMuckroot.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_CookedMuckroot.Id.ToUpperInvariant()}.DESC", Food_CookedMuckroot.Description);

        //        //===> COOKED CHARD <==============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_CookedShard.Id.ToUpperInvariant()}.NAME", Food_CookedShard.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_CookedShard.Id.ToUpperInvariant()}.DESC", Food_CookedShard.Description);

        //        //===> GRILLED PLANT MEAT <========================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_GrilledPlantMeat.Id.ToUpperInvariant()}.NAME", Food_GrilledPlantMeat.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_GrilledPlantMeat.Id.ToUpperInvariant()}.DESC", Food_GrilledPlantMeat.Description);

        //        //===> MEALBROT <==================================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MealBread.Id.ToUpperInvariant()}.NAME", Food_MealBread.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MealBread.Id.ToUpperInvariant()}.DESC", Food_MealBread.Description);

        //        //===> MILK BUN <==================================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MilkBun.Id.ToUpperInvariant()}.NAME", Food_MilkBun.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_MilkBun.Id.ToUpperInvariant()}.DESC", Food_MilkBun.Description);

        //        //===> NOSH PUDDING <==============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_NoshPudding.Id.ToUpperInvariant()}.NAME", Food_NoshPudding.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_NoshPudding.Id.ToUpperInvariant()}.DESC", Food_NoshPudding.Description);

        //        //===> NUTPIE <====================================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_Nutpie.Id.ToUpperInvariant()}.NAME", Food_Nutpie.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_Nutpie.Id.ToUpperInvariant()}.DESC", Food_Nutpie.Description);

        //        //===> JELLY DOUGHNUT <============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_JellyDoughnut.Id.ToUpperInvariant()}.NAME", Food_JellyDoughnut.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_JellyDoughnut.Id.ToUpperInvariant()}.DESC", Food_JellyDoughnut.Description);

        //        //===> PLANT BURGER <==============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_PlantBurger.Id.ToUpperInvariant()}.NAME", Food_PlantBurger.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_PlantBurger.Id.ToUpperInvariant()}.DESC", Food_PlantBurger.Description);

        //        //===> SALT-CURED MEAT <===========================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_SaltedMeat.Id.ToUpperInvariant()}.NAME", Food_SaltedMeat.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_SaltedMeat.Id.ToUpperInvariant()}.DESC", Food_SaltedMeat.Description);

        //        //===> SPICED OMELETTE <===========================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_SpicedOmelette.Id.ToUpperInvariant()}.NAME", Food_SpicedOmelette.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_SpicedOmelette.Id.ToUpperInvariant()}.DESC", Food_SpicedOmelette.Description);

        //        //===> DUSK OMELETTE <=============================================================================================================================
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_DuskOmelette.Id.ToUpperInvariant()}.NAME", Food_DuskOmelette.Name);
        //        Strings.Add($"STRINGS.ITEMS.FOOD.{Food_DuskOmelette.Id.ToUpperInvariant()}.DESC", Food_DuskOmelette.Description);
        //    }
        //}
    }
}
