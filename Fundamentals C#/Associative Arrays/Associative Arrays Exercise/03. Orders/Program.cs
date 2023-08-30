namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<double>> items= new Dictionary<string,List<double>>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] info = input
                .Split(" ")
                .ToArray();
                string itemType = info[0];
                double price = double.Parse(info[1]);
                double quantity = double.Parse(info[2]);

                if (!items.ContainsKey(itemType))
                {
                    items.Add(itemType, new List<double>());
                    List<double> priceAndQuantiy = new List<double>();
                    priceAndQuantiy.Add(price);
                    priceAndQuantiy.Add(quantity);
                    items[itemType] = priceAndQuantiy;
                }
                else if (items.ContainsKey(itemType)) // case where already have that item i nthe list we need to manipulate the price and the quantity
                {
                    // price overwriten, quantity added
                    List<double> priceAndQuantity = items[itemType];
                    priceAndQuantity[0]= price;
                    priceAndQuantity[1]+= quantity;
                }
            }
            // "{productName} -> {totalPrice}"
            foreach (var product in items)
            {
                double sum = product.Value[1] * product.Value[0];
                

                Console.WriteLine($"{product.Key} -> {sum:f2}");
            }
        }


    }
}