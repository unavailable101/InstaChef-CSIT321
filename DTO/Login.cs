using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{
    public class Login
    {
        public required string Username { get; set; }

        [PasswordPropertyText]
        public required string Password { get; set; }
    }
}
