namespace _01._Burger_Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int citiesNum = int.Parse(Console.ReadLine());
            string cityName;
            decimal currentProfit = 0;            
            decimal expenses = 0;
            decimal totalProfit = 0;
            bool burgerDay= false;
            int days = 0;
            for (int i = 1; i <= citiesNum; i++)
            {
                
                cityName= Console.ReadLine();
                currentProfit= decimal.Parse(Console.ReadLine());
                expenses= decimal.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    burgerDay = true;
                }
                if (i % 5 == 0)
                {
                    burgerDay= false;
                    currentProfit *= 0.90m;
                }
                if (burgerDay)
                {
                    burgerDay = false;
                    expenses += expenses * 0.50m;
                }
                currentProfit -= expenses;
                totalProfit += currentProfit;
                Console.WriteLine($"In {cityName} Burger Bus earned {currentProfit:f2} leva.");
                currentProfit= 0;
            }
            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
       }
    }
}