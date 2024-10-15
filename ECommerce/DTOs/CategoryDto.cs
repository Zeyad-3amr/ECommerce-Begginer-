using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
