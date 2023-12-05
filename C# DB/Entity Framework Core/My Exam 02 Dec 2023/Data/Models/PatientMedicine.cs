using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Medicine))]
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
