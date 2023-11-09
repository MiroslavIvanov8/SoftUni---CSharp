using System.Text;
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

        Console.WriteLine(GetGoldenBooks(db));
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
}




