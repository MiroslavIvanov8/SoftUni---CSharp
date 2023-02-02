
int n = int.Parse(Console.ReadLine());
SignOfInteger(n);

static void SignOfInteger(int number)
{
    if(number>0)
        Console.WriteLine($"The number {number} is positive.");
    if (number < 0)
        Console.WriteLine($"The number {number} is negative.");
    else 
        Console.WriteLine($"The number {number} is zero.");
}