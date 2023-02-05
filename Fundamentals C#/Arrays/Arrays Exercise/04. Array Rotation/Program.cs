







int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
int n = int.Parse(Console.ReadLine());
int firstNum = inputNumbers[0];
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < inputNumbers.Length - 1; j++)
    {
        inputNumbers[j] = inputNumbers[j+1];
    }
    inputNumbers[inputNumbers.Length-1] = firstNum;
    firstNum = inputNumbers[0];
}
Console.WriteLine(string.Join(" ", inputNumbers));