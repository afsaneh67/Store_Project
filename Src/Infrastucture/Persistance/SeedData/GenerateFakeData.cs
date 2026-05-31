using Domain.Entities.Identity;
using Domain.Entities.Product;
using Infrastucture.Persistance.Configurations;
using Infrastucture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Persistance.SeedData
{
    public class GenerateFakeData
    {
        public static async Task SeedDataAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {

                if (!await context.productTypes.AnyAsync())
                {
                    var productt = new List<ProductType>()
                    {
                        new() { Description="dest1",Title="type1",Summary="summaryt1" },
                        new() { Description="dest2",Title="type2",Summary="summaryt2"}
                    };
                    await context.productTypes.AddRangeAsync(productt);
                    context.SaveChanges();
                }

                if (!await context.productBrands.AnyAsync())
                {
                    var productb = new List<ProductBrand>()
                    {
                        new() { Description="desb1",Title="brand1",Summary="summaryb1" },
                        new() { Description="desb2",Title="brand2",Summary="summaryb2"}
                    };
                    await context.productBrands.AddRangeAsync(productb);
                    context.SaveChanges();
                }

                if (!await context.Products.AnyAsync())
                {
                    var products = new List<Product>()
                    {
                        new() { Description="desc1",PictureUrl="url1",Price=15000,Title="title1",Summary="summary1",BrandId=1,TypeId=1 },
                        new() { Description="desc2",PictureUrl="url2",Price=16000,Title="title2",Summary="summary2" ,BrandId=1,TypeId=1},
                        new() { Description="desc3",PictureUrl="url3",Price=17000,Title="title3",Summary="summary3",BrandId=2,TypeId=2 },
                        new() { Description="desc4",PictureUrl="url4",Price=18000,Title="title4",Summary="summary4" ,BrandId=2,TypeId=2 },
                    };
                    await context.Products.AddRangeAsync(products);
                    context.SaveChanges();
                }

                if (!await context.Role.AnyAsync())
                {
                    var roles1 = new List<Role>()
                    {
                        new() { Id="1",Name="Admin",NormalizedName="Admin",ConcurrencyStamp="Admin"},
                        new() { Id="2",Name="User",NormalizedName="User",ConcurrencyStamp="User"},
                    };
                    await context.Role.AddRangeAsync(roles1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<GenerateFakeData>();
                logger.LogError(ex, "error in seed data");
            }
        }
    }
}
