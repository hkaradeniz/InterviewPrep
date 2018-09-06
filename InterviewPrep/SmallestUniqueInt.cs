using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    class SmallestUniqueInt
    {
        // Find the smallest unique integer in a random integer array with possible duplicates.

        /*
            1- Sort the array then look for the first unique int
            2- Use dictionary, pinpoint the duplicates, go through the dictionary and find the smallest. 
         */

        // 1- Sort the array then look for the first unique int
        // Complexity: O(n lg n)

        public int GetSmallestUniqueInt1(int[] arr)
        {
            Array.Sort(arr);

            int n = arr.Length;
            int pointer = 0, scanner = 0;
            bool duplicate = false;

            while (pointer < n)
            {
                duplicate = false;
                scanner = pointer + 1;

                while (scanner < n)
                {
                    if (arr[pointer] == arr[scanner])
                    {
                        duplicate = true;
                    }
                    else
                    {
                        break;
                    }

                    scanner++;
                }

                if (!duplicate) return arr[pointer];
                pointer = scanner;
            }

            return -1;
        }

        // 2- Use dictionary, pinpoint the duplicates, go through the dictionary and find the smallest. 
        // Complexity: O(n)
        // Extra space O(n)
        public int GetSmallestUniqueInt2(int[] arr)
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                    dict.Add(arr[i], false);
                else
                    dict[arr[i]] = true;
            }

            int min = int.MaxValue;

            foreach (var item in dict)
            {
                if (!item.Value)
                    if (item.Key < min)
                        min = item.Key;
            }

            return min;
        }
    }
}
