using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Serialization;
using Z.BulkOperations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureCreated();

            //string inputJson = File.ReadAllText((@"../../../Datasets/sales.json"));
            Console.WriteLine(GetTotalSalesByCustomer(dbContext));

        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CamelCaseMapperConfiguration();

            var importSaleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> validSales = new HashSet<Sale>();

            foreach (var dto in importSaleDtos)
            {
                if (!context.Customers.Any(c => c.Id == dto.CustomerId))
                    continue;
                Sale sale = mapper.Map<Sale>(dto);

                validSales.Add(sale);
            }

            context.AddRange(validSales);

            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = 
                    c.Sales.SelectMany(s => s.Car.PartsCars
                            .Select(pc => pc.Part.Price))
                            .Sum()
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars);

            ;
            return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        public static IMapper CamelCaseMapperConfiguration() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}