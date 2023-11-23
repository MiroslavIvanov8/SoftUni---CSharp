using System.IO;
using System.Linq.Expressions;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using ProductShop.Utilities;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            Console.WriteLine(ImportCars(dbContext, inputXml));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] importSupplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            
            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supplierDto in importSupplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue; 
                }

                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] importPartDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts =  new HashSet<Part>();

            foreach (var partDto in importPartDtos)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part = mapper.Map<Part>(partDto);

                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carsDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (ImportCarDto carDto in carsDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                
                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        PartId = partDto.PartId
                    };

                    car.PartsCars.Add(partCar); 
                }

                validCars.Add(car);

            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        private static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}