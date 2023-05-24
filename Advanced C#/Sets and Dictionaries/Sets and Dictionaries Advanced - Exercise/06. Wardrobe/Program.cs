using System;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string,int>> clothes = new();
            string itemToLookFor = string.Empty;
            string colorToLookFor = string.Empty;
            for (int i = 0; i < number; i++)
            {
                string command = Console.ReadLine();

                if (command.Contains(" -> "))
                {
                    string[] commandInfo = command.Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                    string color = commandInfo[0];

                    if (!clothes.ContainsKey(color))
                    {
                        clothes.Add(color, new Dictionary<string, int>());                        
                    }
                    foreach (string cloth in commandInfo.Skip(1))
                    {
                        if (!clothes[color].ContainsKey(cloth))
                        {
                            clothes[color].Add(cloth, 1);
                        }
                        else
                            clothes[color][cloth]++;
                    }
                }
            }
            string[] itemInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            itemToLookFor = itemInfo[1];
            colorToLookFor = itemInfo[0];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == colorToLookFor && itemToLookFor == cloth.Key)
                        Console.WriteLine($" * {cloth.Key} - {cloth.Value} (found!)");

                    else
                    {
                        Console.WriteLine($" * {cloth.Key} - {cloth.Value}");
                    }
                }
            }

        }
    }      
}
