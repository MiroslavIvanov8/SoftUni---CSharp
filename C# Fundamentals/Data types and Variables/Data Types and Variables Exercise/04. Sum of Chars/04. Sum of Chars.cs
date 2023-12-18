int numberOfSymbols = int.Parse(Console.ReadLine());
int totalSum = 0;
for (int i = 0; i < numberOfSymbols; i++)
{
    char symbol = char.Parse(Console.ReadLine());
    Console.WriteLine(symbol);
    Console.WriteLine((int)symbol);
    totalSum += symbol;
}
Console.WriteLine($"The sum equals: {totalSum}");