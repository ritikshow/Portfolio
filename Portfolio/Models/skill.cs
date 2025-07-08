using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class skill
    {
        [Key]
        public int id { get; set; }   
        [Required]
        public string skills { get; set; } 
    }
}
