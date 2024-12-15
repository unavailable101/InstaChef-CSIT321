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
    }
}