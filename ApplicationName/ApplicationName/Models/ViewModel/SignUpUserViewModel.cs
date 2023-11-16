using System.ComponentModel.DataAnnotations;

namespace ApplicationName.Models.ViewModel
{
    public class SignUpUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        //  [RegularExpression(@"/ ^([a - zA - Z0 - 9._ % -] +@[a - zA - Z0 - 9.-] +\.[a - zA - Z]{2,})$/")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile")]
        //  [RegularExpression(@"/^(\+\d{1,3}[- ]?)?\d{10}$/")]

        public long? Mobile { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter confirmpassword")]
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }
    }
}
