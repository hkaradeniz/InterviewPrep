using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class CountAndSay
    {
        public string countAndSay(int A)
        {
            if (A == 0) return string.Empty;
            if (A == 1) return "1";

            return countAndSay("1", 1, A).ToString();
        }

        public StringBuilder countAndSay(string str, int counter, int A)
        {
            int pointer = 0;
            int scanner = 0;
            int count = 0;
            StringBuilder newSequence = new StringBuilder();

            while (pointer < str.Length)
            {
                scanner = pointer + 1;
                count = 1;

                while (scanner < str.Length)
                {
                    if (str[pointer] != str[scanner])
                        break;

                    count++;
                    scanner++;
                }

                newSequence.Append(count).Append(str[pointer]);
                pointer = scanner;
            }

            counter++;

            if (counter < A)
                newSequence = countAndSay(newSequence.ToString(), counter, A);

            return newSequence;
        }
    }
}
