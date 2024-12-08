using InstaChef.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaChef.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly InstaChefDbContext _context;
        public DataRepository(InstaChefDbContext context)
        {
            _context = context;
        }

        // Accounts
        public void ChangeStatus(string currentAccount)
        {
            var existingAccount = _context.Account.SingleOrDefault(x => x.Username == currentAccount);
            if (existingAccount.Status == 1) existingAccount.Status = 0;
            else existingAccount.Status = 1;
        }
        public void UpdateAccount(string username, string FirstName, string LastName, string Email, string hashPass)
        {
            var existingAccount = _context.Account.SingleOrDefault(x => x.Username == username);

            if (FirstName != null) existingAccount.FirstName = FirstName;
            if (LastName != null) existingAccount.LastName = LastName;
            if (Email != null) existingAccount.Email = Email;
            if (hashPass != null) existingAccount.Password = hashPass;
        }

        public void AddAccount(string username, string email, string password, int status)
        {
            int id = _context.Account.Max(x => x.Id) + 1;
            Account newAccount = new Account()
            {
                Id = id,
                Username = username,
                Email = email,
                Password = password,
                Status = 1
            };
            _context.Account.Add(newAccount);
        }

        // User Profile
        public Account? GetAccountByEmail(string email)
        {
            return _context.Account.SingleOrDefault(x => x.Email == email);
        }

        public Account? GetAccountByUsername(string username)
        {
            return _context.Account.SingleOrDefault(x => x.Username == username);
        }


        // Browse Recipes
        public List<Recipe>? GetAllRecipes()
        {
            return _context.Recipe
            .Include(r => r.RecipeIngredients) 
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.Creator)
            .ToList();
            throw new NotImplementedException();
        }
        public List<Recipe>? GetAllRecipeOfCurrUser(string currUser)
        {
            return _context.Recipe
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Where(r => r.Creator.Username == currUser) 
            .ToList();
            throw new NotImplementedException();
        }

        // Recipe Profile
        public Recipe? GetRecipeProfile(int Id)
        {
            return _context.Recipe
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.Creator)
            .SingleOrDefault(r => r.Id == Id);
            throw new NotImplementedException();
        }

        // Creating and Updating Recipe from Creator
        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipe.Update(recipe);
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            _context.SaveChanges();
            throw new NotImplementedException();
        }

        // Generating Recipe pero lists, si services nay bahalag pili
        public List<Recipe> GetRecipe(string cuisine, string mealType, string difficulty, int preparationTime, int servingCount, List<Ingredient> chosenIngredients)
        {
            var query = _context.Recipe
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .AsQueryable();

            if (!string.IsNullOrEmpty(cuisine))
                query = query.Where(r => r.CuisineType == cuisine);

            if (!string.IsNullOrEmpty(mealType))
                query = query.Where(r => r.MealType == mealType);

            if (!string.IsNullOrEmpty(difficulty))
                query = query.Where(r => r.CookingDifficulty == difficulty);

            if (preparationTime > 0)
                query = query.Where(r => r.PreparationTime <= preparationTime);

            if (servingCount > 0)
                query = query.Where(r => r.ServingCount >= servingCount);

            if (chosenIngredients != null && chosenIngredients.Any())
            {
                var ingredientIds = chosenIngredients.Select(ci => ci.Id).ToList();
                query = query.Where(r => r.RecipeIngredients.Any(ri => ingredientIds.Contains(ri.IngredientId)));
            }

            return query.ToList();
            throw new NotImplementedException();
        }
    }
}
