int number = int.Parse(Console.ReadLine());
string text = string.Empty;
Stack<string> stack = new();

for (int i = 0; i < number; i++)
{
    string[] tokens = Console.ReadLine().Split();
    int command = int.Parse(tokens[0]);
    switch (command)
    {
        case 1:
            stack.Push(text);
            text += tokens[1];
            break;
        case 2:
            stack.Push(text);
            text = text.Remove(text.Length - int.Parse(tokens[1]), int.Parse(tokens[1]));
            break;
        case 3:
            int index = int.Parse(tokens[1]);
            Console.WriteLine(text[index-1]);
            break;
        case 4:
            text = stack.Pop();
            break;
    }
}