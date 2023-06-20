namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string, string[]> AddSir = (title, str) =>
            {
                foreach (string name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };
            AddSir("Sir",names);
            AddSir("Kekw", names);
        }
    }
}