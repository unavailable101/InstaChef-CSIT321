using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class CreateRecipe
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public required int PreparationTime { get; set; } //should be in minutes
        public required int ServingCount { get; set; }
        public required List<IngredientDTO> Ingredients { get; set; }
    }
}
