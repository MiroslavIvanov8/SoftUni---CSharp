
double[] inputNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
for (int i = 0; i < inputNumbers.Length; i++)
{
    if (inputNumbers[i] == 0)
    {
        Console.WriteLine($"{inputNumbers[i]} => 0");
    }
    else
        Console.WriteLine($"{inputNumbers[i]} => {(int)Math.Round(inputNumbers[i], MidpointRounding.AwayFromZero)}");
}