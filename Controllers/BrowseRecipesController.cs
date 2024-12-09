using InstaChef.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("home/")]
    public class BrowseRecipesController : ControllerBase
    {
        private readonly IBrowseServices _browseServices;

        public BrowseRecipesController(IBrowseServices browseServices)
        {
            _browseServices = browseServices;
        }

        [HttpGet("trending")]
        public IActionResult TrendingRecipes()
        {
            var trending = _browseServices.GetTrendingRecipes();
            if ( trending == null) return NoContent();
            return Ok(trending);
        }
        
        [HttpGet("new-recipes")]
        public IActionResult NewRecipes()
        {
            var newRecipes = _browseServices.GetNewRecipes();
            if (newRecipes == null) return NoContent();
            return Ok(newRecipes);
        }

        [HttpGet("popular")]
        public IActionResult PopularRecipes()
        {
            var popular = _browseServices.GetPopularRecipes();
            if (popular == null) return NoContent();
            return Ok(popular);
        }

        [HttpGet("saved-recipe")]
        public IActionResult SavedRecipes()
        {
            var saved= _browseServices.GetSavedRecipes();
            if (saved == null) return NoContent();
            return Ok(saved);
        }

        [HttpGet("liked-recipes")]
        public IActionResult LikedRecipes()
        {
            var like = _browseServices.GetLikedRecipes();
            if (like == null) return NoContent();
            return Ok(like);
        }

        [HttpGet("recipe/{name}")]
        public IActionResult RecipeProfile(int id)
        {
            var recipe = _browseServices.GetRecipeProfile(id);
            if (recipe == null) return NotFound("Recipe does not exist");   //di ni sha NoContent kay nganu no content mn sha na ig click niya sa recipe kay dapat naa sha, it should exist
            return Ok(recipe);
        }

    }
}
