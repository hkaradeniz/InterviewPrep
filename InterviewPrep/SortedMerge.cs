using System;

namespace InterviewPrep
{
    class SortedMerge
    {
        /*? 
         Sorted Merge: You are given two sorted arrays, A and B, where A has a large enough buffer at the
         end to hold B. Write a method to merge B into A in sorted order.
         */

        // Test Data
        //int?[] arrA = { 10, 20, 30, 45, 53, 62, null, null, null, null };
        //int[] arrB = { 9, 15, 59, 65 };
        //SortedMerge sm = new SortedMerge();
        //sm.SolveSortedMerge1(arrA, arrB);

        //? O(A) A-> Size of Array A
        public void SolveSortedMerge1(int?[] arrA, int[] arrB)
        {
          
            int size = arrA.Length;
            int pointerA = 0; int pointerB = 0;
            int?[] newArray = new int?[size];

            for (int i = 0; i < size; i++)
            {
                if (arrA[pointerA]!=null && arrA[pointerA] <= arrB[pointerB])
                {
                    newArray[i] = arrA[pointerA];
                    pointerA++;
                }
                else
                {
                    newArray[i] = arrB[pointerB];
                    pointerB++;
                }
            }

            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
