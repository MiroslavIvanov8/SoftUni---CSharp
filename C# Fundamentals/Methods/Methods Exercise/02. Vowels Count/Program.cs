using System.Diagnostics.Metrics;

namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int output = VowelsCounter(input);
            Console.WriteLine(output);
        }

        static int VowelsCounter(string input)
        {
            int vowelSum = 0;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            foreach (char letter in input.ToLower())
            {
                if(vowels.Contains(letter))
                vowelSum++;
            }
            return vowelSum;
        }
    }
}