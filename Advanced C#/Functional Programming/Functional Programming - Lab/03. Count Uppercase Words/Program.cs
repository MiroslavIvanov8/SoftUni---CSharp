using System.Security.Cryptography.X509Certificates;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Predicate<string> checker = x => x[0] == x.ToUpper()[0];
            string[] words = Console.ReadLine().Split(" ");
            string[] upperWords = words               
                .Where(w => char.IsUpper(w[0]))
                .ToArray();
            foreach (string word in upperWords)
            {
                Console.WriteLine(word);
            }



        }
    }
}