using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {

            //user
            this.CreateMap<ImportUserDto, User>();

            //product
            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.ProductSeller,
                    opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //category
            this.CreateMap<ImportCategoryDto, Category>();

            //categoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
