using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }

        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public Ingredient? Ingredient { get; set; }
        
        public double Quantity { get; set; }
        public string? Unit { get; set; }
    }
}
