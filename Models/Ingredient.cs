namespace InstaChef.Models
{
    public class Ingredient
    {
        //public int Id { get; set; }
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Quantity { get; set; } // eg 1 cup ganern

        //later ko ni gamiton, i think
        //public ICollection<Recipe> Recipes { get; set; }
        public required ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
