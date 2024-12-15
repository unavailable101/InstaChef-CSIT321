using InstaChef.DTO;
using InstaChef.Models;
using InstaChef.Repositories;

namespace InstaChef.Services
{
    public class ChefRecipesService
    {
        private readonly IChefRecipesRepository _repository;

        public ChefRecipesService(IChefRecipesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ChefRecipesDTO>> GetAllRecipesAsync()
        {
            var recipes = await _repository.GetAllRecipesAsync();
            return recipes.Select(r => new ChefRecipesDTO
            {
                Name = r.Name,
                Description = r.Description,
                Preparation = r.Preparation,
                CuisineType = r.CuisineType,
                MealType = r.MealType,
                CookingDifficulty = r.CookingDifficulty,
                PreparationTime = r.PreparationTime,
                ServingCount = r.ServingCount,
                Category = r.Category
            });
        }
        public async Task AddRecipeAsync(ChefRecipesDTO recipeDto)
        {
            var recipe = new ChefRecipes
            {
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                Preparation = recipeDto.Preparation,
                CuisineType = recipeDto.CuisineType,
                MealType = recipeDto.MealType,
                CookingDifficulty = recipeDto.CookingDifficulty,
                PreparationTime = recipeDto.PreparationTime,
                ServingCount = recipeDto.ServingCount,
                Category = recipeDto.Category
            };

            await _repository.AddRecipeAsync(recipe);
        }
    }
}