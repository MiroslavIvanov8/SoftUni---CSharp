using System.Collections;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> milk = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> coffeeCount = new();
            while (coffee.Any() && milk.Any())
            {
                int sum = coffee.Dequeue() + milk.Peek();
                if (sum == 50)
                {
                    if (!coffeeCount.ContainsKey("Cortado"))
                    {
                        coffeeCount.Add("Cortado", 0);
                    }       
                    coffeeCount["Cortado"]++;
                    milk.Pop();
                }
                else if (sum == 75)
                {
                    if (!coffeeCount.ContainsKey("Espresso"))
                    {
                        coffeeCount.Add("Espresso", 0);
                    }
                    coffeeCount["Espresso"]++;
                    milk.Pop();
                }
                else if (sum == 100)
                {
                    if (!coffeeCount.ContainsKey("Capuccino"))
                    {
                        coffeeCount.Add("Capuccino", 0);
                    }
                    coffeeCount["Capuccino"]++;
                    
                    milk.Pop();
                }
                else if (sum == 150)
                {
                    if (!coffeeCount.ContainsKey("Americano"))
                    {
                        coffeeCount.Add("Americano", 0);
                    }
                    coffeeCount["Americano"]++;
                    
                    milk.Pop();
                }
                else if (sum == 200)
                {
                    if (!coffeeCount.ContainsKey("Latte"))
                    {
                        coffeeCount.Add("Latte", 0);
                    }
                    coffeeCount["Latte"]++;
                    
                    milk.Pop();
                }
                else
                {
                    milk.Push(milk.Pop() - 5);
                }
                
            }
            if (!coffee.Any() && !milk.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                if (coffee.Any())
                {
                    Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
                    Console.WriteLine("Milk left: none");
                }
                else if (milk.Any())
                {
                    Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
                    Console.WriteLine("Coffee left: none");
                }
            }
            

            foreach(var coffe in coffeeCount.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
                Console.WriteLine($"{coffe.Key}: {coffe.Value}");

        }
    }
}