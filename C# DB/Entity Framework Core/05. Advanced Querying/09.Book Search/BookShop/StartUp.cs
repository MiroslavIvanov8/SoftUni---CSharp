using System.Text;
using System.Xml.Serialization;
using BookShop.Models;
using BookShop.Models.Enums;

namespace BookShop;

using Data;
using Initializer;
using System.Globalization;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();
        DbInitializer.ResetDatabase(db);

        string input = Console.ReadLine()!;
        Console.WriteLine(GetBookTitlesContaining(db, input));
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

    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var books = context.Books
            .Where(b => b.BookCategories.Any(y => categories.Contains(y.Category.Name.ToLower())))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToList();

        StringBuilder sb = new();

        foreach (var title in books)
        {
            sb.AppendLine(title);
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetBooksReleasedBefore(BookShopContext context, string input)
    {
        DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var books = context.Books
            .Where(b => b.ReleaseDate.Value.Date < date.Date)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                Price = b.Price.ToString("f2"),
                b.ReleaseDate
            })
            .OrderByDescending(b => b.ReleaseDate);

        StringBuilder sb = new();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => a.FirstName + ' ' + a.LastName)
            .OrderBy(n => n);

        StringBuilder sb = new();
        foreach (var a in authors)
        {
            sb.AppendLine(a);
        }

        return sb.ToString().TrimEnd();
    }

    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var titles = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(n => n);

        return string.Join(Environment.NewLine, titles);
    }
}




