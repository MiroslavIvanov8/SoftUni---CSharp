namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int carsToPass = n;
            Queue<string> cars = new Queue<string>();
            string command = string.Empty;
            int counter = 0;
            while ((command=Console.ReadLine()) !="end")
            {
                if (command == "green")
                {
                    if(cars.Count<carsToPass)
                        carsToPass = cars.Count;

                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;
                        
                    }
                    carsToPass = n;
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}