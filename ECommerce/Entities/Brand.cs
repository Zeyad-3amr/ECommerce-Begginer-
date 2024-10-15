using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
