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

            string inputJson = File.ReadAllText((@"../../../Datasets/cars.json"));
            Console.WriteLine(ImportCars(dbContext, inputJson));

        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var importCarsDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            ICollection<Car> validCars = new HashSet<Car>();

            foreach (var carDto in importCarsDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                validCars.Add(car);
            }

            context.AddRange(validCars);

            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }
    }
}