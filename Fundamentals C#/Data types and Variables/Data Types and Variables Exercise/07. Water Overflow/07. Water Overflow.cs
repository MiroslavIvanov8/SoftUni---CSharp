int times = int.Parse(Console.ReadLine());
int capacity = 255;
int poured = 0;
for (int i = 0; i < times; i++)
{
    int litres = int.Parse(Console.ReadLine());
    if (litres <= capacity - poured)
    {
        poured += litres;
    }
    else
        Console.WriteLine("Insufficient capacity!");    
}
Console.WriteLine(poured);