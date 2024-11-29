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

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        //might be useful
        //[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

    }
}
