using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patternForNumbers = @"\+359(-| )2\1\d{3}\1\d{4}\b";
            //Regex regex = new Regex(patternForNumbers);
            MatchCollection numbers = Regex.Matches(input,patternForNumbers);
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == numbers.Count - 1)
                {
                    Console.Write(numbers[i]);
                }
                else
                    Console.Write(numbers[i] + ", ");
            }
        }
    }
}   