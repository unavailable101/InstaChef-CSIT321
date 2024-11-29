using System.ComponentModel.DataAnnotations.Schema;

namespace InstaChef.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public Recipe FavoriteRecipe{ get; set; }

        public int AccountID { get; set; }

        [ForeignKey("AccountID")]
        public Account CurrentAccount { get; set; }
    }
}
