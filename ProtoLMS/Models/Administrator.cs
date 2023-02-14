using System.ComponentModel.DataAnnotations;

namespace ProtoLMS.Models
{
    public class Administrator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Organization Organization { get; set; }

    }
}
