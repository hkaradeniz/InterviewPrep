using System;

namespace InterviewPrep.BitManipulation
{
    /*?
     * Insertion: You are given two 32-bit numbers, N and M, and two bit positions, i and j. Write a method
        to insert M into N such that M starts at bit j and ends at bit i. You can assume that the bits j through
        i have enough space to fit all of M. That is, if M = 10011, you can assume that there are at least 5
        bits between j and i. You would not, for example, have j = 3 and i = 2, because M could not fully
        fit between bit 3 and bit 2.
        
        EXAMPLE
        Input: N = 10000000000, M = 10011, i = 2, j = 6

        Output: N = 10001001100

        Test:
        BitManipulation.Insertion bi = new BitManipulation.Insertion();
        bi.Insert(1024, 19, 2, 6);
     */
    class Insertion
    {
        public void Insert(int n, int m, int i, int j)
        {
            int pointer = i;

            /* Considering j > i */
            /* Clear the bits j through i in N */
            while (pointer <= j)
            {
                // Clear bits
                n &= ~(1 << pointer);

                // Set bits
                // n |= (1 << i);
                pointer++;
            }

            /* Shift M so that it lines up with bits j through i */
            pointer = 1;
            while (pointer <= i)
            {
                m = m << 1;
                pointer++;
            }

            /* Merge M and N */
            Console.WriteLine(Convert.ToString(n | m, 2));
        }
    }
}
