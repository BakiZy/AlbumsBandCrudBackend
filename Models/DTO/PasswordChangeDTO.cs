using System.ComponentModel.DataAnnotations;

namespace ZavrsniTest.Models.DTO
{
    public class PasswordChangeDTO
    {

        [Required(ErrorMessage = "username required")]

        public string Username  { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "new Password is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "confirm password must be equald to new password")]
        public string ConfirmPassword { get; set; }











    }
}
