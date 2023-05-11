namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArgs = input.Split(", ");
                if (!shops.ContainsKey(inputArgs[0]))
                {
                    shops.Add(inputArgs[0], new Dictionary<string, double>());
                }
                shops[inputArgs[0]].Add(inputArgs[1], double.Parse(inputArgs[2]));

            }
            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {

                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}

