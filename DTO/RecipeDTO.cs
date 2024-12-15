using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class RecipeDTO  //para ni sa edit and create recipe
    {
        public required string Name { get; set; }
        //public required string StringIngredients { get; set; }
        public required string Preparation { get; set; }
        public required string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public required int PreparationTime { get; set; } //should be in minutes
        public required int ServingCount { get; set; }
        public required List<IngredientDTO> Ingredients { get; set; }
    }
}
