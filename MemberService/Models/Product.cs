using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberService.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}