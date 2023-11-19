using AutoMapper;
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

            //category
            this.CreateMap<ImportCategoryDto, Category>();

            //categoryProduct
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
