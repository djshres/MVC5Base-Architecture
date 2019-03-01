using System.ComponentModel.DataAnnotations;

namespace MVC5Base.Entities
{
    public class Student : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        public int Age { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
