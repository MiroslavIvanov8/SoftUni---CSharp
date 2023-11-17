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

            string inputJson = File.ReadAllText(@"../../../Datasets/users.json");

            Console.WriteLine(ImportUsers(dbContext, inputJson));
        }
         
        public static string ImportUsers(ProductShopContext dbContext, string inputJson)
        {
            // we create mapper and add specified profile to configure map options
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            //deserialize json file and create dto[] from it
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            //fill this collection
            ICollection<User> validUsers = new HashSet<User>();
            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            // model collection is ready for the db 

            dbContext.AddRange(validUsers);

            dbContext.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }
    }
    
}