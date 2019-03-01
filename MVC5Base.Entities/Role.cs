using System.ComponentModel.DataAnnotations;
namespace MVC5Base.Entities
{
    public class Role : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
