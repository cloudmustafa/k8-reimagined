using System.ComponentModel.DataAnnotations;

namespace SimpleApi.Domain.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string title { get; set; }

        [Required]
        public int state { get; set; }


        [Required]
        public int severity { get; set; }

        [Required]
        public int reportedby { get; set; }
    }
}