int stop = int.Parse(Console.ReadLine());
for (int i = 2; i <= stop; i++)
{
    bool isPrime = true;
    for (int devided= 2; devided < i; devided++)
    {
        if (i % devided == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
    Console.WriteLine($"{i} -> true");
    else
        Console.WriteLine($"{i} -> false");
}
