int yield = int.Parse(Console.ReadLine());
int total = 0;
int days = 0;
while (yield >= 100)
{
    days++;
    total+= yield;
    total -= 26;
    yield -= 10;
    if (yield < 100)
    {
        total -= 26;
        break;
    }
}
Console.WriteLine(days);
Console.WriteLine(total);
