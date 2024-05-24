using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_Nutpie : IEntityConfig
    {
        public const string Id = "Nutpie";
        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            EdiblesManager.FoodInfo foodInfo = new EdiblesManager.FoodInfo(Food_Nutpie.Id, "", 6000000f, 5, 255.15f, 277.15f, 4800f, true);
            foodInfo.AddEffects(new List<string>
            {
                Effects.SugarRushId
            },
            DlcManager.AVAILABLE_ALL_VERSIONS);

            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_Nutpie.Id,
                    STRINGS.FOOD.NUTPIE.NAME,
                    STRINGS.FOOD.NUTPIE.DESC, 1f, false, Assets.GetAnim(("food_nutpie_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true),
                foodInfo);

            ComplexRecipe.RecipeElement[] recipeElementArray1;
            if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))
                recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
                {
                    new ComplexRecipe.RecipeElement("WormBasicFood", 2f),
                    new ComplexRecipe.RecipeElement("ColdWheatSeed", 2f),
                    new ComplexRecipe.RecipeElement("RawEgg", 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f)
                };
            else
                recipeElementArray1 = new ComplexRecipe.RecipeElement[4]
                {
                    new ComplexRecipe.RecipeElement(GrilledPrickleFruitConfig.ID, 6/5f),
                    new ComplexRecipe.RecipeElement("ColdWheatSeed", 2f),
                    new ComplexRecipe.RecipeElement("RawEgg", 1f),
                    new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f)
                };
            ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_Nutpie.Recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(GourmetCookingStationConfig.ID, recipeElementArray1, recipeElementArray2), recipeElementArray1, recipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.NUTPIE.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { GourmetCookingStationConfig.ID },
                sortOrder = 31
            };
            return food;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
