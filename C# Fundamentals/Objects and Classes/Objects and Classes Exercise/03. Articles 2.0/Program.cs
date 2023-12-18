using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace _02._Articles
{
    internal class Program
    {


        static void Main(string[] args)
        {




           
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string author = input[2];
                Article article = new Article(title, content, author);
                articles.Add(article);
            }
            foreach (Article article in articles)
            {
                article.Print();
            }
        }
    }


    class Article
    {
        // creator, methods


        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;

        }
        
        public void Print()
        {
            Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


    }
}