using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class SearchChefRecipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Preparation { get; set; }
        public string CuisineType { get; set; }
        public string MealType { get; set; }
        public string CookingDifficulty { get; set; }
        public string PreparationTime { get; set; }
        public int ServingCount { get; set; }
        public string ImageName { get; set; }
        public string Ingredients { get; set; }
    }
}
