using System.ComponentModel.DataAnnotations;

namespace SimpleApi.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public byte Age { get; set; }
    }
}