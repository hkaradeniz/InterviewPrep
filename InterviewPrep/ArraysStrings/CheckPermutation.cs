using System;

namespace InterviewPrep.ArraysStrings
{
    class CheckPermutation
    {
        /*? Cracking the Coding Interview, 6th Edition
            Check Permutation: Given two strings, write a method to decide if one is a permutation of the
            other.
            Constraint: all strings are lowercase
        */
        static int NUMBER_LETTERS = 26; // 26 chars in English alphabet

        public bool CheckStringPermutation(string str1, string str2)
        {
            int[] arr1 = GetCharCounts(str1);
            int[] arr2 = GetCharCounts(str2);

            int difference = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                difference += Math.Abs(arr1[i] - arr2[i]);
            }

            if (difference > 0)
                return false;

            return true;
            
        }

        private int[] GetCharCounts(string s)
        {
            int[] arr = new int[NUMBER_LETTERS];

            for (int i = 0; i < s.Length; i++)
            {
                // ASCII Code of lowercase chars
                /*
                     * 97  01100001 a
                     * 98  01100010	b
                     * ...
                     * 122 01111010	z
                 */
                // Using 'a' as an offset
                arr[s[i] - 'a']++;
            }

            return arr;
        }
    }
}
