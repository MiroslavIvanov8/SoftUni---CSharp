namespace _01.Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int smallestNum = Compare(num1,num2, num3);
            Console.WriteLine(smallestNum);

        }
        static int Compare(int num1, int num2, int num3)
        {
            int result = num1;                // int result = max.Value;
            if(num1<num2 && num1<=num3)       // if(num1 < result)
                result = num1;                // result = num1;
            else if (num2<num1 && num2<=num3) // if(num2 < result);
                result = num2;                // result = num2;
            else if (num3<num1 && num3<=num2) // if(num3 < result);
                result = num3;                // result = num3;
            return result;
            
        }
    }
} 