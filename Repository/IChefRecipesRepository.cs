using InstaChef.Models;
using InstaChef.DTO;

namespace InstaChef.Repositories
{
    public interface IChefRecipesRepository
    {
        Task<IEnumerable<ChefRecipes>> GetAllRecipesAsync();
        Task<ChefRecipes> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(ChefRecipes recipe);
        Task UpdateRecipeAsync(ChefRecipes recipe);
        Task DeleteRecipeAsync(int id);

        Task<List<ChefRecipes>> SearchRecipesAsync(string[] keywords, bool matchAllKeywords);
        Task<List<ChefRecipes>> GenerateRecipes(string cuisineType, string mealType, string cookingDifficulty, int? preparationTime, string[] keywords);
    }
}