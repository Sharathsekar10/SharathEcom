using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.SeedData
{
    public class SeedAppDbContext
    {
        public static async Task SeedProductAsync(AppDbContext context, ILoggerFactory loggerFractory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var brand in productBrands)
                    {
                         context.ProductBrands.Add(brand);

                    }

                    await context.SaveChangesAsync();
                }
                
                if(!context.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    foreach(var item in productTypes)
                    {
                        await context.ProductTypes.AddAsync(item);

                    }

                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any())
                {
                    var ProductData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                    foreach(var item in products)
                    {
                        await context.Products.AddAsync(item);

                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
              var logger = loggerFractory.CreateLogger<ILogger>();
              logger.LogError(ex, "An error occured while seeding Product data to database");
            }
        } 
    }
    
        
    
}