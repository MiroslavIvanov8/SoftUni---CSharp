namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Dictionary<int, int> numberOccurences = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (numberOccurences.ContainsKey(number))
                {
                    numberOccurences[number]++;
                }
                else 
                {
                    numberOccurences.Add(number, 1);
                }
            }
            foreach (var number in numberOccurences)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }  
    }
}