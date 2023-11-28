using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductDto
    {
        [JsonProperty("Name")] 
        public string Name { get; set; } 

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Clients")]
        public ExportClientDto[] Clients { get; set; }
    }
}
