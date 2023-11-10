using System.Text;
using System.Xml.Serialization;
using BookShop.Models;
using BookShop.Models.Enums;

namespace BookShop;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        int year = int.Parse(Console.ReadLine());
        Console.WriteLine(GetBooksNotReleasedIn(db, year));
    }

    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        command = command.ToLower();
        StringBuilder sb = new();

        List<Book> bookInfo = new List<Book>();

        if (command == "minor")
        {
            bookInfo = context.Books
                              .Where(b => b.AgeRestriction == AgeRestriction.Minor)
                              .OrderBy(b => b.Title).ToList();
        }
        else if (command == "teen")
        {
            bookInfo = context.Books
                .Where(b => b.AgeRestriction == AgeRestriction.Teen)
                .OrderBy(b => b.Title)
                .ToList();

        }
        else
        {
            bookInfo = context.Books
                .Where(b => b.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(b => b.Title)
                .ToList();
        }

        foreach (var book in bookInfo)
        {
            sb.AppendLine(book.Title);
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetGoldenBooks(BookShopContext context)
    {
        StringBuilder sb = new();

        var goldenBooks = context.Books
            .Where(b => b.Copies<5000 && b.EditionType == EditionType.Gold)
            .OrderBy(b => b.BookId);

        foreach (var book in goldenBooks)
        {
            sb.AppendLine(book.Title);
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new();

        var books = context.Books
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .Where(b => b.Price > 40)
            .OrderByDescending(b => b.Price);
            

        foreach(var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId);

        StringBuilder sb = new();
        foreach (var book in books)
        {
            sb.AppendLine(book.Title);
        }

        return sb.ToString().TrimEnd();
    }
}




