using System.Text;

namespace _04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] charrArr = input.ToCharArray();

            EncryptingMassage(charrArr);
        }
        public static void EncryptingMassage(char[] input)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (char)(input[i] + 3);
                sb.Append(input[i]);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}