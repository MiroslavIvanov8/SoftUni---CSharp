namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                int number = int.Parse(Console.ReadLine());
            try
            {
                if (number < 0)
                    throw new ArithmeticException("Invalid number.");

                Console.WriteLine(Math.Sqrt(number));
            }

            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}