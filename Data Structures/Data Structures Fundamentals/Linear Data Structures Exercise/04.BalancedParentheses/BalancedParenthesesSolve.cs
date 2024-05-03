namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 == 1)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < parentheses.Length; i++)
            {
                char currentChar = default;
                switch (parentheses[i])
                {
                    case '}':
                        currentChar = '{';
                        break;
                    case ']':
                        currentChar = '[';
                        break;
                    case ')':
                        currentChar = '(';
                        break;
                    default:
                        stack.Push(parentheses[i]);
                        continue;

                }

                if (stack.Pop() == currentChar)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
