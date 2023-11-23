using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using Z.BulkOperations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureCreated();

            string inputJson = File.ReadAllText((@"../../../Datasets/sales.json"));
            Console.WriteLine(ImportSales(dbContext, inputJson));

        }
        
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CamelCaseMapperConfiguration();

            var importSaleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            ICollection<Sale> validSales = new HashSet<Sale>();

            foreach (var dto in importSaleDtos)
            {
                Sale sale = mapper.Map<Sale>(dto);

                validSales.Add(sale);
            }

            context.AddRange(validSales);

            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        public static IMapper CamelCaseMapperConfiguration() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}