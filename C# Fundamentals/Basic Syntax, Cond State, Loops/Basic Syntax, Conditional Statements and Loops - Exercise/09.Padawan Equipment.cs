double budget = double.Parse(Console.ReadLine());
double students = double.Parse(Console.ReadLine());
double lightsaberPr = double.Parse(Console.ReadLine());
double robePr = double.Parse(Console.ReadLine());
double beltPr = double.Parse(Console.ReadLine());

double priceAll = 0;
double lightsaberCount = students + students * 0.10;

double beltCount1 = students / 6;
double beltCount = students;
if(beltCount1>= 1)
{
    beltCount -= beltCount1;
}

lightsaberCount = Math.Ceiling(lightsaberCount);
beltCount= Math.Ceiling(beltCount);
priceAll= lightsaberCount*lightsaberPr + students* robePr + beltCount* beltPr;

if (priceAll <= budget)
{
    Console.WriteLine($"The money is enough - it would cost {priceAll:f2}lv.");
}
else if (priceAll > budget)
{
    Console.WriteLine($" John will need {(priceAll- budget):f2}lv more.");
}