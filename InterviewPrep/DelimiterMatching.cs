using System.Collections.Generic;

namespace InterviewPrep
{
    class DelimiterMatching
    {
        // Uber Interview Questions – Delimiter Matching
        // http://blog.gainlo.co/index.php/2016/09/30/uber-interview-question-delimiter-matching/
        // Write an algorithm to determine if all of the delimiters in an expression are matched and closed.
        // For example, “{ac[bb]}”, “[dklf(df(kl))d]{}” and “{[[[]]]}” are matched. But “{3234[fd” and {df][d} are not.
        Dictionary<char, int> dict;

        public DelimiterMatching()
        {
            dict = new Dictionary<char, int>();
            dict.Add('{', 0);
            dict.Add('(', 0);
            dict.Add('[', 0);
        }


        public bool IsMatched(string text)
        {
            //int mismatchedDelimiter = 0;

            // Test case 1: [dklf(df(kl))d]{}
            // Test case 2: {df][d}
            // Test case 3: {[[[]]]}
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '{' || text[i] == '(' || text[i] == '[')
                    stack.Push(text[i]);
                else if (text[i] == '}' || text[i] == ')' || text[i] == ']')
                {
                    char c = GetOpenDelimiter(text[i]);

                    if (stack.Pop() != c)
                        return false;
                }
            }

            return stack.Count == 0;
        }

        private char GetOpenDelimiter(char c)
        {
            if (c == '}')
                return '{';
            else if (c == ')')
                return '(';
            else if (c == ']')
                return '[';

            return '\0';
        }

    }
}
