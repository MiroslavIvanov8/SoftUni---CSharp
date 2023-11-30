using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class ExportFootballerDto
    {
        public string Name { get; set; }

        public string Position { get; set; }
        
    }
}
