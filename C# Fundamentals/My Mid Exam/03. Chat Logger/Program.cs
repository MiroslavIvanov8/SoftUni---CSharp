namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commandArgs = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandArgs[0];
                if (commandType == "Chat")
                {
                    string massage = commandArgs[1];
                    AddMasssage(chat, massage);
                }
                else if (commandType == "Delete")
                {
                    string delete = commandArgs[1];
                    RemoveMassage(chat, delete);
                }
                else if (commandType == "Edit")
                {
                    string massage = commandArgs[1];
                    string editedMassage = commandArgs[2];
                    int index = chat.IndexOf(massage);
                    if (index < 0 && index > chat.Count - 1)
                    {
                        continue;
                    }
                    else
                        EditMassage(chat, index, editedMassage);
                }
                else if (commandType=="Pin")
                {
                    PinMassage(chat, commandArgs);
                }
                else if (commandType== "Spam")
                {
                    for (int i = 1; i < commandArgs.Length; i++)
                    {
                        chat.Add(commandArgs[i]);
                    }
                }
                
            }
            Console.WriteLine(string.Join(Environment.NewLine,chat));
        }
        static List<string> AddMasssage(List<string> chat, string massage)
        {
            chat.Add(massage);
            return chat;
        }
        static List<string> RemoveMassage(List<string> chat, string delete)
        {
            chat.Remove(delete);
            return chat;
        }
        static List<string> EditMassage (List<string> chat, int index,string editedMassage)
        {
            chat[index] = editedMassage;
            return chat;
        }
        static List<string> PinMassage(List<string> chat, string[] commandArgs)
        {
            string massage = commandArgs[1];
            int index = chat.IndexOf(massage);
            chat.Remove(massage);
            chat.Add(massage);
            return chat;
        }
    }
}