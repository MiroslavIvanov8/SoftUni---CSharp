namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            GetMiddle(input);            
        }

        static void GetMiddle(string input)
        {
            string middleChar = string.Empty;
            int middleCharPosition =0;
            if (input.Length % 2 != 0)
            {                                          // 0 1 2 3 4 
                middleCharPosition = input.Length / 2; // Math.Ceiling  5/2 =2.5=> Math.Ceiling(2.5)=> 3
                middleChar = input[middleCharPosition].ToString();
                
            }            

            else // if input is even count we have 2 middle chars 
            {
                middleCharPosition = input.Length / 2 - 1;
                middleChar = input[middleCharPosition].ToString() + input[middleCharPosition+1] ;

            }
            Console.WriteLine(middleChar);
        }
    }
}