namespace _04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine()
                .Split();

            int sum = 0;

            foreach(string number in numbers)
            {
                try
                {
                    int currNum = int.Parse(number);

                    sum += currNum;
                } 
                catch(FormatException)
                {
                    Console.WriteLine($"The element '{number}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{number}' is out of range!");
                }
                catch(Exception)
                {
                }
                finally
                {
                    Console.WriteLine($"Element '{number}' processed - current sum: {sum}");
                }
                    
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
                


    