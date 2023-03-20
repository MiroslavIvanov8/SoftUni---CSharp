namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command;
            while ((command = Console.ReadLine()) != "Decode")
            {
                string[] commandArgs = command.Split("|");
                if (commandArgs[0] == "Move")
                {
                    int number = int.Parse(commandArgs[1]);
                    
                    string addition = input.Substring(0,number);
                    input = input.Remove(0,number);
                    input = input+addition;
                    
                }
                else if (commandArgs[0] == "Insert")
                {
                    int index = int.Parse(commandArgs[1]);
                    string value = commandArgs[2];
                    input = input.Insert(index, value);

                }
                else if (commandArgs[0] == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    input = input.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}