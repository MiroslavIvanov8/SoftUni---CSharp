namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Box> boxes = new List<Box>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] boxInfo = input.Split();

                

                string serialNum = boxInfo[0];
                string itemName = boxInfo[1];
                int itemQuantity = int.Parse(boxInfo[2]);
                decimal itemPrice = decimal.Parse(boxInfo[3]);

                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice,
                };


                Box box = new Box
                {
                    SerialNumber = serialNum,
                    Item = item,
                    ItemQuantity = itemQuantity,
                    PricePerBox = itemPrice * itemQuantity,
                };

                boxes.Add(box);

            }
            //{ boxSerialNumber}
            //-- { boxItemName} – ${ boxItemPrice}: { boxItemQuantity}
            //-- ${ boxPrice}

            
            foreach (Box box in boxes.OrderByDescending(x => x.PricePerBox))
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PricePerBox:f2}");

            }
        }
    }


    class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PricePerBox { get; set; }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}