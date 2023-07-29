namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> citizensAndRebels = new();

            string cmd;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);
                if (info.Length == 4)
                {
                    string id = info[2];
                    string birthDate = info[3];
                    IBuyer citizen = new Citizen(name, age, id, birthDate);
                    citizensAndRebels[name] = citizen;
                }
                else if (info.Length == 3)
                {
                    string group = info[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    citizensAndRebels[name] = rebel;
                }
            }
            string buyerName;
            int foodSum = 0;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                if (citizensAndRebels.ContainsKey(buyerName))
                {
                    foodSum += citizensAndRebels[buyerName].BuyFood();
                }
            }
            Console.WriteLine(foodSum);
        }
    }
}