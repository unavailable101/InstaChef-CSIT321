using InstaChef.DTO;
using InstaChef.Repository;

namespace InstaChef.Services
{
    public class BrowseServices : IBrowseServices
    {
        private readonly IDataRepository _dataRepository;

        public BrowseServices(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public List<RecipeProfile> GetAllRecipes()
        {
            var recipes = _dataRepository.GetAllRecipes();
            return recipes.Select(
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
                    ChefUsername = recipe.Creator.Username
                }
            ).ToList();
            throw new NotImplementedException();
        }

        public string GetLikedRecipes() //unya nako ani
        {
            throw new NotImplementedException();
        }

        public string GetNewRecipes()   //mag base guro ko sa when na create ang recipe, but later na kay update nasd sa table @-@
        {
            throw new NotImplementedException();
        }

        public string GetPopularRecipes()   //unya nako ani
        {
            throw new NotImplementedException();
        }

        public RecipeProfile? GetRecipeProfile(int id)
        {
            var recipe = _dataRepository.GetRecipeProfile(id);
            if (recipe == null) return null;
            return new RecipeProfile
            {
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
                ChefUsername = recipe.Creator.Username
            };
            throw new NotImplementedException();
        }

        public string GetSavedRecipes() //unya nako ani
        {
            throw new NotImplementedException();
        }

        public string GetTrendingRecipes()  //unya nako ani
        {
            throw new NotImplementedException();
        }
    }
}
