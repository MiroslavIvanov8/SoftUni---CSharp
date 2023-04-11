using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\ (?<user>[a-z\d]{1,}[a-z-\._\d]*)@(?<host>(?<word1>[a-z][a-z-]*[a-z]))\.(?<words>[a-z][a-z-]*[a-z]\.)*(?<last>[a-z]+)";
            Regex regex= new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            { 
                string matched = match.ToString();
                matched = matched.Remove(0,1);
                Console.WriteLine(matched);
            }
        }
    }
}