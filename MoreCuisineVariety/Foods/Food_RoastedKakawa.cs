using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Foods
{
    public class Food_RoastedKakawa : IEntityConfig
    {
        public const string Id = "Roasted_Kakawa";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_RoastedKakawa.Id,
                    STRINGS.FOOD.ROASTEDKAKAWA.NAME,
                    STRINGS.FOOD.ROASTEDKAKAWA.DESC, 1f, false, Assets.GetAnim(("food_roasted_kakawa_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                new EdiblesManager.FoodInfo(Food_RoastedKakawa.Id, "", 300000f, 0, 275.15f, 298.15f, 7200f, true));

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Crop_KakawaAcorn.Id, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_RoastedKakawa.Id, 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = 10f,
                description = STRINGS.FOOD.ROASTEDKAKAWA.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
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
