using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
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

            string inputJson = File.ReadAllText((@"../../../Datasets/customers.json"));
            Console.WriteLine(ImportCustomers(dbContext, inputJson));

        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CamelCaseMapperConfiguration();

            var importCustomerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var dto in importCustomerDtos)
            {
                Customer customer = mapper.Map<Customer>(dto);

                validCustomers.Add(customer);
            }   

            context.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        public static IMapper CamelCaseMapperConfiguration() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}