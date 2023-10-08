namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string command = string.Empty;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] commandArgs = command.Split();
                string type = commandArgs[0];
                if (type == "add")
                {
                    stack.Push(int.Parse(commandArgs[1]));
                    stack.Push(int.Parse(commandArgs[2]));

                }
                else if (type == "remove")
                {
                    int count = int.Parse(commandArgs[1]);
                    if (stack.Count < count)
                        continue;
                    else
                    {
                        for(int i =0;i<count;i++)
                        { 
                            stack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}