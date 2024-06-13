﻿using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
