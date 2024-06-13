using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.Models
{
    public class ApplicationUserDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
