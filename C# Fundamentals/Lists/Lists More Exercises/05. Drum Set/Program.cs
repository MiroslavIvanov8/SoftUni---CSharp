namespace _05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> drums =Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> initialQuaity = drums.ToList();
            string input;
            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int power = int.Parse(input);
                
                for (int i = 0; i < drums.Count; i++)
                {
                    
                    drums[i]-=power;
                    if (drums[i] <= 0)
                    {
                        if (money >= initialQuaity[i] * 3)
                        {
                            money -= initialQuaity[i] * 3;
                            drums[i] = initialQuaity[i];
                        }
                        else
                        {
                            drums.RemoveAt(i);
                            initialQuaity.RemoveAt(i);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}