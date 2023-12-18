namespace _01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] commandArgs = command.Split(">>>");
                if (commandArgs[0] == "Contains")
                {
                    string substring = commandArgs[1];
                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                    }
                    else
                        Console.WriteLine("Substring not found!");
                }
                else if (commandArgs[0] == "Flip")
                {
                    string type = commandArgs[1];
                    int start = int.Parse(commandArgs[2]);
                    int end = int.Parse(commandArgs[3]);
                    string substring = input.Substring(start, end - start);
                    string reversedSubstring = string.Empty;
                    if (type == "Upper")
                    {
                        for (int i = 0; i < substring.Length; i++)
                        {
                            char ch = substring[i];
                            if (char.IsLetter(ch))
                            {
                                ch = char.ToUpper(ch);
                                reversedSubstring += ch;
                            }
                            else
                                reversedSubstring += ch;
                        }
                    }
                    else if (type == "Lower")
                    {
                        for (int i = 0; i < substring.Length; i++)
                        {
                            char ch = substring[i];
                            if (char.IsLetter(ch))
                            {
                                ch = char.ToLower(ch);
                                reversedSubstring += ch;
                            }
                            else
                                reversedSubstring += ch;
                        }
                    }
                    input = input.Replace(substring, reversedSubstring);
                    Console.WriteLine(input);
                }
                else if (commandArgs[0] == "Slice")
                {
                    int start = int.Parse(commandArgs[1]);
                    int end = int.Parse(commandArgs[2]);
                    input = input.Remove(start, end - start);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine($"Your activation key is: {input}");
        }
    }
}