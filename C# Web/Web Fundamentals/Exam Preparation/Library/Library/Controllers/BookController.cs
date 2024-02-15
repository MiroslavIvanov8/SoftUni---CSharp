using Library.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models.Book;
    using static CategoriesExtensions;
    using Library.Data.Models;

    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext dbContext;

        public BookController(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Visualizing all available books through the "All" button
        public async Task<IActionResult> All()
        {
            ICollection<BookViewModel> books = await this.dbContext.Books.Select(b => new BookViewModel()
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Rating = b.Rating,
                ImageUrl = b.ImageUrl,
                Category = b.Category.Name,
            }).ToListAsync();

            return View(books);
        }

        //Adding a book through the "Add" button, only logged users can do that
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            BookFormModel viewModel = new BookFormModel()
            {
                Categories = await GetCategories(dbContext)
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormModel formModel)
        {
            //Checking for any model binding and validation errors 
            if (!ModelState.IsValid)
            {
                formModel.Categories = await GetCategories(dbContext);
                ModelState.AddModelError(nameof(formModel.CategoryId), "Invalid category Id");
                return View(formModel);
            }

            //Checking if given category Id is valid
            if (!await this.dbContext.Categories.AnyAsync(c => c.Id == formModel.CategoryId))
            {
                return BadRequest();
            }

            Book book = new Book()
            {
                Author = formModel.Author,
                Title = formModel.Title,
                Description = formModel.Description,
                Rating = formModel.Rating,
                ImageUrl = formModel.ImageUrl,
                CategoryId = formModel.CategoryId

            };

            await this.dbContext.Books.AddAsync(book);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Book");
        }

        //Adding a book to the user collection via "Add to collection" button
        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            Book? book = await this.dbContext.Books.FindAsync(bookId);

            //Checking if id is invalid
            if (book == null)
            {
                return BadRequest();
            }

            //Checking if user is trying to add same book to his collection
            if (await this.dbContext.IdentityUsersBooks.AnyAsync(ub =>
                    ub.BookId == bookId && ub.IdentityUserId == User.GetUserId()))
            {
                return RedirectToAction("All", "Book");
            }

            IdentityUserBook ub = new IdentityUserBook()
            {
                IdentityUserId = User.GetUserId(),
                BookId = bookId
            };

            await this.dbContext.AddAsync(ub);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("All", "Book");
        }

        //Removing a book from the users collection vie the "Remove from collection" button
        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            Book? book = await this.dbContext.Books.FindAsync(bookId);

            //Checking if id is invalid
            if (book == null)
            {
                return BadRequest();
            }

            //Checking if user is trying to remove a non existing book from his collection
            if (!await this.dbContext.IdentityUsersBooks.AnyAsync(ub =>
                    ub.BookId == bookId && ub.IdentityUserId == User.GetUserId()))
            {
                return RedirectToAction("All", "Book");
            }

            IdentityUserBook ub = new IdentityUserBook()
            {
                IdentityUserId = User.GetUserId(),
                BookId = bookId
            };

            this.dbContext.IdentityUsersBooks.Remove(ub);
            await this.dbContext.SaveChangesAsync();
            
            return RedirectToAction("Mine", "Book");
        }

        public async Task<IActionResult> Mine()
        {
            ICollection<MineBookModel> mineBooks = await this.dbContext
                .IdentityUsersBooks
                .Where(ub => ub.IdentityUserId == User.GetUserId())
                .Select(b => new MineBookModel()
                {
                    Id = b.BookId,
                    Author = b.Book.Author,
                    Title = b.Book.Title,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name,
                    ImageUrl = b.Book.ImageUrl,
                })
                .ToListAsync();

            return View(mineBooks);
        }

    }

}
