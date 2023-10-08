using System;

namespace UniversityLibrary
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            TextBook book = new TextBook("kek", "mirokek", "fantasy");

            Console.WriteLine(book);
        }
    }
}
