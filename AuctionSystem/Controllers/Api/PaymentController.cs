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
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:ApiKey"];
        }

        [HttpPost("charge")]
        public IActionResult Charge([FromBody]PaymentDetails paymentDetails)
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

                return Ok(charge);
            }
            catch (Exception ex)
            {
                return BadRequest($"Payment failed: {ex.Message}");
            }
        }
    }
}
