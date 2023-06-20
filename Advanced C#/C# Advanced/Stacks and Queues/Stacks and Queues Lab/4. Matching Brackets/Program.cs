namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                    stack.Push(i);
                if (input[i] == ')')
                {
                    //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
                    int start = stack.Pop();
                    int end = i;
                    Console.WriteLine(input.Substring(start, end - start+1));
                }
                
            }
        }
    }
}