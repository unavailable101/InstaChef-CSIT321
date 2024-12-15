using InstaChef.DTO;
using InstaChef.Models;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChefRecipesController : ControllerBase
    {
        private readonly ChefRecipesService _service;

        public ChefRecipesController(ChefRecipesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _service.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(ChefRecipesDTO recipeDto)
        {
            await _service.AddRecipeAsync(recipeDto);
            return CreatedAtAction(nameof(GetAllRecipes), new { name = recipeDto.Name }, recipeDto);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ChefRecipesDTO>>> SearchRecipes([FromQuery] string[] keywords, bool matchAllKeywords)
        {
            if (keywords == null || keywords.Length == 0)
            {
                return BadRequest("At least one keyword is required.");
            }

            var recipes = await _service.SearchRecipesAsync(keywords, matchAllKeywords);

            if (recipes == null || !recipes.Any())
            {
                return NotFound("No recipes found containing all the keywords.");
            }

            return Ok(recipes); // Return the list of matching recipes
        }

        [HttpGet("GenerateRecipes")]
        public async Task<IActionResult> GenerateRecipes(
        [FromQuery] string? cuisineType,
        [FromQuery] string? mealType,
        [FromQuery] string? cookingDifficulty,
        [FromQuery] int? preparationTime,
        [FromQuery] string[]? keywords)
        {
            try
            {
                var recipes = await _service.GenerateRecipes(cuisineType, mealType, cookingDifficulty, preparationTime, keywords);
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("Category")]
        public async Task<ActionResult<IEnumerable<ChefRecipes>>> GetRecipesByCategory()
        {
            try
            {
                var recipes = await _service.GetRecipesByCategoryAsync();
                if (recipes == null || !recipes.Any())
                {
                    return NotFound("No recipes found for the specified categories.");
                }

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}