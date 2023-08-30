using System;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace _02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ulong coolThreshhold = 1;
            ulong emojiSum = 0;
            string digitPatter = @"[\d]";
            string emojiPattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            Regex digitRegex = new Regex(digitPatter);
            Regex emojiRegex = new Regex(emojiPattern);
            MatchCollection digits = digitRegex.Matches(input);
            MatchCollection emojis = emojiRegex.Matches(input);
            var coolEmojis = new List<Match>();
            foreach (Match digit in digits)
            {
                ulong number = ulong.Parse(digit.ToString());
                coolThreshhold *= number;
            }
            Console.WriteLine($"Cool threshold: {coolThreshhold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojis)
            {
                string currEmoji = emoji.Groups["emoji"].ToString();
                foreach (char ch in currEmoji)
                {
                    emojiSum+= ch;
                }
                if (emojiSum > coolThreshhold)
                coolEmojis.Add(emoji);
                emojiSum = 0;                  
                
            }
            foreach (var match in coolEmojis)
            {
                Console.WriteLine(match);
            }
        }
    }
} 