using System.ComponentModel.DataAnnotations;

namespace MVC5Base.ViewModels
{
    public class StudentViewModel : BaseViewModel
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

        public int UserId { get; set; }

        public UserViewModel User { get; set; }
    }
}
