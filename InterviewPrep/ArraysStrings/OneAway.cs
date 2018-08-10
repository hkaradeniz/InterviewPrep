using System;

namespace InterviewPrep.ArraysStrings
{
    class OneAway
    {
        /*? Cracking the Coding Interview, 6th Edition
            One Away: There are three types of edits that can be performed on strings: insert a character,
            remove a character, or replace a character.Given two strings, write a function to check if they are
            one edit (or zero edits) away.

                    EXAMPLE
            pale, ple -> true
            pales, pale -> true
            pale, bale -> true
            pale, bake -> false
       */

        public bool IsOneAway(string s1, string s2)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;

            if (Math.Abs(n1 - n2) > 1) return false;

            int[] arr1 = StringToIntArray(s1);
            int[] arr2 = StringToIntArray(s2);

            int diff = 0;

            for (int i = 0; i < arr1.Length; i++)
            {
                diff = Math.Abs(arr1[i] - arr2[i]);
            }

            return diff > 1 ? false : true;
        }

        private int[] StringToIntArray(string s)
        {
            int[] arr = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }

            return arr;
        }
    }
}
