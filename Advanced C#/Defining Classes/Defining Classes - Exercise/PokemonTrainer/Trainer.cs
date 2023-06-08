using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges = 0;
        public List<Pokemon> PokemonCollection { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"{this.Name} ");
            sb.Append($"{this.Badges} ");
            sb.Append($"{this.PokemonCollection.Count} ");
            
            return sb.ToString().Trim();
        }
    }
}
