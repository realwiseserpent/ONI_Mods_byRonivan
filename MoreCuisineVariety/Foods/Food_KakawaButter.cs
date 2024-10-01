using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;
using DupesCuisine.Buildings;

namespace DupesCuisine.Foods
{
    public class Food_KakawaButter : IEntityConfig
    {
        public const string Id = "KakawaButter";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_KakawaButter.Id,
                    STRINGS.FOOD.KAKAWABUTTER.NAME,
                    STRINGS.FOOD.KAKAWABUTTER.DESC, 1f, false, Assets.GetAnim(("food_kakawa_butter_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                    new EdiblesManager.FoodInfo(Food_KakawaButter.Id, "", 0.0f, -1, 255.15f, 277.15f, 4800f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Crop_KakawaAcorn.Id, 4f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Food_KakawaButter.Id, 1f),
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(ManualJuicerConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = 50f,
                description = STRINGS.FOOD.KAKAWABUTTER.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { ManualJuicerConfig.ID },
                sortOrder = 3,
            };
            return food;
        }

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
