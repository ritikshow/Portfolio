using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Contanct
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Email { get; set; }

        public string discription { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false; // Indicates if the contact message has been read
        



    }
}
