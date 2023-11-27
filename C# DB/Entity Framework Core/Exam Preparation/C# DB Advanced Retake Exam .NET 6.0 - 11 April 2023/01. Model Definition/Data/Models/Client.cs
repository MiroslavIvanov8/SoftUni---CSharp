using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.Invoices = new HashSet<Invoice>();
            this.Addresses = new HashSet<Address>();
            this.ProductsClients = new HashSet<ProductClient>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string NumberVat { get; set; }


        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }

    }
}
