using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputPattern = @"[^,\s]+";
            string matchPattern = @"([A-Za-z\d]*([^?<left>\d\w]{6,10})[A-Za-z]*([^?<right>\d\w]{6,10})[A-Za-z\d]*)";
            Regex inputRegex = new Regex(inputPattern);
            Regex matchRegex = new Regex(matchPattern);
            MatchCollection matches = inputRegex.Matches(input);
            foreach (Match match in matches)
            {
                Match currMatch = matchRegex.Match(match.ToString());
                int leftCount = currMatch.Groups[2].Value.Length;
                int rightCount = currMatch.Groups[3].Value.Length;

                if (!currMatch.Success)
                {
                    if (match.Length < 20 || currMatch.Length > 20)
                        Console.WriteLine("invalid ticket");
                    else
                        Console.WriteLine($"ticket \"{match}\" - no match");
                }
                else if (leftCount >= 6 && leftCount <= 9 && currMatch.Length == 20)
                {

                    char currSymbol = currMatch.Groups["2"].ToString().First();
                    Console.WriteLine($"ticket \"{match}\" - {leftCount}{currSymbol}");

                }
                else if (leftCount == 10 && currMatch.Length == 20)
                {
                    if (leftCount == rightCount)
                    {
                        char currSymbol = currMatch.Groups["2"].ToString().First();
                        Console.WriteLine($"ticket \"{match}\" - {leftCount}{currSymbol} Jackpot!");
                    }
                }
            }
        }
    }
}