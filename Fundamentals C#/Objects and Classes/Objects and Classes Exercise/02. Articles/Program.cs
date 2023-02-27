using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace _02._Articles
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            
            
            

            string[] input = Console.ReadLine().Split(", ");
            string title = input[0];
            string content = input[1];
            string author = input[2];
            Article article = new Article(title, content, author);


            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(": ");
                string command = info[0];
                string data = info[1];
                
                if (command == "Edit")
                {
                    article.EditContent(data);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(data);
                }
                else if (command == "Rename")
                {
                    article.Rename(data);
                }
                
            }
            article.Print();
        }
    }

   
    class Article
    {
        // creator, methods
        

        public Article (string title,string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
            
        }
        public void EditContent(string data)
        { 
            this.Content=data;
        }
        public void ChangeAuthor(string data)
        {
            this.Author=data;
        }
        public void Rename(string data)
        {
            this.Title=data;
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