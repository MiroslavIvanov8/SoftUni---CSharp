int numberOfKegs = int.Parse(Console.ReadLine());
double bestVolume = 0;
string bestModel= string.Empty;
for (int i = 1; i <= numberOfKegs; i++)
{
    string model = Console.ReadLine();
    double radius = double.Parse(Console.ReadLine());
    double heigh = double.Parse(Console.ReadLine());
    double currentVolume = Math.PI * Math.Pow(radius, 2) * heigh;
    if (currentVolume>bestVolume)
    { 
        bestVolume= currentVolume;
        bestModel = model;
    }
    currentVolume = 0;
}
Console.WriteLine(bestModel);