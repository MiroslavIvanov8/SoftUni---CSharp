using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Z.BulkOperations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new CarDealerContext();
            //dbContex.Database.EnsureCreated();

            string inputJson = File.ReadAllText((@"../../../Datasets/suppliers.json"));
            Console.WriteLine(ImportSuppliers(dbContext, inputJson));

        }

        public static string ImportSuppliers(CarDealerContext dbContext, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var importSuppliersDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

            ICollection<Supplier> validDtos = new HashSet<Supplier>();

            foreach (var dto in importSuppliersDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(dto);

                validDtos.Add(supplier);
            }

            dbContext.BulkInsert(validDtos);

            return $"Successfully imported {validDtos.Count}.";
        }
    }
}