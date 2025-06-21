using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class About_Me
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Gmail { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string Bio { get; set; }

        // Just store file names
        public string? ImageFile { get; set; }
        public string? ResumeFile { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [NotMapped]
        public IFormFile Image { get; set; }

        [NotMapped]
        public IFormFile Resume { get; set; }
    }
}
