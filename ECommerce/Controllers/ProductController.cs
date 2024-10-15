using ECommerce.Data;
using ECommerce.DTOs;
using ECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ECommerce.Controllers
{

    public class ProductController(ApplicationDbContext context) : BaseApiController
    {

        // CREATING PRODUCT IN THE DATABASE
        [HttpPost("create-product")]
        public async Task<ActionResult<CreateProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return BadRequest("Product data is required !");
            }

            var brand = await context.Brands
        .FirstOrDefaultAsync(b => b.Name.ToLower() == createProductDto.BrandName.ToLower());

            if (brand == null)
            {
                return BadRequest("Invalid Brand Name.");
            }


            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Description = createProductDto?.Description,
                BrandId = brand.Id,
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                Brand = brand.Name
            });
        }

        // EDITING PRODUCTS
        [HttpPut("edit-product/{id}")]
        public async Task<ActionResult<UpdateProductDto>> EditProduct(int id, UpdateProductDto updateProductDto)
        {

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }


            var brand = await context.Brands
                .FirstOrDefaultAsync(b => b.Name.ToLower() == updateProductDto.BrandName.ToLower());

            if (brand == null)
            {
                return BadRequest("Invalid Brand Name.");
            }


            product.Name = updateProductDto.Name ?? product.Name;
            product.Price = updateProductDto.Price != 0 ? updateProductDto.Price : product.Price;
            product.Description = updateProductDto.Description ?? product.Description;
            product.BrandId = brand.Id;


            context.Products.Update(product);
            await context.SaveChangesAsync();

            return Ok(product);
        }


        // DELETING PRODUCT FROM THE DATABASE

        [HttpPost("delete-product/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return Ok("Product deleted successfully.");
        }

        // GETTING PRODUCT FROM THE DATABASE
        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<CreateProductDto>> GetProduct(int id)
        {
            var product = await context.Products
                .Include(p => p.Brand)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            var productDto = new CreateProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                BrandName = product.Brand?.Name
            };

            return Ok(productDto);
        }
    }
}

