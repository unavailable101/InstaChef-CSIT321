namespace InstaChef.DTO
{
    public class RecipeProfile
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Preparation { get; set; }
        public required int PreparationTime { get; set; }
        public List<IngredientDTO> Ingredients { get; set; } = new();
        public string? ChefUsername { get; set; }
    }
}
