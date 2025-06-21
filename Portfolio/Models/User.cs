using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

}
