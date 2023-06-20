namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Queue<string> kids = new Queue<string>(names);
            int number = int.Parse(Console.ReadLine());
            int counter = 0;
            while (kids.Count > 1)
            {
                counter++;
                string currentKid = kids.Dequeue();
                if (counter == number)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    counter = 0;
                }
                else
                {
                    kids.Enqueue(currentKid);
                }
                
            }
            Console.WriteLine($"Last is {string.Join(" ",kids)}");
        }
    }
}