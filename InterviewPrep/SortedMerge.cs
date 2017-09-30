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
        //int[] arrA = { 10, 20, 30, 45, 53, 62, -1, -1, -1, -1};
        //int[] arrB = { 9, 15, 59, 65 };
        //SortedMerge sm = new SortedMerge();
        //sm.SolveSortedMerge(arrA, arrB, 6, 4);
        public void SolveSortedMerge(int[] arrA, int[] arrB, int sizeA, int sizeB)
        {
            int indexA = sizeA - 1;
            int indexB = sizeB - 1;
            int newIndex = sizeA + sizeB - 1;

            while (indexA >= 0 && indexB >= 0)
            {
                if (arrA[indexA] > arrB[indexB])
                {
                    arrA[newIndex] = arrA[indexA];
                    indexA--;
                }
                else 
                {
                    arrA[newIndex] = arrB[indexB];
                    indexB--;
                }
                newIndex--;
            }

            while (indexB >= 0)
            {
                arrA[newIndex] = arrB[indexB];
                indexB--;
                newIndex--;
            }

            PrintArray(arrA);
        }

        // Test Data
        //int?[] arrA = { 10, 20, 30, 45, 53, 62, -1, -1, -1, -1};
        //int[] arrB = { 9, 15, 59, 65 };
        //SortedMerge sm = new SortedMerge();
        //sm.SolveSortedMerge1(arrA, arrB);

        //? O(A) A-> Size of Array A
        // With Extra Space
        public void SolveSortedMergeExtraSpace(int[] arrA, int[] arrB, int sizeA, int sizeB)
        {
            int indexA = 0;
            int indexB = 0;
            int newIndex = 0;
            int[] newArray = new int[sizeA + sizeB];

            while(indexA < sizeA && indexB < sizeB)
            {
                if (arrA[indexA] <= arrB[indexB])
                {
                    newArray[newIndex] = arrA[indexA];
                    indexA++;
                }
                else
                {
                    newArray[newIndex] = arrB[indexB];
                    indexB++;
                }

                newIndex++;
            }

            while (indexB < sizeB)
            {
                newArray[newIndex] = arrB[indexB];
                indexB++;
                newIndex++;
            }

            while (indexA < sizeA)
            {
                newArray[newIndex] = arrA[indexA];
                indexA++;
                newIndex++;
            }

            PrintArray(newArray);
        }

        private void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} * ");
            }
        }
    }
}
