namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(",");
                string command = info[0];
                string carNumber = info[1];
                if (command == "IN")
                {
                    set.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    set.Remove(carNumber);
                }
            }
            if (set.Count > 0)
                foreach (string car in set)
                    Console.WriteLine(car);
            else
                Console.WriteLine("Parking Lot is Empty");
        }
    }
}