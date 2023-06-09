using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
          public string Model { get; set; }
          public int Capacity { get; set; }
          private List<CPU> multiprocessor;
          public List<CPU> Multiprocessor
          {
              get { return multiprocessor; }
              set { multiprocessor = value; }
          }

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();            
        }

        public int Count => multiprocessor.Count;
        public void Add(CPU cpu)
        {
            if(Count>=Capacity)
            {
                return;
            }
            multiprocessor.Add(cpu);
        }
        public bool Remove(string brand)
        { 
            if (multiprocessor.Any(x => x.Brand == brand))
            {
                multiprocessor.Remove(multiprocessor.First(x => x.Brand == brand));
                return true;
            }
            else
                return false;

            
        }
        public CPU MostPowerful()
        {
            return multiprocessor.OrderByDescending(x=>x.Frequency).First();
        }
        public CPU GetCPU(string brand)
        {
            if (multiprocessor.Any(x => x.Brand == brand))
            {
                return multiprocessor.First(x => x.Brand == brand);
            }
            else 
                return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach(CPU cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd(); ;
        }
    }
}
