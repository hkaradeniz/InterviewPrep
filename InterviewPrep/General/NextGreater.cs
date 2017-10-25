using System;
using System.Collections.Generic;

namespace InterviewPrep.General
{
    class NextGreater
    {
        // Next greater element in an array
        // Sample: http://www.geeksforgeeks.org/next-greater-element/
        /*
         Given an array, print the Next Greater Element (NGE) for every element. The Next greater Element for an element x is the first greater element on the right side of x in array. Elements for which no greater element exist, consider next greater element as -1.

            Examples:
            a) For any array, rightmost element always has next greater element as -1.
            b) For an array which is sorted in decreasing order, all elements have next greater element as -1.
            c) For the input array [4, 5, 2, 25}, the next greater elements for each element are as follows.

            Element       NGE
               4      -->   5
               5      -->   25
               2      -->   25
               25     -->   -1

            Test Data:
            General.NextGreater ng = new General.NextGreater();
            ng.PrintNextGreaterElements(new int[] { 98, 23, 54, 12, 20, 7, 27 });
         */

        // Brute Force: Use two loops O(N^2)
        // Efficient Method: Use a stack O(N)


        public void PrintNextGreaterElements(int[] arr)
        {
            if (arr == null) return;

            Stack<int> stack = new Stack<int>();
            stack.Push(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                int current = arr[i];
                int element = current;

                while (current > stack.Peek() && stack.Count > 0)
                {
                    Console.WriteLine($"Next Greater Element for { stack.Pop() } = {current}");
                }

                stack.Push(current);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine($"Next Greater Element for {stack.Pop()} = null");
            }
        }
    }
}
