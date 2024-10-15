using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
