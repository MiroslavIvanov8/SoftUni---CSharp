namespace AnimalFarm
{
    using System;
    using System.Collections.Generic;
    using AnimalFarm.Models;
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            List<Chicken> chickens= new List<Chicken>();
            try
            {
                Chicken chicken = new Chicken(name, age);
                chickens.Add(chicken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach(var chicken in chickens)
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");             
                
        }
    }
}
