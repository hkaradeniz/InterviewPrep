using System.Collections.Generic;

namespace InterviewPrep
{
    class GenerateParenthesis
    {
        /*
            Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

            For example, given n = 3, a solution set is:

            [
              "((()))",
              "(()())",
              "(())()",
              "()(())",
              "()()()"
            ]
         */
        public IList<string> Generate(int n)
        {
            List<string> list = new List<string>();
            Calculate(list, string.Empty, 0, 0, n);
            return list;
        }

        private void Calculate(List<string> list, string str, int opening, int closing, int n)
        {
            if (str.Length == n * 2)
            {
                list.Add(str);
                return;
            }

            if (opening < n)
                Calculate(list, str + "(", opening + 1, closing, n);

            if (closing < opening)
                Calculate(list, str + ")", opening, closing + 1, n);
        }
    }
}
