double number = double.Parse(Console.ReadLine());
double power = double.Parse(Console.ReadLine());
double result =GetPower(number, power);
Console.WriteLine(result);
 double GetPower(double number, double power)
{
    double result = 0;
    result = Math.Pow(number, power);
    return result;
}