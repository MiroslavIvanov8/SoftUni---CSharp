using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ExportDto
{
    public class ExportClientDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NumberVat")]
        public string NumberVat { get; set; }
        
    }
}
