using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
   public class ChefRecipesDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Preparation { get; set; }
        public required string CuisineType { get; set; }
        public required string MealType { get; set; }
        public required string CookingDifficulty { get; set; }
        public required int PreparationTime { get; set; }
        public required int ServingCount { get; set; }
        public int? Category { get; set; }
        public required string ImageName { get; set; }
    }
}