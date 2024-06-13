using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.DTOs
{
    public class ApplicationUserDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
