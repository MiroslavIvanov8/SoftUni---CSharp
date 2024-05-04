namespace _07._Sequence_N___M
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = numbers[0];
            int m = numbers[1];

            Queue<Item<int>> queue = new Queue<Item<int>>();
            List<int> result = new List<int>();
            Item<int> item = new Item<int>(n); 

            queue.Enqueue(item);

            while (queue.Any())
            {   
                item = queue.Dequeue();
                if (item.Value < m)
                {
                    queue.Enqueue(new Item<int>((item.Value + 1), item));
                    queue.Enqueue(new Item<int>((item.Value + 2), item));
                    queue.Enqueue(new Item<int>((item.Value * 2), item));

                }
                else if(item.Value == m)
                {
                    while (item != null)
                    {
                        result.Add(item.Value);
                        item = item.Previous;
                    }

                    result.Reverse(0, result.Count);
                    Console.WriteLine(string.Join(" -> ", result));
                    return;
                }

            }
        }

        class Item<T>
        {
            public Item(T value, Item<T> previous = null)
            {
                this.Value = value;
                this.Previous = previous;
            }
            public T Value { get; set; }
            public Item<T> Previous { get; set; }
        }
    }
}
