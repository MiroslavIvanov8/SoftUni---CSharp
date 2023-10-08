namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> charsCount = new();
            foreach (char ch in input)
            {
                if (!charsCount.ContainsKey(ch))
                {
                    charsCount[ch] = 0;
                }

                charsCount[ch]++;
            }
            foreach (var kvp in charsCount)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}