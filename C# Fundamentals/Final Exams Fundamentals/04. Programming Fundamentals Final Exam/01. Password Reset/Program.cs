namespace _01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "TakeOdd")
                {
                    string rawPass = string.Empty;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i % 2 != 0)
                            rawPass += input[i];
                    }
                    input = rawPass;
                    Console.WriteLine(input);
                }
                else if (commandArgs[0] == "Cut")
                {
                    int index = int.Parse(commandArgs[1]);
                    int length = int.Parse(commandArgs[2]);
                    input = input.Remove(index, length);
                    Console.WriteLine(input);
                }
                else if (commandArgs[0] == "Substitute")
                {
                    string substring = commandArgs[1];
                    string substitute = commandArgs[2];
                    if (input.Contains(substring))
                    {
                        input = input.Replace(substring, substitute);
                        Console.WriteLine(input);
                    }
                    else
                        Console.WriteLine("Nothing to replace!");
                }
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}