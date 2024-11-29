namespace InstaChef.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; } // eg 1 cup ganern

        //later ko ni gamiton, i think
        //public ICollection<Recipe> Recipes { get; set; }
    }
}
