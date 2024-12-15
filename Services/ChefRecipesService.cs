using InstaChef.DTO;
using InstaChef.Models;
using InstaChef.Repositories;

namespace InstaChef.Services

{
    public interface IChefRecipesService
    {
        Task<List<ChefRecipesDTO>> SearchRecipesAsync(string[] keywords, bool matchAllKeywords);
    }
    public class ChefRecipesService : IChefRecipesService
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
                Category = r.Category,
                ImageName = r.ImageName
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
                Category = recipeDto.Category.GetValueOrDefault(0),
                ImageName = recipeDto.ImageName
            };

            await _repository.AddRecipeAsync(recipe);
        }

        public async Task<List<ChefRecipesDTO>> SearchRecipesAsync(string[] keywords, bool matchAllKeyword)
        {
            // Get the recipes matching the keywords
            var recipes = await _repository.SearchRecipesAsync(keywords, matchAllKeyword);

            // Convert the results to DTOs
            var recipesDto = recipes.Select(r => new ChefRecipesDTO
            {
                Name = r.Name,
                Description = r.Description,
                Preparation = r.Preparation,
                CuisineType = r.CuisineType,
                MealType = r.MealType,
                CookingDifficulty = r.CookingDifficulty,
                PreparationTime = r.PreparationTime,
                ServingCount = r.ServingCount,
                Category = r.Category,
                ImageName = r.ImageName
            }).ToList();

            return recipesDto;
        }

        public async Task<List<ChefRecipes>> GenerateRecipes(string cuisineType, string mealType, string cookingDifficulty, int? preparationTime, string[] keywords)
        {
            return await _repository.GenerateRecipes(cuisineType, mealType, cookingDifficulty, preparationTime, keywords);
        }

        public async Task<IEnumerable<ChefRecipes>> GetRecipesByCategoryAsync()
        {
            return await _repository.GetRecipesByCategoryAsync();
        }
    }
}