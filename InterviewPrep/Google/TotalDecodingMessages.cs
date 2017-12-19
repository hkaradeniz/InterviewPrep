using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Google
{
    /* Total Decoding Messages */
    /* https://practice.geeksforgeeks.org/problems/total-decoding-messages/0 */
    /* A top secret message containing letters from A-Z is being encoded to numbers using the following mapping:

        'A' -> 1
        'B' -> 2
        ...
        'Z' -> 26
        You are an FBI agent. You have to determine the total number of ways that message can be decoded.
        Note: An empty digit sequence is considered to have one decoding. It may be assumed that the input contains valid digits from 0 to 9 and If there are leading 0’s, extra trailing 0’s and two or more consecutive 0’s then it is an invalid string.

        Example :
        Given encoded message "123",  it could be decoded as "ABC" (1 2 3) or "LC" (12 3) or "AW"(1 23).
        So total ways are 3.
     */
    class TotalDecodingMessages
    {
        public int TotalNumberOfCombinations(string number)
        {
            if (string.IsNullOrEmpty(number)) throw new InvalidOperationException();

            for (int i = 2; i < number.Length; i++)
            {
               
            }

            return 0;
        }
    }
}
