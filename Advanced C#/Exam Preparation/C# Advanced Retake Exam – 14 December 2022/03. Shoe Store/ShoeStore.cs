using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        private List<Shoe> shoes;

        public List<Shoe> Shoes
        {
            get { return shoes; }
            set { shoes = value; }
        }
        public ShoeStore(string name, int capacity)
        {
            Name = name;
            StorageCapacity = capacity;
            shoes = new List<Shoe>();
        }

        public int Count => shoes.Count;
        public string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            else
            {
                shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
                
            }
        }
        public int RemoveShoes(string material)
        {

            return shoes.RemoveAll(x => x.Material == material);
        }
        public List<Shoe> GetShoesByType(string type)
        { 
            type = type.ToLower();
            List<Shoe> foundShoes = new List<Shoe>();
            foundShoes = shoes.FindAll(x => x.Type == type);
            return foundShoes;
        }
        public Shoe GetShoeBySize(double size)
        {
            Shoe foundShoe = shoes.First(x => x.Size == size);
            return foundShoe;
        }
        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            bool foundMatch = false;
            sb.AppendLine($"Stock list for size {size} - {type} shoes:");
            foreach (Shoe shoe in shoes)
            {
                if (shoe.Type == type && shoe.Size == size)
                {
                    //Size 42, textile Salomon hiking shoe.
                    sb.AppendLine($"Size {shoe.Size}, {shoe.Material} {shoe.Brand} {shoe.Type} shoe.");
                    foundMatch = true;
                }
            }
            if (!foundMatch)
                return "No matches found!";
            else
            {
               return sb.ToString().TrimEnd();
            }
        }
    }

}
