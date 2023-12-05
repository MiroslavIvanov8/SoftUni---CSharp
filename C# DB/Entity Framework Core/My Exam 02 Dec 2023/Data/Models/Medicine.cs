using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Data.Models.Enums;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.PatientsMedicines = new HashSet<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Producer { get; set; }

        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}
