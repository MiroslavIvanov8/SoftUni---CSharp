using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullNameRegex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b"; //@"([A-Z][a-z]{2,}) \1"
            Regex regex= new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+\b");
            string names = Console.ReadLine();
            MatchCollection result = Regex.Matches(names, fullNameRegex);
            foreach (Match name in result)
            {
                Console.Write(name.Value + " ");
            }
            


        }
    }
}