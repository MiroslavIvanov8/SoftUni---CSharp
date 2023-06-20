namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stop = int.Parse(Console.ReadLine());
            List<int> numbers = new();
            Func<int, int, List<int>> generatingNumbers = (start, stop) =>
            {
                for (start = 1; start <= stop; start++)
                {
                    numbers.Add(start);
                }
                return numbers;
            };
            numbers = generatingNumbers(1,stop);

            HashSet<int> dividers = Console.ReadLine().
                Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();
            List<Predicate<int>> predicates = new();

            foreach (int devider in dividers)
            {
                predicates.Add(n => n % devider == 0);
            }

            foreach (int number in numbers)
            {
                bool isDivisible = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(number))
                    {
                        isDivisible = false;
                        break;
                    }                    
                }
                if(isDivisible) 
                {
                    Console.Write(number + " ");
                }
            }
            
        }
    }
}