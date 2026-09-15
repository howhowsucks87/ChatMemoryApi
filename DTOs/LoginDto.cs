using System.ComponentModel.DataAnnotations;

namespace ChatMemoryApi.DTOs
{
    public class LoginDto
    {
        // ----------------------------------------------------------
        // Email
        // ----------------------------------------------------------
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = null!;


        // ----------------------------------------------------------
        // Password
        // ----------------------------------------------------------
        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}