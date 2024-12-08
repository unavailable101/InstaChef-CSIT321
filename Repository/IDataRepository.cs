using InstaChef.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace InstaChef.Repository
{
    public interface IDataRepository
    {

        // Account
        public void AddAccount(string username, string email, string password, int status);
        public Account? GetAccountByEmail(string email);  //profile
        public Account? GetAccountByUsername(string username);  //profile
        public void UpdateAccount(string username, string FirstName, string LastName, string Email, string hashPass);
        public void ChangeStatus(string currentAccount);

        // Recipes
        public List<Recipe>? GetAllRecipeOfCurrUser(string currUser);
        public List<Recipe>? GetAllRecipes();
        public void UpdateRecipe(Recipe recipe);
        public void AddRecipe(Recipe recipe);   //create recipe
        public Recipe? GetRecipeProfile(int Id);   //recipe profile
        public List<Recipe> GetRecipe(string Cuisine, string MealType, string Difficulty, int PreparationTime, int ServingCount, List<Ingredient> ChosenIngredients);    //generating recipe

    }
}
