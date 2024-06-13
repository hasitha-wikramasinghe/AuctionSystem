using AuctionSystem.DTOs;
using AuctionSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ItemController(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> PostItem(ItemDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item.Id);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateItem(ItemDto itemDto)
        {
            if (itemDto.Id == 0)
            {
                return BadRequest("Item's id is required to perform update operation");
            }

            var item = await _context.Items.FindAsync(itemDto.Id);

            if (item is null)
            {
                return NotFound($"No item found for id - {itemDto.Id}");
            }

            var updatedItem = _mapper.Map(itemDto, item);
            _context.Items.Update(updatedItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApplicationUserDto>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item is null)
            {
                return NotFound($"No item found for id - {id}");
            }

            return Ok(_mapper.Map<ItemDto>(item));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ItemDto>> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item is null)
            {
                return NotFound($"No item found for id - {id}");
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
