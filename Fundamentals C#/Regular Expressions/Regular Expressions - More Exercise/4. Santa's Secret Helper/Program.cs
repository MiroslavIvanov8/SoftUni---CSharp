using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());            
            string input = string.Empty;
            string regexPattern = @"@(?<name>[A-Z][a-z]+)[^@\-!,:>]*!(?<type>[G|N])!";
            Regex regex = new Regex(regexPattern);
            while((input=Console.ReadLine())!="end")
            {
                string kidName = string.Empty;
                foreach (char ch in input)
                {
                    kidName += (char)(ch - key);
                }
                Match goodKid = regex.Match(kidName);
                string name = goodKid.Groups["name"].Value;
                string type = goodKid.Groups["type"].Value;

                if (type == "G")
                {
                    Console.WriteLine(name);
                }
                else
                    continue;
            }
        }
    }
}