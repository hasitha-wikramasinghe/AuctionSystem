using AuctionSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace AuctionSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public PaymentController(
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:ApiKey"];
            _context = context;
        }

        [HttpPost("charge")]
        public async Task<IActionResult> Charge([FromBody]PaymentDetails paymentDetails)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(paymentDetails.Amount * 100), 
                    Currency = paymentDetails.Currency,
                    Source = paymentDetails.TokenId, 
                    Description = paymentDetails.Description
                };

                var service = new ChargeService();
                var charge = service.Create(options);

                var item = await _context.Items.FindAsync(paymentDetails.Id);
                if (item != null)
                {
                    item.Status = "Sold";
                    item.HighestPrice = paymentDetails.Amount;
                    item.HighestBidder = paymentDetails.BidderName;
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                }

                return Ok(charge);
            }
            catch (Exception ex)
            {
                return BadRequest($"Payment failed: {ex.Message}");
            }
        }
    }
}
