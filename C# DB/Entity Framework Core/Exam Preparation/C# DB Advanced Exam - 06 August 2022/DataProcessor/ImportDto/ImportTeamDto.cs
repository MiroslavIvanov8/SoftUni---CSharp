using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [JsonProperty("Name")]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression("[\\w\\d. -]+")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("Nationality")]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; }

        [Required]
        [JsonProperty("Trophies")]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; }
    }
}
