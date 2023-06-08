namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> medicaments = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Dictionary<string, int> items = new();
            while (medicaments.Any() && textiles.Any())
            {
                int sum = textiles.Peek() + medicaments.Peek();
                
                if (sum == 30)
                {
                    if (!items.ContainsKey("Patch"))
                    {
                        items.Add("Patch", 0);
                    }
                    items["Patch"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (sum == 40)
                {
                    if (!items.ContainsKey("Bandage"))
                    {
                        items.Add("Bandage", 0);
                    }
                    items["Bandage"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (sum == 100)
                {
                    if (!items.ContainsKey("MedKit"))
                    {
                        items.Add("MedKit", 0);
                    }
                    items["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                }
                else if (sum > 100)
                {
                    items["MedKit"]++;
                    int itemDiff = sum - 100;

                    textiles.Dequeue();
                    medicaments.Pop();
                    itemDiff += medicaments.Pop();
                    medicaments.Push(itemDiff);
                }
                else
                {
                    textiles.Dequeue();
                    int medicament = medicaments.Pop();
                    medicament += 10;
                    medicaments.Push(medicament);
                }
            }

            if (medicaments.Count > textiles.Count)
                Console.WriteLine("Textiles are empty.");
            else if (medicaments.Count < textiles.Count)
                Console.WriteLine("Medicaments are empty.");
            else
                Console.WriteLine("Textiles and medicaments are both empty.");
            
            foreach (var item in items.OrderByDescending(x => x.Value).ThenBy(y=>y.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            if (medicaments.Count > textiles.Count)            
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            
            else if (medicaments.Count < textiles.Count)
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");

           // if (!textiles.Any() && !medicaments.Any())
           // {
           //     Console.WriteLine("Textiles and medicaments are both empty.");
           // }
           // else if (!textiles.Any())
           // {
           //     Console.WriteLine("Textiles are empty.");
           // }
           // else
           // {
           //     Console.WriteLine("Medicaments are empty.");
           // }
           //
           // foreach (var item in items.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
           // {
           //     Console.WriteLine($"{item.Key} - {item.Value}");
           // }
           //
           // if (textiles.Any())
           // {
           //     Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
           // }
           //
           // if (medicaments.Any())
           // {
           //     Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
           // }
        }
    }
}