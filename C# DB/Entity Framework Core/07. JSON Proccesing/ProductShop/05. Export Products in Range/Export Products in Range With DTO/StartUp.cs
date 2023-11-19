using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
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
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
                
            }));

            ExportProductInRangeDto[] productsByRangeDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();
          
          return JsonConvert.SerializeObject(productsByRangeDtos,
                   Formatting.Indented,
                   new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
          );
        }
    }
    
}