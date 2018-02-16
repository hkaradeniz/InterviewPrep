using System;

namespace InterviewPrep.Amazon
{
    /* Given an array of 0s and 1s . I was asked to return the index of a zero turning which will produce a longest continuous 1s. */
    class LongestContinuousOnes
    {
        public void GetIndex(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            bool isUsed;
            int count;
            int startIndex = 0;
            int tempIndex = -1;
            int max = 0;
            int zeroIndex = -1;
            int pointer = 0;

            while (pointer < arr.Length)
            {
                isUsed = false;
                count = 0;
                startIndex = pointer;

                while (pointer < arr.Length)
                {
                    if (arr[pointer] == 1)
                        count++;
                    else
                    {
                        if (isUsed) break;

                        tempIndex = pointer;
                        isUsed = true;
                        count++;
                    }

                    pointer++;
                }

                if (count > max)
                {
                    max = count;
                    zeroIndex = tempIndex;
                }

                pointer = startIndex + 1;
            }

            Console.WriteLine($"Index: { zeroIndex }");
        }
        /*
        public void GetIndex(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int max = 0;
            int index = 0;
            int startIndex = 0;

            int pointer = 0;

            /// 1 0 1 1 0 1 0 1 1 1 0 1
            while (pointer < arr.Length)
            {
                int count = 0;
                startIndex = pointer;

                while (pointer < arr.Length && arr[pointer] == 1)
                {
                    count++;
                    pointer++;
                }

                if(count > max)
                {
                    max = count;
                    index = startIndex;
                }

                pointer++;
            }

            Console.WriteLine($"Index: { index }");
        }
        */
    }
}
