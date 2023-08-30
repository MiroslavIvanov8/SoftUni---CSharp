using static _03._P_rates.Program;

namespace _03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string info = string.Empty;
            var cities = new Dictionary<string, Town>();
            while ((info = Console.ReadLine()) != "Sail")
            {
                string[] infoArgs = info.Split("||");
                string cityName = infoArgs[0];
                int citypopulation = int.Parse(infoArgs[1]);
                int cityGold = int.Parse(infoArgs[2]);
                if (cities.ContainsKey(cityName))
                {
                    cities[cityName].Population += citypopulation;
                    cities[cityName].Gold+= cityGold;
                }
                else
                {
                    Town town = new Town() { Population = citypopulation, Gold = cityGold };
                    cities.Add(cityName, town);
                }

            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split("=>");

                if (commandArgs[0] == "Plunder")
                {
                    string cityName = commandArgs[1];
                    int peopleToBeKilled = int.Parse(commandArgs[2]);
                    int goldToSteal = int.Parse(commandArgs[3]);
                    if (cities[cityName].Population - peopleToBeKilled <= 0 || cities[cityName].Gold - goldToSteal <= 0)
                    {
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                        cities.Remove(cityName);
                    }

                    else
                    {
                        cities[cityName].Population -= peopleToBeKilled;
                        cities[cityName].Gold-= goldToSteal;
                        Console.WriteLine($"{cityName} plundered! {goldToSteal} gold stolen, {peopleToBeKilled} citizens killed.");
                    }
                    

                }
                else if (commandArgs[0] == "Prosper")
                {
                    string cityName = commandArgs[1];
                    int goldToAdd = int.Parse(commandArgs[2]);
                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    else
                    {
                        cities[cityName].Gold += goldToAdd;
                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {cityName} now has {cities[cityName].Gold} gold.");
                    }
                }
            }
            if(cities.Count>0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else 
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");

        }
        public class Town
        {
            public int Population { get; set; }
            public int Gold { get; set; }
        }
    }
}