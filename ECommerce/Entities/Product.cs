using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; } = 0;

        public int BrandId { get; set; } // Foreign key to the Brand entity
        public Brand Brand { get; set; } // Navigation property to the Brand


    }
}
