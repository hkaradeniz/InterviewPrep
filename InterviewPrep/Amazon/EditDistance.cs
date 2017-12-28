using System;

namespace InterviewPrep.Amazon
{
    /* Edit Distance */
    /* Given two strings str1 and str2 and below operations that can performed on str1. Find minimum number of edits (operations) required to convert ‘str1′ into ‘str2′.

        Insert
        Remove
        Replace
        All of the above operations are of cost=1.
        Both the strings are of lowercase. */
    /* https://practice.geeksforgeeks.org/problems/edit-distance/0 */
    class EditDistance
    {
        private const int ALPHABET_SIZE = 26;

        public void FindDistance(string s1, string s2)
        {
            int[] arr1 = ToIntArray(s1);
            int[] arr2 = ToIntArray(s2);

            int difference1 = 0;
            int difference2 = 0;

            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (arr1[i] > arr2[i])
                {
                    difference1 += arr1[i] - arr2[i];
                }
                else if (arr1[i] < arr2[i])
                {
                    difference2 += arr2[i] - arr1[i];
                }
            }

            Console.WriteLine($"Distance: { Math.Max(difference1, difference2) }");
        }

        private int[] ToIntArray(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new NullReferenceException();

            int[] arr = new int[ALPHABET_SIZE];

            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }

            return arr;
        }
    }
}
