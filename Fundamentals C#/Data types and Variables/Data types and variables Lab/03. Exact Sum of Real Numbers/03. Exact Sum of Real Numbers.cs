int num = int.Parse(Console.ReadLine());
decimal sum = 0;
for (int i = 0; i < num; i++)
{ 
    decimal numbers = decimal.Parse(Console.ReadLine());
    sum += numbers;
}
Console.WriteLine(sum);