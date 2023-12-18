int wildth = int.Parse(Console.ReadLine());
int height = int.Parse(Console.ReadLine());

double area = GetArea(wildth, height);

double GetArea(int wildth, int height)
{
    return wildth * height;
}