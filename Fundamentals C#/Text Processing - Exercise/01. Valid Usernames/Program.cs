namespace _01._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            foreach (string username in input)
            {
                username.ToCharArray();
                if (username.Length > 3 && username.Length <= 16)
                {
                    bool isUsernameValud = true;
                    foreach (char currCh in username)
                    {
                        if (!(char.IsLetterOrDigit(currCh) || currCh == '-' || currCh == '_'))
                        {
                            isUsernameValud= false;
                            break;
                        }
                    }
                    if (isUsernameValud)
                    {
                        Console.WriteLine(username);
                    }
                }
            }
        }
    }
}
