using System;

namespace InterviewPrep
{
    class MinimumBitFlips
    {
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
