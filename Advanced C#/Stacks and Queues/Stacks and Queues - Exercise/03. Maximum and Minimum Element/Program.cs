namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new();
            for (int i = 0; i < count; i++)
            {
                int[] arr = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (arr[0] == 1)
                {
                    int number = arr[1];
                    stack.Push(number);
                }
                else if (arr[0] == 2)
                {
                    stack.Pop();
                }
                else if (arr[0] == 3)
                {
                    if (!stack.Any())
                        continue;
                    else
                        Console.WriteLine(stack.Max());
                }
                else if (arr[0] == 4)
                {
                    if (!stack.Any())
                        continue;
                    else
                        Console.WriteLine(stack.Min());
                }                
            }
            Console.WriteLine(string.Join(", ", stack));

        }
    }
}