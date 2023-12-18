using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string datePattern = @"\b(?<day>\d{2})(-|.|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            Regex regex= new Regex(datePattern);
            string input = Console.ReadLine();
            MatchCollection dates = regex.Matches(input);
            foreach (Match date in dates)
            {
               //var day=(date.Groups["day"].Value);
               //var month = (date.Groups["month"].Value);
               //var year = (date.Groups["year"].Value);
                Console.WriteLine($"Day: {date.Groups["day"]}, Month: {date.Groups["month"]}, Year: {date.Groups["year"]}");
            }
        }
    }
}