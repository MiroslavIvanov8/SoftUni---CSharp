string product = Console.ReadLine();
int quantity = int.Parse(Console.ReadLine());

Price(product, quantity);

static void Price(string item,int number)
{
   double price = 0;
    if (item == "coffee")
        price = 1.50;
    else if (item == "water")
        price = 1.00;
    else if (item == "coke")
        price = 1.40;
    else if (item == "snacks")
        price = 2.00;

    price= price * number;
   Console.WriteLine($"{price:f2}");
}