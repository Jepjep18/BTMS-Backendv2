using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }  
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}$", ErrorMessage = "Username must be in the format 000-000.")]
        public string Username { get; set; }
        [Required]
        public string BusinessUnit { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
