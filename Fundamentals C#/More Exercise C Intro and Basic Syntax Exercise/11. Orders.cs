

// ((daysInMonth * capsulesCount) * pricePerCapsule)



double numberOfOrders = double.Parse(Console.ReadLine());
double daysInMonth = 0;
double capsulesCount = 0;
double pricePerCapsule =0;

double price = 0;
double total = 0;

for (int i = 0; i < numberOfOrders; i++)
{
    
    pricePerCapsule = double.Parse(Console.ReadLine());
    daysInMonth =double.Parse(Console.ReadLine());
    capsulesCount =double.Parse(Console.ReadLine());

    price = (daysInMonth* capsulesCount)* pricePerCapsule;
    total += price;

    Console.WriteLine($"The price for the coffee is: ${price:f2}");
    price = 0;
}

Console.WriteLine($"Total: ${total:f2}");