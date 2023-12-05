using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketDto
    {
        [JsonProperty("Price")]
        [Range(1.00,100.00)]
        public decimal Price { get; set; }

        [JsonProperty("RowNumber")]
        [Range(1,10)]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}
