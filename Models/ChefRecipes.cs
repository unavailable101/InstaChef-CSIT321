using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class ChefRecipes
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set;} 
        public required string Preparation { get; set; }// 10 min, 20, 30, 60, 90, 105, 120
        public required string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public required int PreparationTime { get; set; } //should be in minutes
        public required int ServingCount { get; set; } // 1, 2, 3, 4, 5
        public required int Category { get; set; } //Trending, Popular, New, Recommended, SavedRecipe, LikedRecipe
        //public int IngredientsId { get; set; }

        //[ForeignKey("IngredientsId")]
        //public Ingredient Ingredients { get; set; } //lahi na model for the ingredients, foreign key ni sha
        // public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        // public required int CreatorId { get; set; }
        
        // [ForeignKey("CreatorId")]
        // public Account? Creator { get; set; } //foreign key, base sa kng kinsa na user ang nag create sa recipe
        // public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
