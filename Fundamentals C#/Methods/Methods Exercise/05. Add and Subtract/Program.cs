namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int sumOfFirstTwo = GetSum(num1, num2,num3);
            int sumSubtracted = Subtract(sumOfFirstTwo, num3);
            Console.WriteLine(sumSubtracted);
        }

        static int GetSum(int num1, int num2,int num3)
        {
            return num1+ num2;
            
        }
        static int Subtract(int sumOfFirstTwo, int num3)
        {
            return (sumOfFirstTwo - num3);
        }
    }
}