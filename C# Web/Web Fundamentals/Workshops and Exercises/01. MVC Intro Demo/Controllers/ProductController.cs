
using System.Text;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Net.Http.Headers;
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
        public IActionResult All(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return View(products); 
            }

            ICollection<ProductViewModel> productsAfterSearch = products
                .Where(p => p.Name.ToLower().Contains(keyword))
                .ToArray();

            return View(productsAfterSearch);
        }

        [Route("/Product/Details/{id?}")]
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
        public IActionResult DownloadProductsInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb
                    .AppendLine($"Product with Id {product.Id}")
                    .AppendLine($"## Product Name {product.Name}")
                    .AppendLine($"## Product Price {product.Price:f2}lv")
                    .AppendLine($"-----------------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition,"attachment;filename=products.txt");


            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
