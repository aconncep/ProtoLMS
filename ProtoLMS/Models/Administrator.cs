using System.ComponentModel.DataAnnotations;

namespace ProtoLMS.Models
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
