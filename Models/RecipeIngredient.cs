using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class RecipeIngredient
    {
        //public int Id { get; set; }

        public Guid Id { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public required Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public required Ingredient Ingredient { get; set; }
    }
}
