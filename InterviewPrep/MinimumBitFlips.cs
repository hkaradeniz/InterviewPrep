using System;

namespace InterviewPrep
{
    class MinimumBitFlips
    {
        public int ComputeMinimumBitFlipsOptimum(int a, int b)
        {
            int count = 0;

            for (int i = a^b; i!=0; i = i>>1)
            {
                count += i & 1;
            }

            return count;
        }

        public void ComputeMinimumBitFlipsBitwise(int a, int b)
        {
            /* XOR GATE:
               INPUT	OUTPUT
                A	B	A XOR B
                0	0	    0
                0	1	    1
                1	0	    1
                1	1	    0

             if bits are different, XOR will return 1
             */
            int result = a ^ b;

            int shiftCount = 0;
            int counter = 0;

            while (shiftCount < 32)
            {
                if ((result & (1 << shiftCount)) != 0)
                    counter++;

                shiftCount++;
            }

            Console.WriteLine($">> {counter}");
        }

        public void ComputeMinimumBitFlips(int a, int b)
        {
            // int Array to store Binary bits
            int[] binaryA = BinaryArray(a);
            int[] binaryB = BinaryArray(b);

            // The return variable to define 
            // how many bits we must flip
            int counter = 0;

            // Array pointer to iterate
            int pointer = 0;

            // Comparing bits between arrays
            // to find the distance between each other
            while (binaryA.Length > pointer)
            {
                if (binaryA[pointer] != binaryB[pointer])
                    counter++;

                pointer++;
            }

            Console.WriteLine($">> {counter}");
        }

        // Converting to Int Binary Array (32-bit integer)
        static int[] BinaryArray(int a)
        {
            int[] arr = new int[32];
            int pointer = 31;
            int i = 0;

            while (i < 32)
            {
                // Binary left shift operation
                if ((a & (1 << i)) != 0)
                {
                    arr[pointer] = 1;
                }
                else
                {
                    arr[pointer] = 0;
                }

                pointer--;
                i++;
            }

            return arr;
        }
    }
}
