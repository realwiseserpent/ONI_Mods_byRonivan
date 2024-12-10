using HarmonyLib;
using DupesCuisine.Buildings;
using Klei.AI;
using static STRINGS.ELEMENTS;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using BUILDINGS = STRINGS.BUILDINGS;
using ITEMS = STRINGS.ITEMS;

namespace DupesCuisine.Patches
{
    public class MoreCuisineVariety_Patches_Buildings
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
        //[HarmonyPatch(typeof(VendingMachineConfig), "CreatePrefab")]
        public static class VendingMachineConfig_CreatePrefab
        {
            public static void Postfix(GameObject __result)
            {
                if (__result == null)
                    return;

                __result.AddOrGet<DropAllWorkable>();
                Prioritizable.AddRef(__result);
                __result.AddOrGet<BuildingComplete>().isManuallyOperated = true;
                var fabricator = __result.AddOrGet<CookingStation>();
                fabricator.heatedTemperature = 300.15f;
                __result.AddOrGet<FabricatorIngredientStatusManager>();
                __result.AddOrGet<CopyBuildingSettings>();
                __result.AddOrGet<ComplexFabricatorWorkable>().overrideAnims = new KAnimFile[1]
                {
                Assets.GetAnim((HashedString) "anim_loco_destructive_kanim")
                };
                fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;


                ConfigureRecipes();

                //__result.AddOrGetDef<PoweredController.Def>();
                BuildingTemplates.CreateComplexFabricatorStorage(__result, fabricator);
                //__result.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.CookTop);
            }
            private static void ConfigureRecipes()
            {
                ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Polypropylene.CreateTag(), 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Glass.CreateTag(), 1f)
                };
                ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(FieldRationConfig.ID , 10f)
                };

                ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("VendingMachine", inputs, outputs), inputs, outputs, 0)
                {
                    time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME,
                    description = STRINGS.CROPS.RECIPEDESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag> { "VendingMachine" },
                    sortOrder = 0
                };
            }
        }

        [HarmonyPatch(typeof(Compost), "OnStorageChanged")]
        public static class Compost_OnStorageChanged
        {
            public static void Postfix(Compost __instance, object data)
            {
                if (data == null)
                    return;

                if (!(data is GameObject))
                    Debug.Log($"Compost WTF");

                Compostable temp;
                (data as GameObject).TryGetComponent<Compostable>(out temp);

                if (temp != null && !temp.isMarkedForCompost)
                {
                    Pickupable component = temp.GetComponent<Pickupable>();

                    if (component.storage != null)
                        component.storage.Drop(temp.gameObject, true);

                    EntitySplitter.Split(component, component.TotalAmount, temp.compostPrefab);
                }
            }
        }
        [HarmonyPatch(typeof(CompostConfig), "DoPostConfigureComplete")]
        public static class CompostConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                Storage storage = go.AddOrGet<Storage>();
                storage.showInUI = true;
                storage.showDescriptor = true;
                storage.storageFilters = new List<Tag>()
                {
                    GameTags.Compostable,
                    GameTags.Organics,
                    GameTags.Edible,
                    GameTags.CookingIngredient,
                    GameTags.Seed,
                    GameTags.IndustrialIngredient,
                };

                storage.allowItemRemoval = false;
                storage.allowSettingOnlyFetchMarkedItems = false;

                storage.capacityKg = 300f;

                storage.storageFullMargin = TUNING.STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
                storage.fetchCategory = Storage.FetchCategory.GeneralStorage;

                go.AddOrGet<StorageLocker>();
            }
        }

        [HarmonyPatch(typeof(WaterCoolerConfig), "DoPostConfigureComplete")]
        public static class WaterCoolerConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                RegisterStrings.MakeWaterCoolerElemStrings("SugarWater", SUGARWATER.NAME + "\nA sweet, cloudy liquid");
                RegisterStrings.MakeWaterCoolerElemStrings("Ethanol", ETHANOL.NAME + "\nFlamable liquid with pungent odor");


                WaterCoolerConfig.BEVERAGE_CHOICE_OPTIONS = new List<Tuple<Tag, string>>(WaterCoolerConfig.BEVERAGE_CHOICE_OPTIONS)
                {
                    new Tuple<Tag, string>(SimHashes.SugarWater.CreateTag(), SugarWaterEffectID),
                    new Tuple<Tag, string>(SimHashes.Ethanol.CreateTag(), EthanolEffectID),
                }.ToArray();

                Storage storage = go.AddOrGet<Storage>();
                storage.capacityKg = 20f;
            }
        }

        [HarmonyPatch(typeof(WaterCooler.StatesInstance), "Drink")]
        public static class WaterCooler_Drink_Patch
        {
            public static void Postfix(WaterCooler.StatesInstance __instance, GameObject druplicant, bool triggerOnDrinkCallback = true)
            {
                var _barVariable = typeof(WaterCooler.StatesInstance).GetField("storage", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(__instance);
                Tag tag = null;
                if (_barVariable != null)
                    tag = (_barVariable as Storage).items[0].PrefabID();
                else
                    Debug.Log($"WaterCooler no storage");

                Effects component = druplicant.GetComponent<Effects>();
                if (tag != null && tag == SimHashes.SugarWater.CreateTag())
                    component.Add(SugarWaterEffectID, true);
                else if (tag != null && tag == SimHashes.Ethanol.CreateTag())
                    component.Add(EthanolEffectID, true);
            }
        }

        public const string EthanolEffectID = "DuplicantGotEthanol";

        public static Effect EthanolEffect()
        {
            float time = 600f;
            Effect effect = new Effect(EthanolEffectID, STRINGS.EFFECTS.DUPLICANTGOTETHANOL.NAME, STRINGS.EFFECTS.DUPLICANTGOTETHANOL.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.GermResistance.Id, +0.5f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.ThermalConductivityBarrier.Id, 0.001f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
            };

            if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
            {
                effect.SelfModifiers.Add(new AttributeModifier(Db.Get().Attributes.RadiationRecovery.Id, -1 / 6f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME));
                effect.SelfModifiers.Add(new AttributeModifier(Db.Get().Attributes.RadiationResistance.Id, +0.1f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME));
            }

            //effect.immunityEffectsNames = new string[] { "WetFeet",
            //    //"FrostSickness" 
            //};

            return effect;
        }

        public const string SugarWaterEffectID = "DuplicantGotSugarWater";

        public static Effect SugarWaterEffect()
        {
            float time = 120f;
            Effect effect = new Effect(SugarWaterEffectID, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                //nectar
                new AttributeModifier(Db.Get().Attributes.CarryAmount.Id, 200, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.Athletics.Id, 2, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.Stamina.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),

                //--------------------------------------------------

                //goop?
                new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, 30000 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), 

                //-------------------------------------------------

                //new AttributeModifier(Db.Get().Attributes.ToiletEfficiency.Id, -0.25f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), kinda useless as temporal
                new AttributeModifier(Db.Get().Attributes.Decor.Id, -20, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.DecorExpectation.Id, +10, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),// passive bonus like trait


                new AttributeModifier(Db.Get().Amounts.PowerCharge.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.InternalBattery.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.InternalBioBattery.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.InternalChemicalBattery.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.InternalElectroBank.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.BionicGunk.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.BionicInternalBattery.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.BionicOil.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Amounts.BionicOxygenTank.deltaAttribute.Id, -2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.DecorExpectation.Id, +10, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.BionicBatteryCountCapacity.Id, +10, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.BionicBoosterSlots.Id, +7, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                new AttributeModifier(Db.Get().Attributes.MaxUnderwaterTravelCost.Id, +10, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),


                
                //new AttributeModifier(Db.Get().Attributes.Luminescence.Id, +100, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), lux
                //new AttributeModifier(Db.Get().Attributes.GeneratorOutput.Id, +10, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), shown but cant see diff



                new AttributeModifier(Db.Get().Attributes.MachinerySpeed.Id, -0.15f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),

                // all the same
                //new AttributeModifier(Db.Get().Attributes.QualityOfLifeExpectation.Id, -1, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                //new AttributeModifier(Db.Get().Attributes.QualityOfLife.Id, 1, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),

                new AttributeModifier(Db.Get().Amounts.Bladder.deltaAttribute.Id, 2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),

                new AttributeModifier(Db.Get().Amounts.HitPoints.deltaAttribute.Id, 2 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME),
                


                //new AttributeModifier(Db.Get().Attributes.Toggle.Id, +2f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), not skill, task
                //new AttributeModifier(Db.Get().Attributes.LifeSupport.Id, +3f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), not skill, task

                //new AttributeModifier(Db.Get().Attributes.Sneezyness.Id, 1, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), //hot here
                //new AttributeModifier(Db.Get().Attributes.AirConsumptionRate.Id, -0.01f, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), not here

                //new AttributeModifier(Db.Get().Attributes.FoodExpectation.Id, +1, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), //too good + must be timed with dinner
                //new AttributeModifier(Db.Get().Amounts.Breath.deltaAttribute.Id, 63 / time, STRINGS.EFFECTS.DUPLICANTGOTSUGARWATER.NAME), air out of nowhere

                //new AttributeModifier(Db.Get().Attributes.Learning.Id, 2, STRINGS.EFFECTS.DUPLICANTGOTETHANOL.NAME),
                //new AttributeModifier(Db.Get().Amounts.Stress.deltaAttribute.Id, -5 / time, STRINGS.EFFECTS.DUPLICANTGOTETHANOL.NAME),
            };

            return effect;
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public static class Db_Initialize_Patch
        {
            public static void Postfix()
            {
                Db.Get().effects.Add(EthanolEffect());
                Db.Get().effects.Add(SugarWaterEffect());
            }
        }

        [HarmonyPatch(typeof(MilkPressConfig), "AddRecipes")]
        public static class MilkPressConfig_AddRecipes_Patch
        {
            public static void Postfix()
            {
                ComplexRecipe.RecipeElement[] saltWaterIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 1.4f),
                    new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 18.6f),
                };
                ComplexRecipe.RecipeElement[] saltWaterResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.SaltWater.CreateTag(), 20f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe saltWaterRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(MilkPressConfig.ID, saltWaterIngredients, saltWaterResults), saltWaterIngredients, saltWaterResults)
                {
                    time = 40f,
                    description = string.Format((string)BUILDINGS.PREFABS.MILKPRESS.WHEAT_MILK_RECIPE_DESCRIPTION, SimHashes.Salt.CreateTag().ProperName(), SimHashes.SaltWater.CreateTag().ProperName()),
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult,
                    fabricators = new List<Tag>()
                    {
                        MilkPressConfig.ID
                    },
                    sortOrder = 11,
                };

                ComplexRecipe.RecipeElement[] brineIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 6f),
                    new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 14f),
                };
                ComplexRecipe.RecipeElement[] brineResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Brine.CreateTag(), 20f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe brineRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(MilkPressConfig.ID, brineIngredients, brineResults), brineIngredients, brineResults)
                {
                    time = 40f,
                    description = string.Format((string)BUILDINGS.PREFABS.MILKPRESS.WHEAT_MILK_RECIPE_DESCRIPTION, SimHashes.Salt.CreateTag().ProperName(), SimHashes.Brine.CreateTag().ProperName()),
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult,
                    fabricators = new List<Tag>()
                    {
                        MilkPressConfig.ID
                    },
                    sortOrder = 11,
                };


                ComplexRecipe.RecipeElement[] nectarIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 15.4f),
                    new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 4.6f),
                };
                ComplexRecipe.RecipeElement[] nectarResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.SugarWater.CreateTag(), 20f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe nectarRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(MilkPressConfig.ID, nectarIngredients, nectarResults), nectarIngredients, nectarResults)
                {
                    time = 40f,
                    description = string.Format((string)BUILDINGS.PREFABS.MILKPRESS.WHEAT_MILK_RECIPE_DESCRIPTION, SimHashes.Sucrose.CreateTag().ProperName(), SimHashes.SugarWater.CreateTag().ProperName()),
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult,
                    fabricators = new List<Tag>()
                    {
                        MilkPressConfig.ID
                    },
                    sortOrder = 12,
                };
            }
        }

        [HarmonyPatch(typeof(SupermaterialRefineryConfig), "ConfigureBuildingTemplate")]
        public static class SupermaterialRefineryConfig_ConfigureBuildingTemplate_Patch
        {
            public static void Postfix()
            {
                ComplexRecipe.RecipeElement[] leadIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Gold.CreateTag(), 90f),
                    new ComplexRecipe.RecipeElement(SimHashes.RefinedCarbon.CreateTag(), 5f),
                    new ComplexRecipe.RecipeElement(SimHashes.Polypropylene.CreateTag(), 5f),
                };
                ComplexRecipe.RecipeElement[] leadResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Lead.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe leadRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(SupermaterialRefineryConfig.ID, leadIngredients, leadResults), leadIngredients, leadResults)
                {
                    time = 80f,
                    description = LEAD.DESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag>()
                    {
                        SupermaterialRefineryConfig.ID
                    },
                    sortOrder = 2,
                };

                ComplexRecipe.RecipeElement[] abyssIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Tungsten.CreateTag(), 80f),
                    new ComplexRecipe.RecipeElement(SimHashes.Ceramic.CreateTag(), 15f),
                    new ComplexRecipe.RecipeElement(SimHashes.TempConductorSolid.CreateTag(), 5f),
                };
                ComplexRecipe.RecipeElement[] abyssResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Katairite.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe abyssRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(SupermaterialRefineryConfig.ID, abyssIngredients, abyssResults), abyssIngredients, abyssResults)
                {
                    time = 80f,
                    description = KATAIRITE.DESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag>()
                    {
                        SupermaterialRefineryConfig.ID
                    },
                    sortOrder = 2,
                };

                ComplexRecipe.RecipeElement[] сinnabarIngredients = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Sulfur.CreateTag(), 35),
                    new ComplexRecipe.RecipeElement(SimHashes.Mercury.CreateTag(), 65),
                };
                ComplexRecipe.RecipeElement[] сinnabarResults = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Cinnabar.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                ComplexRecipe сinnabarRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(SupermaterialRefineryConfig.ID, сinnabarIngredients, сinnabarResults), сinnabarIngredients, сinnabarResults)
                {
                    time = 80f,
                    description = CINNABAR.DESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag>()
                    {
                        SupermaterialRefineryConfig.ID
                    },
                    sortOrder = 2,
                };
            }
        }

        [HarmonyPatch(typeof(CraftingTableConfig), "ConfigureRecipes")]
        public static class CraftingTableConfig_ConfigureRecipes_Patch
        {
            public static void Postfix()
            {
                if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
                {
                    ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
                    {
                        new ComplexRecipe.RecipeElement(OrbitalResearchDatabankConfig.ID, 1f, true)
                    };
                    ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
                    {
                    new ComplexRecipe.RecipeElement(SimHashes.Polypropylene.CreateTag(), 5f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                    };
                    var OrbitalResearchDatabankConfigRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CraftingTableConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
                    {
                        time = 20f,
                        description = POLYPROPYLENE.DESC,
                        nameDisplay = ComplexRecipe.RecipeNameDisplay.ResultWithIngredient,
                        fabricators = new List<Tag>()
                    {
                        CraftingTableConfig.ID
                    },
                        sortOrder = 12,
                        requiredTech = "EnvironmentalAppreciation"
                    };
                }
                else
                {

                    ComplexRecipe.RecipeElement[] ResearchDatabankArray1 = new ComplexRecipe.RecipeElement[1]
                    {
                    new ComplexRecipe.RecipeElement(ResearchDatabankConfig.ID, 1f, true)
                    };
                    ComplexRecipe.RecipeElement[] ResearchDatabankArray2 = new ComplexRecipe.RecipeElement[1]
                    {
                    new ComplexRecipe.RecipeElement(SimHashes.Polypropylene.CreateTag(), 5f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                    };
                    var ResearchDatabankRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CraftingTableConfig.ID, ResearchDatabankArray1, ResearchDatabankArray2), ResearchDatabankArray1, ResearchDatabankArray2)
                    {
                        time = 20f,
                        description = POLYPROPYLENE.DESC,
                        nameDisplay = ComplexRecipe.RecipeNameDisplay.ResultWithIngredient,
                        fabricators = new List<Tag>()
                    {
                        CraftingTableConfig.ID
                    },
                        sortOrder = 12,
                        requiredTech = "EnvironmentalAppreciation"
                    };
                }
            }
        }

        [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
        public class RockCrusherConfig_ConfigureBuildingTemplate_Patch
        {
            public static void Postfix()
            {
                var rec = ComplexRecipeManager.Get().recipes.Find(x => x.ingredients.Length == 1 && x.ingredients[0].material == "IceBellyPoop");
                if (rec != null)
                {
                    ComplexRecipe.RecipeElement[] resultList = new ComplexRecipe.RecipeElement[]
                    {
                        new ComplexRecipe.RecipeElement(SimHashes.Phosphorite.CreateTag(), 32, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature),
                        new ComplexRecipe.RecipeElement(SimHashes.Clay.CreateTag(), 56, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature),
                        new ComplexRecipe.RecipeElement(SimHashes.Cinnabar.CreateTag(), 32, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature),
                    };
                    rec.description = string.Format(BUILDINGS.PREFABS.ROCKCRUSHER.RECIPE_DESCRIPTION_TWO_OUTPUT,
                        (string)ITEMS.INDUSTRIAL_PRODUCTS.ICE_BELLY_POOP.NAME,
                        $"{SimHashes.Phosphorite.CreateTag().ProperName()}, {SimHashes.Clay.CreateTag().ProperName()}",
                        SimHashes.Cinnabar.CreateTag().ProperName());
                    rec.results = resultList;
                }

                ComplexRecipe.RecipeElement[] ResearchDatabankArray1 = new ComplexRecipe.RecipeElement[1]
{
                    new ComplexRecipe.RecipeElement(SimHashes.WoodLog.CreateTag(), 100f, true)
};
                ComplexRecipe.RecipeElement[] ResearchDatabankArray2 = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(SimHashes.Regolith.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
                };
                var ResearchDatabankRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(RockCrusherConfig.ID, ResearchDatabankArray1, ResearchDatabankArray2), ResearchDatabankArray1, ResearchDatabankArray2)
                {
                    time = 40f,
                    description = string.Format(BUILDINGS.PREFABS.ROCKCRUSHER.RECIPE_DESCRIPTION,
                    SimHashes.WoodLog.CreateTag().ProperName(),
                    SimHashes.Regolith.CreateTag().ProperName()),
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult,
                    fabricators = new List<Tag>()
                    {
                        RockCrusherConfig.ID
                    },
                    sortOrder = 12,
                };
            }
        }

        [HarmonyPatch(typeof(KilnConfig), "ConfigureRecipes")]
        public class KilnConfig_ConfigureRecipes_Patch
        {
            public static void Postfix()
            {
                Tag tag1 = SimHashes.Ceramic.CreateTag();
                Tag tag2 = SimHashes.Clay.CreateTag();
                Tag tag3 = SimHashes.WoodLog.CreateTag();
                float amount1 = 100f;
                float amount2 = 50f;
                ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
                {
                    new ComplexRecipe.RecipeElement(tag2, amount1),
                    new ComplexRecipe.RecipeElement(tag3, amount2)
                };
                ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
                {
                    new ComplexRecipe.RecipeElement(tag1, amount1, ComplexRecipe.RecipeElement.TemperatureOperation.Heated)
                };

                string str1 = ComplexRecipeManager.MakeRecipeID(KilnConfig.ID, recipeElementArray1, recipeElementArray2);
                ComplexRecipe complexRecipe = new ComplexRecipe(str1, recipeElementArray1, recipeElementArray2)
                {
                    time = 40f,
                    description = string.Format(BUILDINGS.PREFABS.EGGCRACKER.RECIPE_DESCRIPTION, SimHashes.Clay.CreateTag().ProperName(), SimHashes.Ceramic.CreateTag().ProperName()),
                    fabricators = new List<Tag>()
                    {
                        KilnConfig.ID
                    },
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    sortOrder = 100
                };
            }
        }

        //[HarmonyPatch(typeof(AnalyzeSeed))]
        //[HarmonyPatch("Success")]
        //public static class AnalyzeSeed_Success_Patch
        //{
        //    public static void Postfix(ref bool __result)
        //    {
        //        __result = true;
        //    }
        //}

        //[HarmonyPatch(typeof(HarvestAmountFromSpacePOI))]
        //[HarmonyPatch("Success")]
        //public static class HarvestAmountFromSpacePOI_Success_Patch
        //{
        //    public static void Postfix(ref bool __result)
        //    {
        //        __result = true;
        //    }
        //}

        //[HarmonyPatch(typeof(DupesCompleteChoreInExoSuitForCycles))]
        //[HarmonyPatch("Success")]
        //public static class DupesCompleteChoreInExoSuitForCycles_Success_Patch
        //{
        //    public static void Postfix(ref bool __result)
        //    {
        //        __result = true;
        //    }
        //}
    }

}
