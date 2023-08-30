namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string massage = Console.ReadLine();
            foreach (string bannedWord in bannedWords)
            {
                massage = massage.Replace(bannedWord, new string('*', bannedWord.Length));
            }
            Console.WriteLine(massage);
        }
    }
}