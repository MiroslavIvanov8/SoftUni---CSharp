namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().
                Split(" ",StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse)
                .ToList();
            Func<List<int>, List<int>> reverse = numbers =>
            {
                List<int> result = new ();
                for (int i = numbers.Count-1; i >= 0; i--)
                {
                    result.Add(numbers[i]);
                }
                return result;
            };
            numbers = reverse(numbers);
            int dividen = int.Parse(Console.ReadLine());
            Predicate<int> divisionCheck = number =>
            {
                if (number % dividen == 0)
                    return false;
                else
                    return true;
            };
            foreach (int number in numbers)
            {
                if (divisionCheck(number))
                    Console.Write($"{number} ");

            }
        }
    }
}