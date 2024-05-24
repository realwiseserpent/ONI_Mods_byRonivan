using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_Cookie : IEntityConfig
    {
        public const string Id = "KakawaCookie";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_Cookie.Id, "", 4000000f, 4, 255.15f, 277.15f, 4800f, true);

            foodInfo.AddEffects(new List<string>
            {
                Effects.ChocolateTasteId
            },
            DlcManager.AVAILABLE_ALL_VERSIONS);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_Cookie.Id,
                    STRINGS.FOOD.COOKIE.NAME,
                    STRINGS.FOOD.COOKIE.DESC, 1f, false, Assets.GetAnim(("food_cookie_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.7f, 0.5f, true),
                foodInfo);
            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[3]
            {
                new ComplexRecipe.RecipeElement("ColdWheatSeed", 4f),
                new ComplexRecipe.RecipeElement(Food_RoastedKakawa.Id, 4f),
                new ComplexRecipe.RecipeElement(Food_KakawaButter.Id, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement((Food_Cookie.Id), 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.COOKIE.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 3
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
