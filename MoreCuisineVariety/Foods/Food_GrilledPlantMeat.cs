using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Foods
{
    public class Food_GrilledPlantMeat : IEntityConfig
    {
        public const string Id = "GrilledPlantMeat";
        public static ComplexRecipe OriginalRecipe;
        public static ComplexRecipe ExtendedRecipe;

        public string[] GetDlcIds() => null;

        public GameObject CreatePrefab()
        {
            GameObject food = EntityTemplates.ExtendEntityToFood(
                EntityTemplates.CreateLooseEntity(
                    Food_GrilledPlantMeat.Id,
                    STRINGS.FOOD.GRILLEDPLANTMEAT.NAME,
                    STRINGS.FOOD.GRILLEDPLANTMEAT.DESC, 1f, false, Assets.GetAnim(("food_grilled_plantmeat_kanim")), "object", (Grid.SceneLayer)26, (EntityTemplates.CollisionShape)1, 0.8f, 0.4f, true, 0, (SimHashes)976099455, null),
                new EdiblesManager.FoodInfo(Food_GrilledPlantMeat.Id, 1600000f, 2, 255.15f, 277.15f, 2400f, true));

            ComplexRecipe.RecipeElement[] originalRecipeElementArray;
            ComplexRecipe.RecipeElement[] extendedRecipeElementArray;

            //if (DlcManager.IsContentSubscribed(DlcManager.EXPANSION1_ID))

            //-------------------------------------------
            originalRecipeElementArray = new ComplexRecipe.RecipeElement[1]
            {
                    new ComplexRecipe.RecipeElement("PlantMeat", 1f)
            };

            ComplexRecipe.RecipeElement[] originalRecipeElementArray2 = new ComplexRecipe.RecipeElement[1]
{
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
};
            Food_GrilledPlantMeat.OriginalRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, originalRecipeElementArray, originalRecipeElementArray2), originalRecipeElementArray, originalRecipeElementArray2, DlcManager.EXPANSION1)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.GRILLEDPLANTMEAT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 27
            };
            //-------------------------------------------------


            extendedRecipeElementArray = new ComplexRecipe.RecipeElement[]
                {
                    new ComplexRecipe.RecipeElement(new Tag[]
                    {
                        "BasicPlantFood",
                        "ButterflyPlantSeed"
                    },new float[] { 2.5f, 1f}),
                    new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 0.5f),
                };

            ComplexRecipe.RecipeElement[] extendedRecipeElementArray2 = new ComplexRecipe.RecipeElement[1]
            {
                new ComplexRecipe.RecipeElement(Id, 1f, (ComplexRecipe.RecipeElement.TemperatureOperation) 1, false)
            };
            Food_GrilledPlantMeat.ExtendedRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(CookingStationConfig.ID, extendedRecipeElementArray, extendedRecipeElementArray2), extendedRecipeElementArray, extendedRecipeElementArray2)
            {
                time = FOOD.RECIPES.STANDARD_COOK_TIME,
                description = STRINGS.FOOD.GRILLEDPLANTMEAT.RECIPEDESC,
                nameDisplay = (ComplexRecipe.RecipeNameDisplay)1,
                fabricators = new List<Tag>() { CookingStationConfig.ID },
                sortOrder = 27
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
