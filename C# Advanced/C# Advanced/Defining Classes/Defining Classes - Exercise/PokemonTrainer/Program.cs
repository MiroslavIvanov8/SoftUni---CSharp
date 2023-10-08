using System.Linq.Expressions;
using System.Net;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main()
        {
            
            List<Trainer> trainers = new ();
            string command;
            while((command = Console.ReadLine())!="Tournament")
            {
                // "{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElemnt = info[2];
                int pokemonHealth = int.Parse(info[3]);
                                
                Pokemon pokemon = new Pokemon
                {
                    Name= pokemonName,
                    Element = pokemonElemnt,
                    Health= pokemonHealth,
                };

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = new Trainer() { Name = trainerName, Badges = 0, PokemonCollection = new List<Pokemon>() { pokemon } };
                    trainers.Add(trainer);
                }

                else
                {
                    Trainer trainer = trainers.Find(x => x.Name == trainerName);

                    trainer.PokemonCollection.Add(pokemon);
                }
            }

            string nextCommand;
            while ((nextCommand = Console.ReadLine()) != "End")
            {
                string type = nextCommand;

                foreach(var trainer in trainers)
                {

                    if (trainer.PokemonCollection.Any(x => x.Element == type))
                        trainer.Badges++;
                    else
                    {
                        trainer.PokemonCollection.ForEach(x => x.Health -= 10);
                        trainer.PokemonCollection.RemoveAll(x => x.Health <= 0);
                    }    
                }
                
            }

            var orderedTrainers = trainers.OrderByDescending(x => x.Badges);

            foreach(var trainer in orderedTrainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}