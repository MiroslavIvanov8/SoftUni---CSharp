int bulletPrice = int.Parse(Console.ReadLine());
int barrelSize = int.Parse(Console.ReadLine());

Stack<int> bullets = new(
    Console.ReadLine()
        .Split()
        .Select(int.Parse));

Queue<int> locks = new(
    Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse));

int intelligence = int.Parse(Console.ReadLine());


