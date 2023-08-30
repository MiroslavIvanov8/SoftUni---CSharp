// See https://aka.ms/new-console-template for more information




int start = int.Parse(Console.ReadLine());
int stop = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = start; i <= stop; i++)
{
    Console.Write($"{i} ");
    sum += i;
    if(i==stop)
        Console.WriteLine();
}
Console.WriteLine($"Sum: {sum}");
