using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
    }
}
