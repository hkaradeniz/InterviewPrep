using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Next larger element */
    /* https://practice.geeksforgeeks.org/problems/next-larger-element/0 */
    /* Given an array A [ ] having distinct elements, the task is to find the next greater 
        element for each element of the array in order of their appearance in the array. 
        If no such element exists, output -1  */
    /* Input
        1 3 2 4 

        Output
        3 4 4 -1 */

    class NextLargerElement
    {
        public void FindNextLargerElements(int[] arr)
        {
          
            if (arr == null || arr.Length == 0) return;

            Stack<int> stack = new Stack<int>();
            int element, next;

            stack.Push(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                next = arr[i];

                if (stack.Count > 0)
                {
                    element = stack.Pop();

                    while (element < next)
                    {
                        Console.WriteLine($"{ element } : { next }");

                        if (stack.Count == 0)
                            break;

                        element = stack.Pop();
                    }

                    if (element > next)
                        stack.Push(element);
                }

                stack.Push(next);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine($"{ stack.Pop() } : { -1 }");
            }
        }
    }
}
