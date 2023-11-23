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
            Console.WriteLine(GetSalesWithAppliedDiscount(dbContext));

        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = ((s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100))).ToString("f2")
                })
                .ToArray();

            
            return JsonConvert.SerializeObject(sales, Formatting.Indented);
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