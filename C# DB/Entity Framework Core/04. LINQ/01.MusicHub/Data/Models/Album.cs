using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(Configuration.AlbumNameMaxLength)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price => Songs.Sum(x => x.Price); // TODO calc the price of song collection

        [ForeignKey(nameof(Producer))] 
        public int? ProducerId { get; set; } 
        public virtual Producer Producer { get; set; }

        // TODO navigational props 
        public virtual ICollection<Song> Songs { get; set; }


    }
}
