using System;

namespace InterviewPrep.Amazon
{
    /* Dutch national flag problem */
    /*
    The Dutch national flag problem (DNF)[1] is a computer science programming 
    problem proposed by Edsger Dijkstra.[2] The flag of the Netherlands consists 
    of three colors: red, white and blue. Given balls of these three colors 
    arranged randomly in a line (the actual number of balls does not matter), 
    the task is to arrange them such that all balls of the same color are 
    together and their collective color groups are in the correct order.

    Test Data:
        Amazon.DutchNationalFlag df = new Amazon.DutchNationalFlag();
        df.ArrangeDutchNationalFlag(new int[] {0,1,1,0,1,2,1,2,0,0,0,1 });
    */
    class DutchNationalFlag
    {
        public void ArrangeDutchNationalFlag(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int left = 0;
            int right = arr.Length - 1;
            int mid = 0;

            while (mid <= right)
            {
                if (arr[mid] == 0)
                {
                    Swap(arr, mid, left);
                    mid++;
                    left++;
                }
                else if (arr[mid] == 1)
                {
                    mid++;
                }
                else if (arr[mid] == 2)
                {
                    Swap(arr, mid, right);
                    right--;
                }
            }

            PrintFlag(arr);
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void PrintFlag(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($" { arr[i] } ");
            }
        }
    }
}
