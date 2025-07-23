using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_KakawaBar : IEntityConfig
    {
        public const string Id = "KakawaBar";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_KakawaBar.Id, 3000000f, 3, 255.15f, 277.15f, 4800f, true);

            foodInfo.AddEffects(new List<string>
            {
                Effects.ChocolateTasteId
            });

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_KakawaBar.Id,
                    STRINGS.FOOD.KAKAWABAR.NAME,
                    STRINGS.FOOD.KAKAWABAR.DESC, 1f, false, Assets.GetAnim(("food_kakawa_bar_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
            {
                new ComplexRecipe.RecipeElement(Food_RoastedKakawa.Id, 6f),
                new ComplexRecipe.RecipeElement(Food_KakawaButter.Id, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_KakawaBar.Id, 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(MicrobeMusherConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.KAKAWABAR.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { MicrobeMusherConfig.ID },
                sortOrder = 3
            };

            Recipe.SetFabricationAnim("food_kakawa_bar_kanim");

            return food;
        }

        public string[] GetDlcIds() => null;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
