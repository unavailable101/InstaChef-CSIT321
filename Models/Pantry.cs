using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Pantry
    {
        //list of all ingredients available sa user/account
        // that's why usa ra ang account but gi list ang ingredients
        public int Id { get; set; }
        public required int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public ICollection<Ingredient>? Ingredients { get; set; }
        //public List<Ingredient> Ingredients { get; set; }
    }
}
