using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using Z.EntityFramework;

namespace ProductShop
{
    public class StartUp
    {
        
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");

            Console.WriteLine(GetProductsInRange(dbContext));
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsByRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName

                });

            return JsonConvert.SerializeObject(productsByRange,
                     Formatting.Indented,
                     new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            );
        }
    }
    
}