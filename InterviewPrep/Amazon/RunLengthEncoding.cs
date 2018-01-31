using System;
using System.Text;

namespace InterviewPrep.Amazon
{
    /* Run Length Encoding */
    /* Given a string, Your task is to  complete the function encode that returns the run length 
     * encoded string for the given string.
       eg if the input string is “wwwwaaadexxxxxx”, then the function should return “w4a3d1e1x6″. */
    /* https://practice.geeksforgeeks.org/problems/run-length-encoding/1 */
    class RunLengthEncoding
    {
        public void Encode(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            Console.WriteLine($"String: {str}");
            StringBuilder sb = new StringBuilder();

            int head = 0;
            int scanner, total;

            while (head < str.Length)
            {
                scanner = head + 1;
                total = 1;
                sb.Append(str[head]);

                while (scanner < str.Length)
                {
                    if (str[head] != str[scanner])
                        break;

                    total++;
                    scanner++;
                }

                sb.Append(total);

                head = scanner;
            }

            Console.WriteLine($"Encoded string: {sb.ToString()}");
        }
    }
}
