﻿using AutoMapper;
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

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForMember(dest => dest.PartsCars, opt 
                    => opt.MapFrom(src => src.PartsId.Select(partId => new PartCar { PartId = partId }))); ;

        }
    }
}
