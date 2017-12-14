using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.General
{
    class InfixPrefixPostfix
    {
        /*
        Test Data: 2 + 4 * 5 - 6 * 7 (Infix)
                                    => 2 4 5 * + 6 7 * - (Postfix)
        */
        Dictionary<string, int> PrecedenceMap = new Dictionary<string, int>();

        public InfixPrefixPostfix()
        {
            PrecedenceMap.Add("*", 2);
            PrecedenceMap.Add("/", 2);
            PrecedenceMap.Add("+", 1);
            PrecedenceMap.Add("-", 1);
        }

        private bool IsOperator(string c)
        {
            return c == "*" ||
                   c == "/" ||
                   c == "+" ||
                   c == "-";
        }

        private bool IsOperand(string c)
        {
            int num;
            bool result = int.TryParse(c, out num);
            return result;
        }

        public string InfixToPostfix(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return string.Empty;

            StringBuilder postfix = new StringBuilder();
            Stack<string> operatorStack = new Stack<string>();
            string[] arr = expression.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                if (IsOperand(arr[i]))
                {
                    postfix.Append(arr[i]).Append(' ');
                }
                else if (IsOperator(arr[i]))
                {
                    while (operatorStack.Count > 0 && HasHigherOrEqualPrecedence(operatorStack.Peek(), arr[i]))
                    {
                        postfix.Append(operatorStack.Pop()).Append(' ');
                    }

                    operatorStack.Push(arr[i]);
                }
            }

            while (operatorStack.Count > 0)
            {
                postfix.Append(operatorStack.Pop()).Append(' ');
            }

            return postfix.ToString();
        }

        private bool HasHigherOrEqualPrecedence(string operatorInStack, string operatorInExpression)
        {
            return PrecedenceMap[operatorInStack] > PrecedenceMap[operatorInExpression] ||
                PrecedenceMap[operatorInStack] == PrecedenceMap[operatorInExpression];
        }
    }
}
