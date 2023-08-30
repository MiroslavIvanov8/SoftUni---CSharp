using System.Globalization;

namespace _01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string text = Console.ReadLine();
            int lettersNum = numbers.Count;
            List<string> output = new List<string>();
            // въртим цикъл за всяка една от буквите
            // като трябва да събираме сумата от цифрите и да търсим 
            // отговарящия индекс в посланието, ако индекса е по- голям продължаваме броенето
            // от началто на стринга 
            for (int i = 0; i < lettersNum; i++)
            {
                int digits = numbers[i];
                int sum = 0;
                while (digits > 0)
                {
                    int currDigit = digits % 10;

                    sum += currDigit;

                    digits = digits / 10;
                }

                for (int j = 0; j < text.Length; j++)
                {
                    if (sum >= text.Length)
                    {
                        sum -= text.Length;
                    }
                    if (j == sum)
                    {
                        output.Add(text[j + i].ToString()); // j+i we remove every time text[j] from the text
                        break;
                    }
                }               
      
            }
            Console.WriteLine(string.Join("", output));
        }
    }
}