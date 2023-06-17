using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }
        public Catalog(string name, int needed, string projects)
        {
            Name = name;
            NeededRenovators = needed;
            Project = projects;
            Renovators = new List<Renovator>();
        }
        public int Count => Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Type == null || renovator.Name == string.Empty || renovator.Type == string.Empty)
            {
                return $"Invalid renovator's information.";    
            }
            if (Renovators.Count == NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
                return "Invalid renovator's rate.";
            else
            {
                Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }

        }
        public bool RemoveRenovator(string name)
        {
            Renovator toRemove = Renovators.Find(x => x.Name == name);
            if (toRemove == null)
            {
                return false;
            }
                Renovators.Remove(toRemove);
                return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            return Renovators.RemoveAll(x => x.Type == type);
        }
        public Renovator HireRenovator(string name)
        {
            Renovator toHire = Renovators.Find(x => x.Name == name);
            if(toHire == null)
            {
                return null;
            }
            toHire.Hired = true;
            return toHire;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> toPay = Renovators.FindAll(x => x.Days >= days);
            return toPay;
        }
        public string Report()
        {
            
             StringBuilder sb = new StringBuilder();
            sb.AppendLine("Renovators available for Project");
            sb.AppendLine($"{Project}:");
            foreach (Renovator renovator in Renovators.Where(x => x.Hired != true))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
