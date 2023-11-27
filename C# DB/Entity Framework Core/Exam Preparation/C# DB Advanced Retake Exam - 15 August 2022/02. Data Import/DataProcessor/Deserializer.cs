using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Utilities;

    
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        private static XmlHelper xmlHelper;

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();

            StringBuilder sb = new StringBuilder();
            ImportDespetcherDto[] despetcherDtos =
                xmlHelper.Deserialize<ImportDespetcherDto[]>(xmlString, "Despatchers");

            ICollection<Despatcher> validDespatchers = new HashSet<Despatcher>();

            foreach (var despatcherDto in despetcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Truck> validTrucks = new HashSet<Truck>();
                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };
                    validTrucks.Add(truck);
                    
                }
                
                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = validTrucks
                };

                validDespatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher,despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
            
            ICollection<Client> validClients = new HashSet<Client>();
            
            int[] existingTrucksIds = context.Trucks
                .Select(t => t.Id)
                .ToArray();
            
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            
                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
            
                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };
            
                
            
                foreach (var truckId in clientDto.TrucksIds.Distinct())
                {
                    if (!existingTrucksIds.Contains(truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
            
                    ClientTruck ct = new ClientTruck()
                    {
                        ClientId = client.Id,
                        TruckId = truckId,
                    };
            
                    client.ClientsTrucks.Add(ct);
            
                }   
            
                validClients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }
            
            context.AddRange(validClients);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();

          //StringBuilder sb = new StringBuilder();
          //IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
          //    cfg.AddProfile<TrucksProfile>()));
          //
          //ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);
          //int[] existingTrucksIds = context
          //    .Trucks
          //    .Select(t => t.Id)
          //    .ToArray();
          //
          //
          //ICollection<Client> validClients = new HashSet<Client>(); 
          //foreach (var clientDto in clientDtos)
          //{
          //    if (!IsValid(clientDto))
          //    {
          //        sb.AppendLine(ErrorMessage);
          //        continue;   
          //    }
          //
          //    if (clientDto.Type == "usual")
          //    {
          //        sb.AppendLine(ErrorMessage);
          //        continue;
          //    }
          //
          //    Client client = mapper.Map<Client>(clientDto);
          //
          //    validClients.Add(client);
          //    sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
          //}   
          //
          //context.AddRange(validClients);
          //context.SaveChanges();
          //
          //return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}