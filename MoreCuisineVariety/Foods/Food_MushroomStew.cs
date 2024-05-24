using System.Collections.Generic;
using TUNING;
using UnityEngine;
using DupesCuisine.Crops;

namespace DupesCuisine.Foods
{
    public class Food_MushroomStew : IEntityConfig
    {
        public const string Id = "MushroomStew";
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_MushroomStew.Id, "", 6000000f, 6, 255.15f, 277.15f, 2400f, true);
            foodInfo.AddEffects(new List<string>
            {
                "GoodEats"
            },
            DlcManager.AVAILABLE_ALL_VERSIONS);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(Food_MushroomStew.Id,
                STRINGS.FOOD.MUSHROOMSTEW.NAME,
                STRINGS.FOOD.MUSHROOMSTEW.DESC, 1f, false, Assets.GetAnim(("food_mushroom_stew_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.7f, 0.5f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(Crop_SunnyWheatGrain.Id, 4f),
                new ComplexRecipe.RecipeElement("ColdWheatBread", 1f),
                new ComplexRecipe.RecipeElement(Food_GrilledCreamtop.Id, 2f),
                new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f)
            };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Food_MushroomStew.Id, 1f)
            };
            this.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2, 0)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.MUSHROOMSTEW.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
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
