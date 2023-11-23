using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>();

            //Cars
            /*this.CreateMap<ImportCarDto, Car>()
                .ForMember(d => d.PartsCars, opt => 
                    opt.MapFrom(s => s.Parts
                       .Select(p => new PartCar(){ PartId = p.PartId})));*/

            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

            this.CreateMap<Car, ExportCarDto>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
