namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numberCount = new();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numberCount.ContainsKey(number))
                {
                    numberCount.Add(number,0);
                }
                numberCount[number]++;
            }
            foreach (var kvp in numberCount)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    break;
                }
            }    
        }
    }
}