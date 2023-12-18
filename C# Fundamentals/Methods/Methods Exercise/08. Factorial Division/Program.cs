namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = Math.Abs(int.Parse(Console.ReadLine()));
            int num2 = Math.Abs(int.Parse(Console.ReadLine()));
            int factorial1 = CalculateFactorial(num1);
            int factorial2 = CalculateFactorial(num2);                  
            int result = factorial1 / factorial2;
            Console.WriteLine($"{result:f2}");
        }
        static int CalculateFactorial(int num)

        {
            int factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}