namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbersAsString =Console.ReadLine();
            int evenSum = GetTheSum(numbersAsString, true);
            int oddSum = GetTheSum(numbersAsString, false);
            Console.WriteLine(evenSum *oddSum);
        }   
         static int GetTheSum(string numbers, bool isEven)
        {
            int sum = 0;            
            for(int i =0;i<numbers.Length;i++)                
            {
                if (numbers[i] > 47 && numbers[i] < 57)
                {
                    int currentNum = int.Parse(numbers[i].ToString());
                    if (currentNum % 2 == 0 && isEven)
                    {
                        sum += currentNum;
                    }
                    else if (currentNum % 2 != 0 != isEven)
                    {
                        sum += currentNum;
                    }
                }              
   
            }
            return sum;
         }
    }
}