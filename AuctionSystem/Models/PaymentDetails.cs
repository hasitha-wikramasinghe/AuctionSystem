namespace AuctionSystem.Models
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public string TokenId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string BidderName { get; set; }
    }
}
