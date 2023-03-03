namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mining = new Dictionary<string, int>();
            int counter = 0;
             
            string resourse;
            int quantity = 0;
            while (true)            
            {
                
                resourse = Console.ReadLine();
                if (resourse == "stop")
                    break;
                quantity = int.Parse(Console.ReadLine());

                if (!mining.ContainsKey(resourse))
                {
                    mining.Add(resourse, quantity);
                }
                else
                    mining[resourse] += quantity;

            }
            foreach (var item in mining)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
        
    }
}