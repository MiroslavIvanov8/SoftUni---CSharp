namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int number = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                names.Add(input);
            }
            
            foreach(string name in names)
            Console.WriteLine(name);
        }
    }
}