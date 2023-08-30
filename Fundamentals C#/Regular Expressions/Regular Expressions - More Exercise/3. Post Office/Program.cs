using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;

namespace _3._Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstPartPattern = @"([#$%*&])(?<letters>[A-Z]+)(\1)";
            string secondPartPattern = @"\d{2}:\d{2}";
            string thirtPartPattern = @"[A-Z][^ ]+";
             
            Regex capitalLetters = new Regex(firstPartPattern);
            Regex asciiAndLength = new Regex(secondPartPattern);
            Regex words = new Regex(thirtPartPattern);

            string[] input = Console.ReadLine().Split("|");

            Match Capitals = capitalLetters.Match(input[0]);
            string capitals = Capitals.Groups["letters"].ToString();
            MatchCollection AsciiLength = asciiAndLength.Matches(input[1]);
            MatchCollection Words = words.Matches(input[2]);

            for (int i = 0; i < capitals.Length; i++)
            {
                char first = capitals[i];
                string asciiLength = AsciiLength[i].ToString();
                string[] ascii = asciiLength.Split(":"); 
                int expected = int.Parse(ascii[0]);
                char expectedFirst = (char)expected;
                bool exitLoop = false;
                
                

                foreach (Match doubles in AsciiLength)
                {
                    string currPair = doubles.ToString();
                    string[]currPairArr = currPair.Split(":");
                    int token = int.Parse(currPairArr[0]);
                    char currChar = (char)token;
                    int length = int.Parse(currPairArr[1]);

                    if (currChar == first)
                    {
                        foreach (Match word in Words) // need to figure out how to cycle through all the asciiLength doubles and find the ones suitable with the first expected Letter
                        {
                            string wrd = word.Value;
                            if (wrd.StartsWith(first) && wrd.Length == length+1)
                            {
                                Console.WriteLine(wrd);
                                exitLoop = true;
                                break;
                            }
                        }
                    }
                    if (exitLoop == true)
                        break; 
                }
                
            }
        }
    }
}