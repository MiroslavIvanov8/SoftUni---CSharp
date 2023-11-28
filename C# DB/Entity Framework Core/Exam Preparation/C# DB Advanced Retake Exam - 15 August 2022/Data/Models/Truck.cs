using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key] public int Id { get; set; }

        [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [StringLength(ValidationConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; }
        
        public int TankCapacity  { get; set; }
        public int 	CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [ForeignKey(nameof(Despatcher))]
        public int DespatcherId  { get; set; }
        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
