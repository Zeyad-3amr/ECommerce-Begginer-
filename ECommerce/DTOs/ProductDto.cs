using System.ComponentModel.DataAnnotations;

namespace ECommerce.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        [Required]
        public string BrandName { get; set; }

    }
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }


        public string BrandName { get; set; }
    }

}
