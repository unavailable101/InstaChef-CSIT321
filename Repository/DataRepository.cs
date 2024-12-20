﻿using InstaChef.Models;
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
            var existingAccount = _context.Accounts.SingleOrDefault(x => x.Username == currentAccount);
            if (existingAccount.Status == 1) existingAccount.Status = 0;
            else existingAccount.Status = 1;

            _context.SaveChanges();
        }
        public void UpdateAccount(string username, string FirstName, string LastName, string Email, string hashPass)
        {
            var existingAccount = _context.Accounts.SingleOrDefault(x => x.Username == username);

            if (FirstName != null) existingAccount.FirstName = FirstName;
            if (LastName != null) existingAccount.LastName = LastName;
            if (Email != null) existingAccount.Email = Email;
            if (hashPass != null) existingAccount.Password = hashPass;
            
            _context.SaveChanges();
        }

        public void AddAccount(string username, string email, string password, int status)
        {
            //int id = _context.Account.Max(x => x.Id) + 1;
            Account newAccount = new Account()
            {
                //Id = id,
                Username = username,
                Email = email,
                Password = password,
                Status = 1
            };
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
        }

        // User Profile
        public Account? GetAccountByEmail(string email)
        {
            return _context.Accounts.SingleOrDefault(x => x.Email == email);
        }

        public Account? GetAccountByUsername(string username)
        {
            return _context.Accounts.SingleOrDefault(x => x.Username == username);
        }


        // Browse Recipes
        public List<Recipe>? GetAllRecipes()
        {
            return _context.Recipes
            .Include(r => r.RecipeIngredients) 
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.Creator)
            .ToList();
        }
        public List<Recipe>? GetAllRecipeOfCurrUser(string currUser)
        {
            return _context.Recipes
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Where(r => r.Creator.Username == currUser) 
            .ToList();
        }

        // Recipe Profile
        public Recipe? GetRecipeProfile(int Id)
        {
            return _context.Recipes
            .Include(r => r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .Include(r => r.Creator)
            .SingleOrDefault(r => r.Id == Id);
        }

        // Creating and Updating Recipe from Creator
        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        // Generating Recipe pero lists, si services nay bahalag pili
        public List<Recipe> GetRecipe(string cuisine, string mealType, string difficulty, int preparationTime, int servingCount, List<Ingredient> chosenIngredients)
        {
            var query = _context.Recipes
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
        }

        public Ingredient? GetIngredient(string name)
        {
            return _context.Ingredients.SingleOrDefault(ci => ci.Name == name);
        }

        public List<Ingredient> GetAllIngredients() 
        {
            return _context.Ingredients.ToList();
        }
    }
}
