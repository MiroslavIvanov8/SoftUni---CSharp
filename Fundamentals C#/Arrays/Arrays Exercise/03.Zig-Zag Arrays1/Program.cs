int number = int.Parse(Console.ReadLine());
int[] array1 = new int[number];
int[] array2 = new int[number]; 
for (int i = 0; i < number; i++)
{
    int[] inputNumbers = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();
    if (i % 2 == 0)
    {
        array1[i] += inputNumbers[0];
        array2[i] += inputNumbers[1];
    }
    else
    {
        array1[i] += inputNumbers[1];
        array2[i] += inputNumbers[0];
    }
}
Console.Write(string.Join(" ", array1));
Console.Write(string.Join(" ", array2));