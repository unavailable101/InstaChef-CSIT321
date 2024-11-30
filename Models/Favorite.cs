using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Favorite
    {
        //public int Id { get; set; }
        public Guid Id { get; set; }
        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public required Recipe FavoriteRecipe{ get; set; }

        public int AccountID { get; set; }

        [ForeignKey("AccountID")]
        public required Account CurrentAccount { get; set; }
    }
}
