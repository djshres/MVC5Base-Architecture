using System.ComponentModel.DataAnnotations;

namespace MVC5Base.Entities
{
    public class User : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
