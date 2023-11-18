using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        
        public static void Main()
        {
            ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");

            Console.WriteLine(ImportCategories(dbContext, inputJson));
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
    }
    
}