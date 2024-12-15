using InstaChef.DTO;
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
    }
}