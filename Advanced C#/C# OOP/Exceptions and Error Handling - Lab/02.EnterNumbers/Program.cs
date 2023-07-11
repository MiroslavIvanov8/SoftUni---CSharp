namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();
            
            ReadNumbers(1,100,numbers);

            Console.WriteLine(string.Join(", ",numbers));
            
        }

        private static void ReadNumbers(int start, int end, List<int>numbers)
        {
            if (numbers.Count == 10)
                return;
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number <= start || number>=100)
                    throw new ArgumentOutOfRangeException($"Your number is not in range {start} - 100!");

                start = number;

                numbers.Add(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                ReadNumbers(start, end,numbers);
            }
            
        }
    }
}