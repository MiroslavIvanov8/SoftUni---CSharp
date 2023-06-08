namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> food = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> energy = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Dictionary<string, int> mountains = new()
            {
                {"Vihren",80},
                {"Kutelo",90},
                {"Banski Suhodol",100},
                { "Polezhan",60},
                { "Kamenitza",70},
            };
            List<string> conqueredPeeks = new();            
            
            while (food.Any())
            {
                if (conqueredPeeks.Count == 5)
                    break;
                int sum = food.Pop() + energy.Dequeue();
                foreach(var peak in mountains)
                {
                    if (sum >= peak.Value)
                    {
                        conqueredPeeks.Add(peak.Key);
                        mountains.Remove(peak.Key);
                        break;
                    }
                    else
                        break;
                }
                
            }
            if (conqueredPeeks.Count == 5)
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            else
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            if (conqueredPeeks.Count == 0)
                return;
            else
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeeks));
            }
        }
    }
}