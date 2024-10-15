using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class DataSeeding
    {
        public static async Task Seed(ApplicationDbContext context)
        {
            // Ensure the database is created
            await context.Database.MigrateAsync();

            // Seed Categories if none exist
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Clothes" },
                    new Category { Name = "Electronics" },
                    new Category { Name = "Home Appliances" },
                    new Category { Name = "Books" },
                    new Category { Name = "Sports" }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            // Seed Brands if none exist
            if (!context.Brands.Any())
            {
                var brand1 = context.Categories.FirstOrDefault(c => c.Name == "Clothes");
                var brand2 = context.Categories.FirstOrDefault(c => c.Name == "Electronics");

                var brands = new List<Brand>
                {
                    new Brand { Name = "Nike", CategoryId = brand1.Id },
                    new Brand { Name = "Adidas", CategoryId = brand1.Id },
                    new Brand { Name = "Sony", CategoryId = brand2.Id },
                    new Brand { Name = "Samsung", CategoryId = brand2.Id }
                };

                context.Brands.AddRange(brands);
                await context.SaveChangesAsync();
            }

            // Seed Products if none exist
            if (!context.Products.Any())
            {
                var brand1 = context.Brands.FirstOrDefault(b => b.Name == "Nike");
                var brand2 = context.Brands.FirstOrDefault(b => b.Name == "Sony");

                var products = new List<Product>
                {
                    new Product { Name = "Nike Running Shoes", Description = "Comfortable running shoes.", Price = 100, BrandId = brand1.Id },
                    new Product { Name = "Sony Headphones", Description = "High-quality sound.", Price = 150, BrandId = brand2.Id }
                };

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
