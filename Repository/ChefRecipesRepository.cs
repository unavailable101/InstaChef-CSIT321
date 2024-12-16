using InstaChef.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaChef.Repositories
{
    public class ChefRecipesRepository : IChefRecipesRepository
    {
        private readonly InstaChefDbContext _context;

        public ChefRecipesRepository(InstaChefDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChefRecipes>> GetAllRecipesAsync()
        {
            return await _context.ChefRecipes.ToListAsync();
        }

        public async Task<ChefRecipes> GetRecipeByIdAsync(int id)
        {
            return await _context.ChefRecipes.FindAsync(id);
        }

        public async Task AddRecipeAsync(ChefRecipes recipe)
        {
            await _context.ChefRecipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRecipeAsync(ChefRecipes recipe)
        {
            _context.ChefRecipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.ChefRecipes.FindAsync(id);
            if (recipe != null)
            {
                _context.ChefRecipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }

        // added Search Recipes
        public async Task<List<ChefRecipes>> SearchRecipesAsync(string[] keywords, bool matchAllKeywords)
        {
            if (keywords == null || !keywords.Any()) return new List<ChefRecipes>();

            var query = _context.ChefRecipes.AsQueryable();

            if (matchAllKeywords)
            {
                foreach (var keyword in keywords)
                {
                    query = query.Where(r => EF.Functions.Contains(r.Description, $"\"{keyword}\""));
                }
            }
            else
            {
                foreach (var keyword in keywords)
                {
                    query = query.Where(r => EF.Functions.Contains(r.Description, $"\"{keyword}\""));
                }
            }

            return await query.ToListAsync();
        }

        // Added Generate Recipes Kunuhay
        public async Task<List<ChefRecipes>> GenerateRecipes(string cuisineType, string mealType, string cookingDifficulty, int? preparationTime, string[] keywords)
        {
            var query = _context.ChefRecipes.AsQueryable();

            // Filter Random Cuisine
            if (!string.IsNullOrEmpty(cuisineType))
            {
                if (cuisineType.ToLower() == "random")
                {
                    var randomCuisineTypes = new[] { "Italian", "Korean", "Mexican", "Indian", "Chinese", "Japanese", "French", "American", "Thai" };
                    cuisineType = randomCuisineTypes[new Random().Next(randomCuisineTypes.Length)];
                }
                query = query.Where(r => r.CuisineType == cuisineType);
            }

            // Filter MealType
            if (!string.IsNullOrEmpty(mealType))
            {
                query = query.Where(r => r.MealType == mealType);
            }

            // Filter CookingDifficulty
            if (!string.IsNullOrEmpty(cookingDifficulty))
            {
                query = query.Where(r => r.CookingDifficulty == cookingDifficulty);
            }

            // Filter PreparationTime
            if (preparationTime.HasValue)
            {
                if(preparationTime == 135)
                {
                    query = query.Where(r => true);

                } else
                {
                    query = query.Where(r => r.PreparationTime <= preparationTime);
                }
            }

            // Filter Keywords in Description
            if (keywords != null && keywords.Any())
            {
                foreach (var keyword in keywords)
                {
                    if (keyword != null) // Check if the keyword is not null
                    {
                        var tempKeyword = keyword.ToLower(); // Ensure case-insensitive comparison
                        query = query.Where(r => r.Description != null && r.Description.ToLower().Contains(tempKeyword));
                    }
                }
            }

            return await query.ToListAsync();
        }

        // Recipes by category
        public async Task<IEnumerable<ChefRecipes>> GetRecipesByCategoryAsync()
        {
            var categories = new[] { 1, 2, 3, 4, 5 };
            var recipes = new List<ChefRecipes>();

            foreach (var category in categories)
            {
                var categoryRecipes = await _context.ChefRecipes
                    .Where(r => r.Category == category)
                    .Select(r => new ChefRecipes
                    {
                        Id = r.Id,
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
                    })
                    .Take(3)
                    .ToListAsync();

                recipes.AddRange(categoryRecipes);
            }

            return recipes;
        }
    }
}