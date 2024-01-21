﻿
using Newtonsoft.Json;

namespace MVCIntroDemo.Controllers
{
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Product;
    
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>
        {
            new ProductViewModel
            {
                Id = 1,
                Name = "Cheese",
                Price = 7.00
            },
            new ProductViewModel
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel
            {
                Id = 3,
                Name = "Bread",
                Price = 1.50
            }
        };

        public IActionResult ById(int Id)
        {
            ProductViewModel? model = products.FirstOrDefault(p => p.Id == Id);
            if (model == null)
            {
                return RedirectToAction("All");
            }

            return View(model);
        }

        public IActionResult AllAsJson()
        {
            return Json(products, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public IActionResult All()
        {
            return View(products);
        }
    }
}
