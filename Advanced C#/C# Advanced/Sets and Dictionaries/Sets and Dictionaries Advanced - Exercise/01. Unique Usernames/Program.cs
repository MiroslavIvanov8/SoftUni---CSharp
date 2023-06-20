namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> names = new();

            for (int i = 0; i < number; i++)
            {
                names.Add(Console.ReadLine());
            }
           foreach(string name in names)
                Console.WriteLine(name);
        }
    }
}