using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [JsonProperty("Name")]
        [MinLength(4)]
        [MaxLength(40)]
        public string Name { get; set; }

        [JsonProperty("NumberOfHalls")]
        [Range(1,10)]
        public sbyte NumberOfHalls { get; set; }

        [JsonProperty("Director")]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}
