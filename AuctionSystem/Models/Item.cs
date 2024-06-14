namespace AuctionSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double StartedPrice { get; set; }
        public double? HighestPrice { get; set; }
        public string? HighestBidder { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; } 

    }
}
