namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestNum = numbers => numbers.Min();            
                
            Console.WriteLine(smallestNum(numbers));
            
        }

        
    }
}