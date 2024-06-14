using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using AuctionSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuctionSystem.Data
{
    public static class Seed
    {
        public static async Task SeedRolesAsync(
            RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            string[] roleNames = { "SuperAdmin", "AuctionManager", "Bidder", "Seller" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        // _logger.LogError($"Unable to create role: {result.Errors}");
                    }
                }
            }
        }
    }
}
