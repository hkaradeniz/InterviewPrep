using System;

namespace InterviewPrep
{
    class MoveZeros
    {
        /*
         // Uber Interview Questions – Move Zeroes
         // http://blog.gainlo.co/index.php/2016/11/18/uber-interview-question-move-zeroes/

         Problem: Modify the array by moving all the zeros to the end (right side). The order of other elements doesn’t matter.
         Let’s have an example. For array [1, 2, 0, 3, 0, 1, 2], the program can output [1, 2, 3, 1, 2, 0, 0].

        The most naive approach should be extremely straightforward. By keeping two arrays: one for non-zero numbers and one 
        for all zeroes, we can concatenate them at the end. Since we just need to traverse the array once, this will give 
        us O(N) time complexity. Space complexity is O(N) as we need two additional arrays.

        Apparently, time complexity can’t be improved as we need to traverse the array at least once. 
        In order to use less space, we should look for modifying the array.

         */
        public void SolveMoveZeros(int[] arr)
        {
            //int start = 0;
            int end = arr.Length - 1;

            for (int start = 0; start < end; start++)
            {
                while (end > start)
                {
                    if (arr[end] == 0)
                        end--;
                    else
                        break;
                }

                if (arr[start] == 0)
                {
                    arr[start] = arr[end];
                    arr[end] = 0;
                    end--;
                }
            }

            // [1, 2, 0, 3, 0, 1, 2]
            // start    end
            //   0       6
            //   1       6
            //   2       6 -> swap
            //   3       5
            //   4       5 -> swap
            //   5       4 -> break;   


            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
