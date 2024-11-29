using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        public string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public int PreparationTime { get; set; } //should be in minutes
        public int ServingCount { get; set; }
        public int IngredientsId { get; set; }
        
        [ForeignKey("IngredientsId")]
        public Ingredients Ingredients { get; set; } //lahi na model for the ingredients, foreign key ni sha
        
        public int CreatorId { get; set; }
        
        [ForeignKey("CreatorId")]
        public Account Creator { get; set; } //foreign key, base sa kng kinsa na user ang nag create sa recipe
    }
}
