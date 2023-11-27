using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Collections.Generic;
using System;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContex = new ProductShopContext();

            //dbContex.Database.EnsureDeleted();
            //dbContex.Database.EnsureCreated();

            //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
            
            Console.WriteLine(GetSoldProducts(dbContex));
        }

        //p01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDto[] userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var Dto in userDtos)
            {
                var user = mapper.Map<User>(Dto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //p02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
            ICollection<Product> validProducts = new HashSet<Product>();

            foreach (var productDto in productDtos)
            {
                Product product = mapper.Map<Product>(productDto);

                validProducts.Add(product);
            }

            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //P03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoriesDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var dto in categoriesDtos)
            {
                if (dto.Name.IsNullOrEmpty())
                {
                    continue;
                }

                Category category = mapper.Map<Category>(dto);

                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);

            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //p04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = CreateMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryProductDto[] categoryProductDtos =
                xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> validCategories = new HashSet<CategoryProduct>();

            foreach (var dto in categoryProductDtos)
            {
                if (!context.Categories.Any(c => c.Id == dto.CategoryId) ||
                    !context.Products.Any(p => p.Id == dto.ProductId))
                {
                    continue;
                }

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(dto);

                validCategories.Add(categoryProduct);
            }

            context.AddRange(validCategories);

            context.SaveChanges();

           return $"Successfully imported {validCategories.Count}";
        }

        //p06
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportUserDto[] usersWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductsSold = u.ProductsSold.Select(p => new ExportProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    }).ToArray()
                }).ToArray();

            return xmlHelper.Serialize(usersWithSoldProducts, "Users");
        }

        public static IMapper CreateMapper() => new Mapper(new MapperConfiguration(cfg =>
            cfg.AddProfile<ProductShopProfile>()));
    }
}