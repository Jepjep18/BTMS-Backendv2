using System.ComponentModel.DataAnnotations;

namespace api.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }  // Ensure this matches the type expected
        public string Username { get; set; }
        public string BusinessUnit { get; set; }
        public string Password { get; set; }
    }

}
