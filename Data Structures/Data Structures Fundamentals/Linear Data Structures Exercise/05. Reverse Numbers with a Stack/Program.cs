namespace _05._Reverse_Numbers_with_a_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
