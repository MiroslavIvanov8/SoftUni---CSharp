using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            if(Vehicles.Count()<Capacity)
                Vehicles.Add(vehicle);
        }
        public bool RemoveVehicle(string vin)
        {
            Vehicle toRemove = Vehicles.Find(x => x.VIN == vin);
            if (toRemove != null)
            { 
                Vehicles.Remove(toRemove);
                return true;
            }
            else
                return false;
        }
        public int GetCount()
        { 
            return Vehicles.Count();
        }
        public Vehicle GetLowestMileage()
        {
            List<Vehicle> list = Vehicles.OrderBy(x=>x.Mileage).ToList();
            Vehicle vehichle = list.First();
            return vehichle;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in Vehicles)
                sb.AppendLine(vehicle.ToString());

            return sb.ToString().TrimEnd();
        }
    }

}
