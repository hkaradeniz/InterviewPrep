namespace InterviewPrep.BitManipulation
{
    /*? * Cracking the Coding Interview, 6th Edition
     Conversion: Write a function to determine the number of bits you would need to flip to convert
    integer A to integer B.
    
        EXAMPLE
        Input:

        29 (or: 11101), 15 (or: 01111)

        Output:
        2
    */

    class Conversion
    {
        public int ComputeConversion(int a, int b)
        {
            int count = 0;

            // XOR two numbers
            int c = a ^ b;

            // Count set bits - "1"s
            while (c > 0)
            {
                if ((c & 1) != 0)
                    count++;

                c = c >> 1;
            }

            return count;
        }
    }
}
