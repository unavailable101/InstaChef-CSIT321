using InstaChef.DTO;
using InstaChef.Models;

namespace InstaChef.Services
{
    public interface IRecipeServices
    {
        public List<RecipeProfile> GetMyRecipes(string username);
        public bool CreateRecipe(RecipeDTO newRecipe, string username);
        public bool EditRecipe(RecipeDTO editRecipe, int id);
        public RecipeProfile? GenerateRecipe(string cuisine, string mealType, string difficulty, int preparationTime, int servingCount, List<IngredientDTO> chosenIngredients);
    }
}
