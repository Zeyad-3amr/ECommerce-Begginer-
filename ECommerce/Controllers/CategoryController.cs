using ECommerce.Data;
using ECommerce.DTOs;
using ECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CategoryController(ApplicationDbContext context) : BaseApiController
    {

        [HttpPost("create-category")]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
            {
                return BadRequest("Brand Name Required!");
            }



            var category = new Category
            {
                Name = createCategoryDto.Name

            };

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            // Return the newly created brand details
            return Ok(new
            {
                category.Name
            });

        }

    }
}
