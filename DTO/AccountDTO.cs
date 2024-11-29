using System.ComponentModel.DataAnnotations;

namespace InstaChef.DTO
{

    public class AccountDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }

        //later nani, nakoy plano ani
        //public string? ProfilePictureUrl { get; set; }

    }
}
