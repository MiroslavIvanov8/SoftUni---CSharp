namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            SortedSet<string> set = new ();
            for (int i = 0; i < number; i++)
            {
                string[] elemetns = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach(string element in elemetns)
                {
                    set.Add(element);
                }
            }
            foreach(string element in set)
                Console.Write($"{element} ");
        }
    }
}