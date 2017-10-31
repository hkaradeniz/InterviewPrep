using System;

namespace InterviewPrep.General
{
    class AllSubsets
    {
        /* Find and print all subsets of a given set! (Given as an array.) */
        /* Complexity O(2^N) */

        /* Test Data: 
            General.AllSubsets ss = new General.AllSubsets();
            ss.PrintAllSubsets(new int[] { 1, 2 });
         */
        public void PrintAllSubsets(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            Print(arr, 0, string.Empty);
        }

        private void Print(int[] arr, int pointer, string set)
        {
            if (pointer == arr.Length)
            {
                Console.WriteLine($": {set}");
                return;
            } 

            Print(arr, pointer + 1, set);
            Print(arr, pointer + 1, set + arr[pointer]);
        }
    }
}
