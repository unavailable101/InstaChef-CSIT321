using InstaChef.DTO;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("generate")]
    public class GenerateRecipeController : ControllerBase
    {
        private readonly IRecipeServices _recipeServices;
        public GenerateRecipeController(IRecipeServices recipeServices) 
        {
            _recipeServices = recipeServices;
        }

        [HttpGet]
        public IActionResult GenerateRecipe(string cuisine, string mealType, string difficulty, int preparationTime, int servingCount, List<IngredientDTO> chosenIngredients)
        {
            var recipe = _recipeServices.GenerateRecipe(cuisine, mealType, difficulty, preparationTime, servingCount, chosenIngredients);
            if (recipe == null) NoContent();

            return Ok(recipe);
        }

        [HttpPost("create-recipe")]
        public IActionResult CreateRecipe(RecipeDTO newRecipe, string username)
        {
            if (_recipeServices.CreateRecipe(newRecipe, username))
                return Ok();
            return BadRequest("Cannot create recipe");
        }
        
        [HttpPut("edit-recipe")]
        public IActionResult EditRecipe(RecipeDTO editRecipe, int recipeId)
        {
            if (_recipeServices.EditRecipe(editRecipe, recipeId))
                return Ok();
            return BadRequest("Failed to update recipe");
        }

    }
}
