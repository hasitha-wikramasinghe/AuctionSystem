namespace AuctionSystem.Models
{
    public class PaymentDetails
    {
        public string TokenId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }
}
