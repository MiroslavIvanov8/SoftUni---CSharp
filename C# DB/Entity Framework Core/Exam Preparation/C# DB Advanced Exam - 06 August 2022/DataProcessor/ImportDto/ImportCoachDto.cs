using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public ImportFootballerDto[] Footballers { get; set; }

    }
}
