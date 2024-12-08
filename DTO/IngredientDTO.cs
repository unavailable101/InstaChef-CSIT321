namespace InstaChef.DTO
{
    public class IngredientDTO
    {
        public required string Name { get; set; }
        public required string Category { get; set; }
        public required double Quantity { get; set; } // eg 1 cup, 1 liter
        public string? Unit { get; set; }
    }
}
