namespace _01._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> drinks = new(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int stamatCaffeine = 0;

            while (caffeine.Any() && drinks.Any())
            {
                int currCaffeine = caffeine.Peek() * drinks.Peek();
                if (currCaffeine + stamatCaffeine <= 300)
                {
                    stamatCaffeine += currCaffeine;
                    currCaffeine = 0;
                    caffeine.Pop();
                    drinks.Dequeue();
                }
                else
                {
                    caffeine.Pop();
                    drinks.Enqueue(drinks.Dequeue());

                    if (stamatCaffeine - 30 < 0)
                        stamatCaffeine = 0;
                    else
                        stamatCaffeine -= 30;
                }
            }
            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            Console.WriteLine($"Stamat is going to sleep with {stamatCaffeine} mg caffeine.");
        }
    }
}