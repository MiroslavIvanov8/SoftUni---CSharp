namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int result = Calculation(num1,num2,operation);
            Console.WriteLine(result);
        }

        static int Calculation(int num1, int num2, char operation)
        {
            int result = 0;
            if (operation == '+')
            {
                result = num1 + num2;
            }
            else if (operation == '-')
            {
                result = num1 - num2;
            }
            else if (operation == '/')
            {
                result = num1 / num2;
            }
            else
            {
                result = num1 * num2;
            }
            return result;
        }
    }
}