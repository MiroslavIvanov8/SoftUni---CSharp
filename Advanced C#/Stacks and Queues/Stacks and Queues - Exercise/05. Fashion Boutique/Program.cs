int[] input = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Stack<int> clothes = new(input);
int rackCapacity = int.Parse(Console.ReadLine());
int currentRackSize = rackCapacity;
int racksCount = 1;
while (clothes.Any())
{
    currentRackSize-=clothes.Peek();
    if (currentRackSize < 0)
    {
        currentRackSize= rackCapacity;
        racksCount++;
        continue;
    }
    clothes.Pop();
}
Console.WriteLine(racksCount);