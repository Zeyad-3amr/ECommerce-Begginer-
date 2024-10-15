using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs
{
    public class BrandDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}
