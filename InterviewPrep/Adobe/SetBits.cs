using System;

namespace InterviewPrep.Adobe
{
    /* Set Bits */
    /* Given a positive integer N, print count of set bits in it. */
    /* https://practice.geeksforgeeks.org/problems/set-bits/0 */
    class SetBits
    {
        public void CountSetBits(int n)
        {
            int count = 0;

            int pointer = 0;

            while (pointer < 32)
            {
                if ((n & (1 << pointer)) != 0)
                    count++;

                pointer++;
            }

            Console.WriteLine($"Number of set bits in {n} : {count}");
        }
    }
}
