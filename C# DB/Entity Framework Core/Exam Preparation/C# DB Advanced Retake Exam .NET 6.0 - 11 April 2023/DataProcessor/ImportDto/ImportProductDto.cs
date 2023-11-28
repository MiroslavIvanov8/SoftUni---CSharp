using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MaxLength(30)]
        [MinLength(9)]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Required]
        [Range(5.00,1000.00)]
        public decimal Price { get; set; }

        [JsonProperty("CategoryType")]
        [Required]
        [Range(0,4)]
        public int CategoryType { get; set; }

        [JsonProperty("Clients")]
        public int[] ClientIds { get; set; }
    }
}
