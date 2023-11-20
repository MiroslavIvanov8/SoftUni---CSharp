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

            //string inputJson = File.ReadAllText((@"../../../Datasets/customers.json"));
            Console.WriteLine(GetLocalSuppliers(dbContext));

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
        }

        public static IMapper CamelCaseMapperConfiguration() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}