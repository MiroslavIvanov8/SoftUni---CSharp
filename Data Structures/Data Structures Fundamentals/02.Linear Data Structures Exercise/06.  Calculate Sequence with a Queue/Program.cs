namespace _06.__Calculate_Sequence_with_a_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            Queue<int> deqQueue = new Queue<int>();

            queue.Enqueue(number);
            List<int> numbers = new List<int>();

            numbers.Add(number);

            for (int i = number ; i < 18; i++)
            {
                int number1 = queue.Dequeue();
                int number2 = number1 + 1;
                int number3 =  2 * number1 + 1;
                int number4 = number1  + 2;

                queue.Enqueue(number2);
                queue.Enqueue(number3);
                queue.Enqueue(number4);

                numbers.Add(number2);
                numbers.Add(number3);
                numbers.Add(number4);
            }

            Console.WriteLine(string.Join(", ", numbers));
            
        }
    }
}
