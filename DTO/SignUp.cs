using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class SignUp
    {
        //[Required]
        //[MaxLength(50)]
        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters.")]
        //public string FirstName { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters.")]
        //public string LastName { get; set; }
            
        //[MaxLength(50)]
        public required string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }

        //[PasswordPropertyText]
        //might be useful
        //[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public required string Password { get; set; }

    }
}
