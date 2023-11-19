using AutoMapper;
using Newtonsoft.Json;
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

            string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");

            Console.WriteLine(ImportCategoryProducts(dbContext, inputJson));
        }

        public static string ImportCategories(ProductShopContext dbContext, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson)
                .Where(c => c.Name !=null).ToArray();

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var dto in categoryDtos)
            {
                Category category = mapper.Map<Category>(dto);

                validCategories.Add(category);
            }

            dbContext.AddRange(validCategories);

            dbContext.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(dto);

                validCategoryProducts.Add(categoryProduct);
            }

            context.BulkInsert(validCategoryProducts);


            return $"Successfully imported {validCategoryProducts.Count}";
        }
    }
    
}