string parentheses = Console.ReadLine();
Stack<char> stack = new();
foreach (char parentese in parentheses)
{

    switch (parentese)
    {
        case '{':
        case '[':
        case '(':
            stack.Push(parentese);
            break;
        case '}':
            if (stack.Count == 0 || stack.Pop() != '{')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case ']':
            if (stack.Count == 0 || stack.Pop() != '[')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
        case ')':
            if (stack.Count == 0 || stack.Pop() != '(')
            {
                Console.WriteLine("NO");
                return;
            }
            break;
    }
}
if (stack.Count == 0)
    Console.WriteLine("YES");
