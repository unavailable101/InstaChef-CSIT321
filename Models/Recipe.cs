using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Preparation { get; set; }
        public required string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public int PreparationTime { get; set; } //should be in minutes
        public int ServingCount { get; set; }
        //public int IngredientsId { get; set; }

        //[ForeignKey("IngredientsId")]
        //public Ingredient Ingredients { get; set; } //lahi na model for the ingredients, foreign key ni sha
        public required ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public int CreatorId { get; set; }
        
        [ForeignKey("CreatorId")]
        public required Account Creator { get; set; } //foreign key, base sa kng kinsa na user ang nag create sa recipe
    }
}
