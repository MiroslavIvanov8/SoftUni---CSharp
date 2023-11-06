using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(Configuration.ProducerNameMaxLength)]
        public string Name { get; set; }

        public string? Pseudonym { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        
    }
}
