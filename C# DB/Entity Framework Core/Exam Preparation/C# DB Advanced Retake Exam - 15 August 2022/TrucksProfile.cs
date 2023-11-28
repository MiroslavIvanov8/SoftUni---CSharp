using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;

namespace Trucks
{
    using AutoMapper;

    public class TrucksProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TrucksProfile()
        {
            //Client
            /*
             this.CreateMap<ImportClientDto, Client>()
                .ForMember(d => d.ClientsTrucks, opt => 
                    opt.MapFrom(s => s.TrucksIds
                        .Select(t => new ClientTruck(){TruckId = t})
                        .Distinct()
                        .ToArray()));
            */


           this.CreateMap<ImportClientDto, Client>()
                .ForMember(dest => dest.ClientsTrucks, opt
                    => opt.MapFrom(src => src.TrucksIds));
        }
    }
}
