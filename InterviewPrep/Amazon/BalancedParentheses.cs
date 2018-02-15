using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    class BalancedParentheses
    {
        public bool IsBalanced(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return false;

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(' || expression[i] == '[' || expression[i] == '{')
                    stack.Push(expression[i]);
                else if (stack.Pop() != GetOpeningMatch(expression[i]))
                    return false;
            }

            return stack.Count == 0 ? true : false;
        }

        private char GetOpeningMatch(char c)
        {
            switch (c)
            {
                case ')':
                    return '(';
                case ']':
                    return '[';
                case '}':
                    return '{';
                default:
                    break;
            }

            return '\0'; 
        }
    }
}
