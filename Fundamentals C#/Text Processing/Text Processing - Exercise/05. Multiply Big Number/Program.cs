using System.Text;

namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number1 = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            int reminder = 0;
            var sum = new StringBuilder();
            if (multiplier == 0 || number1 == "0")
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int currDigit = int.Parse(number1[i].ToString());
                int product = currDigit * multiplier + reminder;
                int result = product % 10;
                reminder = product/ 10;
                sum.Insert(0,result);
            }
            if(reminder>0)
                sum.Insert(0,reminder);
            Console.WriteLine(sum);
        }
    }
}