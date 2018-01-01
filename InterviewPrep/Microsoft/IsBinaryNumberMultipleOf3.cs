using System;

namespace InterviewPrep.Microsoft
{
    /* Is Binary Number Multiple of 3 */
    /* https://practice.geeksforgeeks.org/problems/is-binary-number-multiple-of-3/0 */
    /* Given a binary number,  write a program that prints 1 if given binary number is a multiple of 3.  Else prints 0. The given number can be big upto 2^100 */
    class IsBinaryNumberMultipleOf3
    {
        public bool IsMultipleOf3(string number)
        {
            if (string.IsNullOrEmpty(number)) return false;
            int oddBitCount = 0;
            int evenBitCout = 0;

            for (int i = number.Length-1; i >= 0; i--)
            {
                int val = number[i] - '0';

                if ((val & 1) > 0)
                {
                    if (i % 2 == 0)
                        evenBitCout++;
                    else
                        oddBitCount++;
                }
            }

            return Math.Abs(evenBitCout - oddBitCount) % 3 == 0;
        }
    }
}
