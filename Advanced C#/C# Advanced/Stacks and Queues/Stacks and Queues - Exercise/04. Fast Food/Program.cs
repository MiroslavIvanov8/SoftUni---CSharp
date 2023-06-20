int foodInStock = int.Parse(Console.ReadLine());

int[] orders = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Queue<int> queue = new(orders);
bool ordersCompeted = true;
Console.WriteLine(queue.Max());

while (queue.Any())
{
    int currOrder = queue.Peek();
    if (foodInStock >= currOrder)
    {
        foodInStock-=queue.Dequeue();
    }
    else if (foodInStock < currOrder)
    {
        ordersCompeted = false;
        break;
    }
}

if(ordersCompeted)
    Console.WriteLine("Orders complete");
else if (!ordersCompeted)
    Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
