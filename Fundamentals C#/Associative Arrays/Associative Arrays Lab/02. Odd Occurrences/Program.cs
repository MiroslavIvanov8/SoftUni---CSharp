using System.Runtime.CompilerServices;

namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (string word in input)
            {
                string wordInLower = word.ToLower();
                {
                    if (counts.ContainsKey(wordInLower))
                    {
                        counts[wordInLower]++;
                    }
                    else
                    {
                        counts.Add(wordInLower, 1);
                    }
                }
            }

            foreach(var count  in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key+ " ");
                }
            }
        }
    }
}