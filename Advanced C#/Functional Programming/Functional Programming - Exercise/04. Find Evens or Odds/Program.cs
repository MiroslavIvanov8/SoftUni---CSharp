namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new List<int>();
                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }
                return range;
            };           

            List<int> numbers = generateRange(range[0], range[1]);

            string type = Console.ReadLine();
            Func<string, int ,bool> evenOddMatch = (type,number) =>
            {
                if (type == "even")
                {
                    return number % 2 == 0;
                }

                else 
                {
                    return number % 2 != 0;
                }
            };
            
            foreach (int number in numbers)
            {
                if(evenOddMatch(type,number))
                    Console.Write(number + " ");
            }
        }
    }
}