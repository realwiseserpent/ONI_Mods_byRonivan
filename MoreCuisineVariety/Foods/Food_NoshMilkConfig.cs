using System.Collections.Generic;
using UnityEngine;
using TUNING;
using DupesCuisine.Buildings;

namespace DupesCuisine.Foods
{
    public class Food_NoshMilkConfig : IEntityConfig
    {
        public const string Id = "NoshMilk";
        public static ComplexRecipe recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            ConfigureRecipes();

            return EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_NoshMilkConfig.Id,
                    STRINGS.FOOD.NOSHMILK.NAME,
                    STRINGS.FOOD.NOSHMILK.DESC, 1f, true, Assets.GetAnim(("nosh_milk_kanim")), "object", (Grid.SceneLayer)26, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_NoshMilkConfig.Id, "", 0.0f, 0, 255.15f, 277.15f, 4800f, true));
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }

        private void ConfigureRecipes()
        {
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement("BeanPlantSeed", 7f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 12f),
            };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_NoshMilkConfig.Id, 6f, 0, false),
            };

            recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, ingredients, results), ingredients, results, 0)
            {
                time = FOOD.RECIPES.SMALL_COOK_TIME,
                description = STRINGS.FOOD.NOSHMILK.RECIPEDESC,
                nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
                fabricators = new List<Tag>{ ManualJuicerConfig.ID },
                sortOrder = 1
            };
        }
    }
}
