using System.ComponentModel.DataAnnotations;

namespace InstaChef.Models
{
    public class Account
    {
        public int Id { get; set; }
        //public Guid Id { get; set; }
     
        public string? FirstName{ get; set; }
        
        public string? LastName{ get; set; }
        
        public required string Username{ get; set; }
        
        public required string Email { get; set; }
        
        public required string Password { get; set; }

        // 1 - active account; 0 - deactivate account
        [Range(0,1)]
        public required int Status{ get; set; }

        //dire lng ni
        //public ICollection<Recipe> Recipes { get; set; }
        public ICollection<Pantry> Pantries{ get; set; }

    }
}
