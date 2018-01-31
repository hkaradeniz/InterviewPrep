using System;

namespace InterviewPrep.Amazon
{
    /* Least common multiple */
    /* For 2 given numbers find out their LCM */
    /* https://practice.geeksforgeeks.org/problems/lcm-and-gcd/0 */
    class LeastCommonMultiple
    {
        /* In arithmetic and number theory, the least common multiple, lowest common multiple, or smallest common 
         * multiple of two integers a and b, usually denoted by LCM(a, b), is the smallest positive integer that 
         * is divisible by both a and b. */

        /*
         Formula:

        The following formula reduces the problem of computing the least common multiple to the problem of 
        computing the greatest common divisor (GCD), also known as the greatest common factor:

        lcm(a, b) = | a * b | / GCD(a, b);
         
         Because gcd(a, b) is a divisor of both a and b, it is more efficient to compute the LCM by dividing before multiplying.

         */

        public int GetLCM(int a, int b)
        {
            if (a == 0 || b == 0) return -1;

            return Math.Abs(a * b) / GCD(a, b);
        }

        private int GCD(int a, int b)
        {
            return a == 0 ? b : GCD(b % a, a);
        }
    }
}
