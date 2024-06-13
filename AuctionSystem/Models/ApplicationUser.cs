using Microsoft.AspNetCore.Identity;

namespace AuctionSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
    }
}
