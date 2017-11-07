using System;

namespace InterviewPrep.ArraysStrings
{
    class ArrayLeaders
    {
        /* Given an array of integers, print the leaders in the array. A leader is an element which is 
        larger than all the elements in the array to its right. */

        /* Input Array: 98, 23, 54, 20, 7, 27 */
        /* Output: 98, 54, 27 */
        /* Last element is always leader element */

        /* Iterate from right to left, and keep track of the currentMax, and display it */

        public void FindLeaders(int[] arr)
        {
            if(arr == null || arr.Length==0)
            { Console.WriteLine("Empty or Null Array!"); return; }

            int currentMax = int.MinValue; 

            for (int i = arr.Length-1; i >= 0; i--)
            {
                if (arr[i] > currentMax)
                {
                    currentMax = arr[i];
                    Console.WriteLine($"{currentMax}");
                }
            }
        }
    }
}
