using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    public class GenerateRecipeController : ControllerBase
    {
        private readonly IRecipeServices _recipeServices;
        public GenerateRecipeController(IRecipeServices recipeServices) 
        {
            _recipeServices = recipeServices;
        }

        [HttpGet]
        public IActionResult GenerateRecipe()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateRecipe()
        {
            return Ok();
        }
        
        [HttpPut]
        public IActionResult EditRecipe()
        {
            return Ok();
        }

    }
}
