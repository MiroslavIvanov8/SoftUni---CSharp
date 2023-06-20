using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }
        public bool AddChild(Child child)
        {
            if (Registry.Count == Capacity)
            {
                return false;

            }
            else
            {
                Registry.Add(child);
                return true;
            }
        }
        public bool RemoveChild(string name)
        {
            string[] fullName = name.Split(" ");
            string firstName = fullName[0];
            string lastName = fullName[1];
            Child child = Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (Registry.Contains(child))
            {
                Registry.Remove(child);
                return true;
            }
            else
                return false;
        }
        public int ChildrenCount => Registry.Count;
        
        public Child GetChild(string childFullName)
        {
            string[] fullName = childFullName.Split(" ");
            string firstName = fullName[0];
            string lastName = fullName[1];
            Child child = Registry.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (Registry.Contains(child))
            {
                return child;
            }
            else
                return null; 
        }
        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {this.Name}:");
            foreach (Child child in Registry.OrderByDescending(x=>x.Age).ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        
    }
}   
