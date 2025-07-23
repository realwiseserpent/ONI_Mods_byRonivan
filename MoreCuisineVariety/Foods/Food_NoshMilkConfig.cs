using System.Collections.Generic;
using UnityEngine;
using TUNING;
using DupesCuisine.Buildings;
using DupesCuisine.Plants;

namespace DupesCuisine.Foods
{
    public class Food_NoshMilkConfig : IEntityConfig
    {
        public const string Id = "NoshMilk";
        public static ComplexRecipe originalRecipe;
        public static ComplexRecipe extendedRecipe;

        public string[] GetDlcIds() => null;

        public GameObject CreatePrefab()
        {
            ConfigureRecipes();

            return EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_NoshMilkConfig.Id,
                    STRINGS.FOOD.NOSHMILK.NAME,
                    STRINGS.FOOD.NOSHMILK.DESC, 1f, false, Assets.GetAnim(("nosh_milk_kanim")), "object", (Grid.SceneLayer)26, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_NoshMilkConfig.Id, 0.0f, 0, 255.15f, 277.15f, 4800f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }

        private void ConfigureRecipes()
        {
            ComplexRecipe.RecipeElement[] originalRecipeIngredients = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    "BeanPlantSeed",
                    Plant_SunnyWheatConfig.SeedId
                }, new float[]{ 4f, 8f }),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 15f),
            };
            ComplexRecipe.RecipeElement[] originalRecipeResults = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 3f, 0, false),
            };

            originalRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, originalRecipeIngredients, originalRecipeResults), originalRecipeIngredients, originalRecipeResults, 0)
            {
                time = 50f,
                description = STRINGS.FOOD.NOSHMILK.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag> { ManualJuicerConfig.ID },
                sortOrder = 1
            };
            //-------------

            ComplexRecipe.RecipeElement[] extendedRecipeIngredients = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(new Tag[]
                {
                    SimHashes.Sand.CreateTag(),
                    SimHashes.Regolith.CreateTag(),
                }, 6f),
                new ComplexRecipe.RecipeElement(SimHashes.Milk.CreateTag(), 30f),
            };
            ComplexRecipe.RecipeElement[] extendedRecipeResults = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 3f, 0, false),
            };

            if (false)
                extendedRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, extendedRecipeIngredients, extendedRecipeResults), extendedRecipeIngredients, extendedRecipeResults, 0)
                {
                    time = 50f,
                    description = STRINGS.FOOD.NOSHMILK.RECIPEDESC,
                    nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                    fabricators = new List<Tag> { ManualJuicerConfig.ID },
                    sortOrder = 1
                };
        }
    }
}
