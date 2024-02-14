using SoftUniBazar.Data.Models;
using SoftUniBazar.Extensions;

namespace SoftUniBazar.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Data;
    using Models;

    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext dbContext;

        public AdController(BazarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<AdViewModel> viewModels = await this.dbContext.Ads
                .AsNoTracking()
                .Select(a => new AdViewModel()
                {
                    Id = a.Id,
                    Description = a.Description,
                    CreatedOn = a.CreatedOn.ToString(ValidationConstants.DateFormat),
                    ImageUrl = a.ImageUrl,
                    Price = a.Price,
                    Category = a.Category.Name,
                    Owner = a.Owner.UserName
                }).ToListAsync();

            return View(viewModels);
        }

        //Get Method for adding an Ad generating formModel with categories
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AdFormModel formModel = new AdFormModel()
            {
                Categories = await  GetCategories()
            };

            return View(formModel);
        }

        //Post method for adding an ad with formModel
        [HttpPost]
        public async Task<IActionResult> Add(AdFormModel formModel)
        {
            //check null
            if (formModel == null)
            {
                return BadRequest();
            }

            //Check for errors in model
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                formModel.Categories = await GetCategories();
                return View(formModel);
            }

            //Check for invalid Category Id
            if (!await this.dbContext.Categories.AnyAsync(c => c.Id == formModel.CategoryId))
            {
                ModelState.AddModelError("", "Invalid Category Id.");
                formModel.Categories = await GetCategories();
                return View(formModel);
            }

            Ad ad = new Ad()
            {
                Id = formModel.Id,
                Name = formModel.Name,
                Description = formModel.Description,
                Price = formModel.Price,
                OwnerId = User.GetUserId(),
                CreatedOn = DateTime.Now,
                CategoryId = formModel.CategoryId,
                ImageUrl = formModel.ImageUrl,
            };

            await this.dbContext.Ads.AddAsync(ad);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        //Method for adding a not owned ad to your cart
        public async Task<IActionResult> AddToCart(int id)
        {
            //Check if user entered an Id of not existing ad
            if (!this.dbContext.Ads.Any(a => a.Id == id))
            {
                return BadRequest();
            }
            
            string currentUserId = User.GetUserId();

            //Check if user is trying to add again same add
            if (await this.dbContext.AdsBuyers.AnyAsync(a => a.AdId == id && a.BuyerId == currentUserId))
            {
                return RedirectToAction("All", "Ad");
            }

            AdBuyer modelToCart = new AdBuyer()
            {
                AdId = id,
                BuyerId = currentUserId,
            };

            await this.dbContext.AdsBuyers.AddAsync(modelToCart);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("Cart", "Ad");
        }

        //method for visualizing all ads in user's cart
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var currentUserCart = await dbContext.AdsBuyers
                .Where(ab => ab.BuyerId == User.GetUserId())
                .Select(ab => new AdViewModel()
                {
                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    ImageUrl = ab.Ad.ImageUrl,
                    CreatedOn = ab.Ad.CreatedOn.ToString(ValidationConstants.DateFormat),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName
                }).ToListAsync();

            return View(currentUserCart);
        }

        //Removing an Ad from the User's Cart through the "Remove from Cart" button
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            //Check if user entered an Id of not existing ad
            if (!this.dbContext.Ads.Any(a => a.Id == id))
            {
                return BadRequest();
            }

            string currentUserId = User.GetUserId();

            //Check if user is trying to delete a non existing model
            if (!await this.dbContext.AdsBuyers.AnyAsync(a => a.AdId == id && a.BuyerId == currentUserId))
            {
                return RedirectToAction("All", "Ad");
            }

            AdBuyer? modelToDelete = await this.dbContext
                .AdsBuyers
                .FirstOrDefaultAsync(ad => ad.AdId == id && ad.BuyerId == currentUserId);

            if (modelToDelete == null)
            {
                return BadRequest();
            }

            this.dbContext.AdsBuyers.Remove(modelToDelete);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("Cart");
        }

        //Editing an Ad through the "Edit" button only if he is the original seller
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //Check if user entered an Id of not existing ad
            if (!this.dbContext.Ads.Any(a => a.Id == id))
            {
                return BadRequest();
            }

            string currentUserId = User.GetUserId();

            Ad? ad = await this.dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);

            if (ad == null)
            {
                return BadRequest();
            }

            if (ad.OwnerId != currentUserId)
            {
                return Unauthorized();
            }

            AdFormModel formModel = new AdFormModel()
            {
                Id = ad.Id,
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId,
                Categories = await GetCategories()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormModel formModel)
        {
            //null check
            if (formModel == null)
            {
                return BadRequest();
            }

            //Check for invalid Category Id
            if (!await this.dbContext.Categories.AnyAsync(c => c.Id == formModel.CategoryId))
            {
                ModelState.AddModelError("", "Invalid Category Id.");
                formModel.Categories = await GetCategories();
                return View(formModel);
            }

            //check for eventual errors in modelState
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                formModel.Categories = await GetCategories();
                return View(formModel);
            }

            Ad? ad = await this.dbContext.Ads.FirstOrDefaultAsync(a => a.Id == formModel.Id);

            //null check
            if (ad == null)
            {
                return BadRequest();
            }

            ad.Name = formModel.Name;
            ad.Description = formModel.Description;
            ad.ImageUrl = formModel.ImageUrl;
            ad.Price = formModel.Price;
            ad.CategoryId = formModel.CategoryId;
            
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Ad");
        }

        //Method for gathering the available categories in the Db
        private async Task<ICollection<AdCategoryModel>> GetCategories()
        {
            ICollection<AdCategoryModel> categories = await this.dbContext.Categories
                .AsNoTracking()
                .Select(c => new AdCategoryModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            return categories;
        }
    }
}
