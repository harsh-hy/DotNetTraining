using System.ComponentModel.DataAnnotations;

namespace IdentityService.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}