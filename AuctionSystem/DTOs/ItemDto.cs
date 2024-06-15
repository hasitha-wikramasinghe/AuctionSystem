using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double StartedPrice { get; set; }
        public double? HighestPrice { get; set; }
        public string? HighestBidder { get; set; } 
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Additional fields just for UI and some business logics
        public string? CurrentBidder { get; set; }
        public double? BiddingPrice { get; set; }
    }
}
