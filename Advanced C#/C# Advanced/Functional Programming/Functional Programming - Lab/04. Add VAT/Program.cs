namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] vatNumbers= Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.2d)
                .ToArray();
            foreach(double number in vatNumbers)
                Console.WriteLine($"{number:f2}");
        }
    }
}