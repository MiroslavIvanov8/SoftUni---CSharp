using System.Text.RegularExpressions;

namespace _02._Encrypting_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"(.+)>(?<numbers>\d{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<symbols>[^><]{3})<(\1)";
            Regex regex = new Regex(pattern);
            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();
                Match match = regex.Match(password);
                if (!match.Success)
                    Console.WriteLine("Try another password!");
                else
                {
                    string encryptedPass = match.Groups["numbers"].Value + match.Groups["lower"].Value + match.Groups["upper"].Value + match.Groups["symbols"].Value;
                    Console.WriteLine($"Password: {encryptedPass}");
                }
            }
        }
    }
}