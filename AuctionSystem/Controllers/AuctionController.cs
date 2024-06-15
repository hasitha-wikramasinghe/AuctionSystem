using AuctionSystem.DTOs;
using AuctionSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Controllers
{
    public class AuctionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AuctionController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FindAsync(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult New()
        {
            var itemDto = new ItemDto();
            return View(itemDto);
        }

        [HttpGet]
        public async Task<IActionResult> BidNow(int id)
        {
            var item = _mapper.Map<ItemDto>(await _context.Items.FindAsync(id));
            return View(item);
        }

        [HttpPost]
        public async Task<ActionResult> BidNow(ItemDto itemDto)
        {
            if (itemDto.BiddingPrice > itemDto.StartedPrice 
                && itemDto.Status != "Sold")
            {
                itemDto.HighestPrice = itemDto.BiddingPrice;
                itemDto.HighestBidder = itemDto.CurrentBidder;
            }
            
            var item = _mapper.Map<Item>(itemDto);
            _context.Items.Update(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
