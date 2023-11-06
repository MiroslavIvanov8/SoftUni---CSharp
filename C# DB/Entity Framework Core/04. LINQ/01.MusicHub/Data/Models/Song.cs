using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using MusicHub.Data.Models.Enums;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(Configuration.SongNameMaxLength)]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreatedOn { get; set; }
        public Genre Genre { get;set;}
        public decimal Price { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }
        
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }



    }
}
