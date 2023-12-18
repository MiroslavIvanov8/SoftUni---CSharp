using static System.Net.Mime.MediaTypeNames;

namespace _01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] commandArgs = command.Split(":|:");

                if (commandArgs[0] == "InsertSpace")
                {
                    int index = int.Parse(commandArgs[1]);
                    input = input.Insert(index, " ");
                    Console.WriteLine(input);
                }
                else if (commandArgs[0] == "Reverse")
                {
                    string substring = commandArgs[1];
                    if (input.Contains(substring))
                    {
                        int index = input.IndexOf(substring);
                        input = input.Remove(index, substring.Length);
                        string reversedSubstring = string.Empty;
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring += substring[i];
                        }
                        input = input+reversedSubstring;
                        Console.WriteLine(input);
                    }
                    else
                    { 
                        Console.WriteLine("error");
                        
                    }
                }
                else if (commandArgs[0] == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    input = input.Replace(substring, replacement);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"You have a new text message: {input}");
            
        }
    }
}