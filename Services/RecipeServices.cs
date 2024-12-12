using InstaChef.DTO;
using InstaChef.Models;
using InstaChef.Repository;

namespace InstaChef.Services
{
    public class RecipeServices : IRecipeServices
    {
        private readonly IDataRepository _dataRepository;

        public RecipeServices(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public bool CreateRecipe(RecipeDTO newRecipe, string username)
        {
            var creator = _dataRepository.GetAccountByUsername(username);
            if (creator == null)
            {
                throw new ArgumentException("Invalid username");
            }

            var recipe = new Recipe
            {
                Name = newRecipe.Name,
                Preparation = newRecipe.Preparation,
                PreparationTime = newRecipe.PreparationTime,
                CuisineType = newRecipe.CuisineType,
                MealType = newRecipe.MealType,
                CookingDifficulty = newRecipe.CookingDifficulty,
                ServingCount = newRecipe.ServingCount,
                CreatorId = creator.Id,
                DateCreated = DateOnly.FromDateTime(DateTime.Now)
            };

            recipe.RecipeIngredients = newRecipe.Ingredients.Select(ingredientDTO =>
            {
                var ingredient = _dataRepository.GetIngredient(ingredientDTO.Name);
                if (ingredient == null)
                {
                    // Handle the missing ingredient here
                    throw new ArgumentException($"Ingredient '{ingredientDTO.Name}' not found in the database");
                }

                return new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingredient.Id,
                    Quantity = ingredientDTO.Quantity,
                    Unit = ingredientDTO.Unit
                };
            }).ToList();

            _dataRepository.AddRecipe(recipe);

            return true;
        }


        public bool EditRecipe(RecipeDTO editRecipe, int id)
        {
            var recipeExist = _dataRepository.GetRecipeProfile(id);

            if (recipeExist == null) return false;

            recipeExist.Name = editRecipe.Name;
            recipeExist.Preparation = editRecipe.Preparation;
            recipeExist.PreparationTime = editRecipe.PreparationTime;
            recipeExist.CuisineType = editRecipe.CuisineType;
            recipeExist.MealType = editRecipe.MealType;
            recipeExist.CookingDifficulty = editRecipe.CookingDifficulty;
            recipeExist.ServingCount = editRecipe.ServingCount;

            recipeExist.RecipeIngredients.Clear();
            recipeExist.RecipeIngredients = editRecipe.Ingredients.Select(
                ingredientsDTO =>
                {
                    var ingredient = _dataRepository.GetIngredient(ingredientsDTO.Name);

                    return new RecipeIngredient
                    {
                        RecipeId = id,
                        IngredientId = ingredient.Id,
                        Quantity = ingredientsDTO.Quantity,
                        Unit = ingredientsDTO.Unit
                    };
                }
            ).ToList();

            return true;
            
            throw new NotImplementedException();
        }

        public RecipeProfile? GenerateRecipe(string cuisine, string mealType, string difficulty, int preparationTime, int servingCount, List<IngredientDTO> chosenIngredients)
        {
            var listIngredients = _dataRepository.GetAllIngredients().Select(
                ci => new Ingredient
                {
                    Name = ci.Name,
                    Category = ci.Category
                }
            ).ToList();

            var allRecipes = _dataRepository.GetRecipe(cuisine, mealType, difficulty, preparationTime, servingCount, listIngredients);
            if (allRecipes == null || !allRecipes.Any()) return null;
            var generatedRecipe = allRecipes.FirstOrDefault();
            return new RecipeProfile
            {
                Id = generatedRecipe.Id,
                Name = generatedRecipe.Name,
                Preparation = generatedRecipe.Preparation,
                PreparationTime = generatedRecipe.PreparationTime,
                Ingredients = generatedRecipe.RecipeIngredients.Select(
                        ri => new IngredientDTO
                        {
                            Name = ri.Ingredient.Name,
                            Category = ri.Ingredient.Category,
                            Quantity = ri.Quantity,
                            Unit = ri.Unit
                        }
                    ).ToList(),
                ChefUsername = null
            };
            throw new NotImplementedException();
        }

        public List<RecipeProfile> GetMyRecipes(string username)
        {
            var myRecipes = _dataRepository.GetAllRecipeOfCurrUser(username);
            if (myRecipes == null) return null;
            return myRecipes.Select(
                recipe => new RecipeProfile
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Preparation = recipe.Preparation,
                    PreparationTime = recipe.PreparationTime,
                    Ingredients = recipe.RecipeIngredients.Select(
                        ri => new IngredientDTO
                        {
                            Name = ri.Ingredient.Name,
                            Category = ri.Ingredient.Category,
                            Quantity = ri.Quantity,
                            Unit = ri.Unit
                        }
                    ).ToList(),
                    ChefUsername = username
                }               
            ).ToList();
            throw new NotImplementedException();
        }
    }
}
