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
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IMapper _mapper;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("New")]
        public async Task<ActionResult> PostApplicationUser(ApplicationUserDto applicationUserDto)
        {
            if (applicationUserDto.Password is null)
            {
                return BadRequest("Password is required for create a new user");
            }

            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserDto);

            var result = await _userManager.CreateAsync(applicationUser, applicationUserDto.Password);

            if (applicationUserDto.Role is not null)
            {
                await _userManager.AddToRoleAsync(applicationUser, applicationUserDto.Role);
            }

            if (result.Succeeded)
            {
                return Ok($"Created new user with email - {applicationUserDto.Email}");
            }

            return StatusCode(500, new { message = "Something went wrong, please try again later" });
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> UpdateApplicationUser(ApplicationUserDto applicationUserDto)
        {
            if (applicationUserDto.Email is null)
            {
                return BadRequest("Email is required to perform update operation");
            }

            var applicationUser = await _userManager.FindByEmailAsync(applicationUserDto.Email);

            if (applicationUser is null ) 
            {
                return NotFound($"No user found for email - {applicationUserDto.Email}");
            }

            _mapper.Map(applicationUserDto, applicationUser);
            await _userManager.UpdateAsync(applicationUser);
            return NoContent();
        }

        [HttpGet]
        [Route("ByEmail")]
        public async Task<ActionResult<ApplicationUserDto>> GetApplicationUserByEmail(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            if (applicationUser is null)
            {
                return NotFound($"No user found for email - {email}");
            }

            return Ok(_mapper.Map<ApplicationUserDto>(applicationUser));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeleteApplicationUser(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            if (applicationUser is null)
            {
                return NotFound($"No user found for email - {email}");
            }

            await _userManager.DeleteAsync(applicationUser);
            return NoContent(); 
        }

    }
}
