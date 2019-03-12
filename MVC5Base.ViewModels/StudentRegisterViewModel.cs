using System.ComponentModel.DataAnnotations;

namespace MVC5Base.ViewModels
{
    public class StudentRegisterViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Student name is required.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Student address is required.")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Student age is required.")]
        [Display(Name = "Age")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 - 150.")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password should be confirmed.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
