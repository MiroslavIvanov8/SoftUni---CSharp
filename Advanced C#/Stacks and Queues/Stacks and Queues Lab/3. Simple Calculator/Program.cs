namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>();
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);

                if (stack.Count == 3)
                {
                    int first = int.Parse(stack.Pop().ToString());
                    var sign = stack.Pop();
                    int second = int.Parse(stack.Pop().ToString());

                    if (sign == "+")
                    {
                        sum = first + second;
                        stack.Push(sum.ToString());
                    }
                    if (sign == "-")
                    {
                        sum = second - first;
                        stack.Push(sum.ToString());
                    }
                }
            }
            Console.WriteLine(stack.Pop());
        }   
    }
}