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

            string inputJson = File.ReadAllText((@"../../../Datasets/parts.json"));
            Console.WriteLine(ImportParts(dbContext, inputJson));

        }

        public static string ImportParts(CarDealerContext dbContext, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var importPartDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var dto in importPartDtos)
            {
                if (!dbContext.Suppliers.Any(s => s.Id == dto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(dto);

                validParts.Add(part);
            }

            dbContext.BulkInsert(validParts);

            return $"Successfully imported {validParts.Count}.";
        }
    }
}