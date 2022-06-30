using System.ComponentModel.DataAnnotations;

namespace ZavrsniTest.Models.DTO
{
    public class RegistrationDTO
    {

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }


    }
}
