using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string subTitle { get; set; }
        public string Description { get; set; }
        public string? Websitelink { get; set; }
        public string? PLogo { get; set; }
        public string? githublink { get; set; }
        public string? reportP { get; set; }
        public string? ProjectType { get; set; } // e.g., Web Development, Mobile App, etc.
        public bool? IsRecent { get; set; }// Indicates if the project is recent

        [NotMapped]
        public IFormFile? Logo { get; set; }

        [NotMapped]
        public IFormFile? report { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;


    }
}
