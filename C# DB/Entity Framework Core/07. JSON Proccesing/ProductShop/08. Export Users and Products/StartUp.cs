using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

            Console.WriteLine(GetUsersWithProducts(dbContext));
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            var categoriesByProductCount = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .ProjectTo<ExportCategoriesByProductCountDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(categoriesByProductCount,
                Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    //UserDto
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        //ProductWrapperDto
                        Count = u.ProductsSold.Count(p=> p.Buyer != null),
                        Products = u.ProductsSold.Where(p => p.Buyer != null)
                            .Select(p => new
                        {
                            //ProductDto
                            p.Name,
                            p.Price
                        })
                            .ToArray()

                    }
                }).OrderByDescending(u=> u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray() ;

            //Final 4th wrapperDto, notice how we use and anonymous object
            //and put the whole usersObj with nested Dtos in last wrapperDto

            var usersWithProducts = new
            {
                UsersCount = users.Length,
                Users = users,
            };

                  return JsonConvert.SerializeObject(usersWithProducts,
                      Formatting.Indented,
                      new JsonSerializerSettings
                      {
                          ContractResolver = new CamelCasePropertyNamesContractResolver(),
                          NullValueHandling = NullValueHandling.Ignore
                      });

        }
    } 
    
}