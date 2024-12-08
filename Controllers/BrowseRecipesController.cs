using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    public class BrowseRecipesController : ControllerBase
    {
        private readonly IBrowserFile _browserFile;

        public BrowseRecipesController(IBrowserFile browserFile)
        {
            _browserFile = browserFile;
        }

        [HttpGet]
        public IActionResult TrendingRecipes()
        {
            return Ok();
        }
        
        [HttpGet]
        public IActionResult NewRecipes()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult PopularRecipes()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult SavedRecipes()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult LikedRecipes()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult RecipeProfile()
        {
            return Ok();
        }


    }
}
