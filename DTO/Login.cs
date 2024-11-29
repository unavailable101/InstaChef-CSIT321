using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
