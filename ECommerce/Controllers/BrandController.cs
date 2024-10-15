using ECommerce.Data;
using ECommerce.DTOs;
using ECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class BrandController(ApplicationDbContext context) : BaseApiController
    {
        [HttpPost("create-brand")]
        public async Task<ActionResult<BrandDto>> CreateBrand(BrandDto createBrandDto)
        {
            if (createBrandDto == null)
            {
                return BadRequest("Brand Name Required!");
            }

            var category = await context.Categories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == createBrandDto.CategoryName.ToLower());
            Console.WriteLine(category.Name);
            if (category == null)
            {
                return BadRequest("Invalid Category Name. The category must already exist.");
            }

            var brand = new Brand
            {
                Name = createBrandDto.Name,
                CategoryId = category.Id

            };

            context.Brands.Add(brand);
            await context.SaveChangesAsync();


            return Ok(brand);

        }
    }
}
