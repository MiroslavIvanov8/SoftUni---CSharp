using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class ImportCarDto
    {
        public ImportCarDto()
        {
            this.PartsId = new HashSet<int>();
        }

        [JsonProperty("make")]
        public string Make { get; set; } = null!;

        [JsonProperty("model")]
        public string Model { get; set; } = null!;

        [JsonProperty("traveledDistance")]
        public int TraveledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsId { get; set; } = null!;

    }
}
