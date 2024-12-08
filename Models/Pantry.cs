using InstaChef.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Pantry
    {
        // later nani nako problemahon
        // list of all ingredients available sa user/account
        // that's why usa ra ang account but gi list ang ingredients
        public int Id { get; set; }
        public required int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }
        public required int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        //public List<Ingredient> Ingredients { get; set; }

        //The use of ICollection<Ingredient> for Ingredients is problematic because it implies multiple ingredients per pantry record. This seems incorrect for a "user pantry" entity.
        //If Ingredients should be a list, you need a separate linking table or navigation logic.
    }
}
