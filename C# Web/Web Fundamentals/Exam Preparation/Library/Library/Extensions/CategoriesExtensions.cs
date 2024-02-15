namespace Library.Extensions
{
    using Microsoft.EntityFrameworkCore;
    
    using Models.Book;
    using Data;
    public static class CategoriesExtensions
    {
        public static async Task<ICollection<BookCategory>> GetCategories(LibraryDbContext dbContext)
        {
            ICollection<BookCategory> categories = await dbContext.Categories.Select(c => new BookCategory()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync();

            return categories;
        }
    }
}
