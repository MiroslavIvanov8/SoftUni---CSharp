namespace _03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = new Dictionary<string, Plant>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plantName = input[0];
                int rarity = int.Parse(input[1]);
                
                Plant plant = new Plant() { Rarity = rarity, Rating = new List<int>() };
                plants.Add(plantName, plant);
            }
            string info = string.Empty;
            while ((info = Console.ReadLine()) != "Exhibition")
            {
                //	"Rate: {plant} - {rating}"
                string[] infoArgs = info.Split(": ");
                string commandType = infoArgs[0];
                string[] commandArgs= infoArgs[1].Split(" - ");
                string name = commandArgs[0];
                if (!plants.ContainsKey(name))
                {
                    Console.WriteLine("error");
                    continue;
                }

                if (commandType == "Rate")
                { 
                    int rating = int.Parse(commandArgs[1]);
                    plants[name].Rating.Add(rating);

                }
                if (commandType == "Update")
                {
                    int rarity = int.Parse(commandArgs[1]);
                    plants[name].Rarity= rarity;
                }
                if (commandType == "Reset")
                {
                    plants[name].Rating = new List<int>();
                }
            }
            Console.WriteLine("Plants for the exhibition:");
            double averageRating = 0;
            foreach (var plant in plants)
            {
                if(plant.Value.Rating.Count>0)
                averageRating = plant.Value.Rating.Average();

                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:f2}");
            }

        } 
    }
    class Plant
    {
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
    }
}