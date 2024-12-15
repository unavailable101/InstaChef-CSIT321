using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class ChefRecipes
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set;} // Naa may description
        public required string Preparation { get; set; }// 10 min, 20, 30, 60, 90, 105, 120
        public required string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public required int PreparationTime { get; set; } //should be in minutes
        public required int ServingCount { get; set; } // 1, 2, 3, 4, 5
        public required int Category { get; set; } //Trending, Popular, New, Recommended, SavedRecipe, LikedRecipe
        public required string ImageName { get; set; }
    }
}
