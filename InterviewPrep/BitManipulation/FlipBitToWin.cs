using System;

namespace InterviewPrep.BitManipulation
{
    /*? * Cracking the Coding Interview, 6th Edition
     Flip Bit to Win: You have an integer and you can flip exactly one bit from a O to a 1. Write code to
     find the length of the longest sequence of 1 s you could create.
     EXAMPLE

        Input: 1775 (or: 1-1-0-1-1-1-0-1-1-1-1)
        Output: 8


    */
    class FlipBitToWin
    {
        public int GetLongestSequence(int num)
        {
            int[] arr = GetBinaryArray(num);

            int counter = 0;
            bool flipped = false;
            int pointer = 0;
            int flippedIndex = 0;
            int max = 0;
            bool check = false;

            Console.WriteLine(Convert.ToString(num,2));

            while (pointer < 32)
            {
                if (pointer == 20)
                    Console.Read();

                if (arr[pointer] == 1)
                    counter++;
                else
                {
                    if (!flipped)
                    {
                        counter++;
                        flippedIndex = pointer;
                        flipped = true;
                    }
                    else
                    {
                        check = true;
                        pointer = flippedIndex;
                    }
                }

                if (check || pointer == arr.Length - 1)
                {
                    if (max < counter)
                        max = counter;

                    counter = 0;
                    flipped = false;
                    check = false;
                }

                pointer++;
            }

            return max;
        }

        private int[] GetBinaryArray(int num)
        {
            int[] arr = new int[32];
            int pointer = 31;
            int i = 0;

            while (i < 32)
            {
                if ((num & (1 << i)) != 0)
                    arr[pointer] = 1;
                else
                    arr[pointer] = 0;

                pointer--;
                i++;
            }

            return arr;

        }
    }
}
