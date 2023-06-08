using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {

		public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public Magazine(string type, int capacity)
        { 
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if(Capacity>Clothes.Count)
                Clothes.Add(cloth);
        }

        public bool RemoveCloth(string color)
        {
            foreach(Cloth cloth in Clothes)
            {
                if (cloth.Color == color)
                {
                    Clothes.Remove(cloth);
                    return true;
                }
            }
            return false;
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.OrderBy(x=>x.Size).First();
        }  

        public Cloth GetCloth(string color)
        {
            return Clothes.Find(x => x.Color == color);
             
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (Cloth cloth in Clothes.OrderBy(x=>x.Size))
            {
                sb.AppendLine($"{cloth.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
