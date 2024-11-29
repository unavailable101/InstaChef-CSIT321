using System.ComponentModel.DataAnnotations;

namespace InstaChef.Models
{
    public class Account
    {
        public int Id { get; set; }
     
        public string FirstName{ get; set; }
        
        public string LastName{ get; set; }
        
        [Required]
        public string Username{ get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        // 1 - active account; 0 - deactivate account
        [Required]
        [Range(0,1)]
        public int Status{ get; set; }

        //dire lng ni
        //public ICollection<Recipe> Recipes { get; set; }

    }
}
