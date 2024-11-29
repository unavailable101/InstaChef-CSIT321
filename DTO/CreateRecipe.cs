using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class CreateRecipe
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CuisineType { get; set; } //American, Italian, Filipino, Korean, diha ra taman, ayna dungagi
        
        [Required] 
        public string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        
        [Required] 
        public string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        
        [Required] 
        public int PreparationTime { get; set; } //should be in minutes
        
        [Required] 
        public int ServingCount { get; set; }

        [Required]
        public List<IngredientDTO> Ingredients { get; set; }
    }

    public class IngredientDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; } // eg 1 cup, 1 liter
    }
}
