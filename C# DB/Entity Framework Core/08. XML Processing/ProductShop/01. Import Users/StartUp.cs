using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContex = new ProductShopContext();

            string inputXml = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(dbContex, inputXml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDto[] userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var Dto in userDtos)
            {
                var user = mapper.Map<User>(Dto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));
    }
}