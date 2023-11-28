using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Invoices.DataProcessor.ImportDto
{
    
    public class ImportInvoiceDto
    {
        [JsonProperty("Number")]
        [Required]
        [Range(1_000_000_000, 1_500_000_000)]
        public int Number { get; set; }

        [JsonProperty("IssueDate")]
        [Required]
        public string IssueDate { get; set; }

        [JsonProperty("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [JsonProperty("Amount")]
        [Required]
        public decimal Amount { get; set; }

        [JsonProperty("CurrencyType")]
        [Required]
        [Range(0,2)]
        public int CurrencyType { get; set; }

        [JsonProperty("ClientId")]
        [Required]
        public int ClientId { get; set; }

    }
}
