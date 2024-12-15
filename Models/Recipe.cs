using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
        public required string Name { get; set; }
        //public string? StringIngredients { get; set; } // Store ingredients as a single string, e.g., "Flour,Sugar,Yeast"
        public required string Preparation { get; set; }
        public required string CuisineType { get; set; } // American, Italian, Filipino, Korean, etc.
        public required string MealType { get; set; } // Breakfast, Lunch, Dinner, Snacks
        public required string CookingDifficulty { get; set; } // Beginner, Intermediate, Difficult
        public required int PreparationTime { get; set; } // Should be in minutes
        public required int ServingCount { get; set; }
        // public int IngredientsId { get; set; }

        //[ForeignKey("IngredientsId")]
        // public Ingredient Ingredients { get; set; } // Separate model for the ingredients, foreign key

        public string? ImageName { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

        private int _creatorId = 0;
        public int CreatorId
        {
            get => _creatorId;
            set => _creatorId = value;
        }

        [ForeignKey("CreatorId")]
        public Account? Creator { get; set; } // Foreign key to the Account model (user who created the recipe)

        public DateOnly DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
