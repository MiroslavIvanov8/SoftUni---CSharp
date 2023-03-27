using System;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(@|#)(?<first>[A-Za-z]{3,})\1{2,}(?<second>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);
            string pairsPattern = @"[A-Za-z]+";
            Regex pairRegex = new Regex(pairsPattern);
            var mirrorWords = new Dictionary<string,string>();
            MatchCollection validPairs = regex.Matches(text);

            if (validPairs.Count == 0)            
                Console.WriteLine("No word pairs found!");     
            
            else
                Console.WriteLine($"{validPairs.Count} word pairs found!");

            for (int i = 0; i < validPairs.Count; i++)
            {

                MatchCollection words = pairRegex.Matches(validPairs[i].ToString());
                string reversedWord = string.Empty;
                string word = words[1].ToString();
                for (int j = word.Length - 1; j >= 0; j--)
                {
                    reversedWord += word[j].ToString();
                }
                if (words[0].ToString() == reversedWord)
                {
                    mirrorWords[words[0].ToString()] = words[1].ToString();
                }

            }
            if (mirrorWords.Count == 0)
                Console.WriteLine("No mirror words!");
            else
                Console.WriteLine(string.Join(", ", mirrorWords.Select(p => $"{p.Key} <=> {p.Value}")));

                    
        }
    }
}