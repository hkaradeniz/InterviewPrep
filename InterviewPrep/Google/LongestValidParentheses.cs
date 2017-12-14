using System.Collections.Generic;

namespace InterviewPrep.Google
{
    /*
     Given a string consisting of opening and closing parenthesis, find length of the longest valid parenthesis substring.

        Examples:

        Input : ((()
        Output : 2
        Explanation : ()

        Input: )()())
        Output : 4
        Explanation: ()()

        Input:  ()(()))))
        Output: 6
        Explanation:  ()(())

        Input:
        First line contains the test cases T.  1<=T<=500
        Each test case have one line string S of character'(' and ')' of length  N.  1<=N<=10000

        Example:
        Input:
        2
        ((()
        )()())

        Output:
        2
        4
     */
    class LongestValidParentheses
    {
        public int NumberOfValidParentheses(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return -1;

            int count = 0;
            Stack<char> leftParenthesesStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                    leftParenthesesStack.Push(expression[i]);
                else
                {
                    if (leftParenthesesStack.Count > 0)
                    {
                        leftParenthesesStack.Pop();
                        count = count + 2;
                    }
                }
            }

            return count;
        }
    }
}
