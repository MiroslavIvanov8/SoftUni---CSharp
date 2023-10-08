namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaInfo[1];
            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string doughType = doughInfo[1];
            string bakingStyle = doughInfo[2];
            double grams = double.Parse(doughInfo[3]);
            double calories = 0;
            try
            {
                
                Pizza pizza = new(pizzaName);
                Dough dough = new(doughType, bakingStyle, grams);
                calories += dough.CalcCalories();
                
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string type = toppingInfo[1];
                    double gram = double.Parse(toppingInfo[2]);
                    Topping topping = new(type, gram);
                    pizza.AddToping(topping);
                    calories += topping.CalcCalories();
                }
           }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
           
            Console.WriteLine($"{pizzaName} - {calories:F2} Calories.");
        }
    }
}