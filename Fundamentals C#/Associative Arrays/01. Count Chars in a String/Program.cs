namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (string word in input)
            {
                foreach (char letter in word)
                {
                    if (!counts.ContainsKey(letter)) // we initialize a new key and a new value
                    {
                        counts.Add(letter, 1);
                    }
                    else // we encunter a existing key and just increase its value by 1 
                    {
                        counts[letter]++;
                    }
                }
            }
            foreach (var letter in counts)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }


        }
    }
}