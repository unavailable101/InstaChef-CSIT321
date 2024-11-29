using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IngredientsId { get; set; }
        
        [ForeignKey("IngredientsId")]
        public Ingredients Ingredients { get; set; } //lahi na model for the ingredients, foreign key ni sha
        
        public int CreatorId { get; set; }
        
        [ForeignKey("CreatorId")]
        public Account Creator { get; set; } //foreign key, base sa kng kinsa na user ang nag create sa recipe
    }
}
