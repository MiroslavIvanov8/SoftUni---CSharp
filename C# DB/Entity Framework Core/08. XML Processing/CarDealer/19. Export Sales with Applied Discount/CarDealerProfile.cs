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

            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartsCount, opt =>
                    opt.MapFrom(s => s.Parts.Count));

            //Part
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<Part, ExportPartDto>();


            //Cars
            /*this.CreateMap<ImportCarDto, Car>()
                .ForMember(d => d.PartsCars, opt => 
                    opt.MapFrom(s => s.Parts
                       .Select(p => new PartCar(){ PartId = p.PartId})));*/

            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportCarAttributeDto>();

            
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, opt => 
                    opt.MapFrom(s => s.PartsCars.Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .ToArray()));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerWithSales>()
                .ForMember(d => d.BoughtCars, opt =>
                    opt.MapFrom(s => s.Sales.Count));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
