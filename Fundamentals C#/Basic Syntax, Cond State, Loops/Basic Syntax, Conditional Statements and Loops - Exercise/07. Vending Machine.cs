string input = string.Empty;
double money = 0;
while ((input = Console.ReadLine()) != "Start")
{
    double coins = double.Parse(input);
    if (coins == 1 || coins == 2 || coins == 0.1 || coins == 0.5)
    {
        money += coins;
    }
    else
    {
        Console.WriteLine($"Cannot accept {input}");
    }
}
string food=string.Empty;
while ((food = Console.ReadLine()) != "End")
{        
        
    if (food == "Nuts")
    {
        if (money >= 2)
        {
            Console.WriteLine("Purchased nuts");
            money -= 2;
        }
        else
        {
            Console.WriteLine($"Sorry, not enough money");

        }

    }
    else if (food == "Water")
    {
        if (money >= 0.7)
        {
            Console.WriteLine("Purchased water");
            money -= 0.7;
        }
        else
        {
            Console.WriteLine($"Sorry, not enough money");

        }
    }
    else if (food == "Crisps")
    {      
        if (money >= 1.5)
        { 
            money -= 1.5;
            Console.WriteLine("Purchased crisps");
        }
        else
        {
            Console.WriteLine($"Sorry, not enough money");

        }
    }
    else if (food == "Soda")
    {
        if (money >= 0.8)
        {
            money -= 0.8;
            Console.WriteLine($"Purchased soda");
        }
        else
        {
            Console.WriteLine($"Sorry, not enough money");

        }
    }
    else if (food == "Coke")
    {        
        if (money >= 1)
        {
            money -= 1;
            Console.WriteLine("Purchased coke");    
        }
        else
        {
            Console.WriteLine($"Sorry, not enough money");

        }
    }
    else 
    {
        Console.WriteLine("Invalid product");
    }

}
Console.WriteLine($"Change: {money:f2}");