using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BeeFC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
