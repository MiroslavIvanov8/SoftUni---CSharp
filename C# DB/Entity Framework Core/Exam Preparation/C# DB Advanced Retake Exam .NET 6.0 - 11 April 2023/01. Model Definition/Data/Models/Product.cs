using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        // TODO MaxLength might cause issue here !!!
        public decimal Price { get; set; }

        [Required]
        public virtual CategoryType CategoryType { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }
    }
}
