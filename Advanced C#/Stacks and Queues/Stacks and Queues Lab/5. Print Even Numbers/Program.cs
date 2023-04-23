namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);
            Console.WriteLine(string.Join(", ", numbers.Where(x=>x%2==0)));
        }
    }
}