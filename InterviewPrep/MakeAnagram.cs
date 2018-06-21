using System;

namespace InterviewPrep
{
    class MakeAnagram
    {
        /* Anagram Problem
        Given two strings (lowercase a-z), how many characters do you need to remove (from either)
        to make them anagrams?
        EXAMPLE: hello, billion -> Answer 6 (he from hello and biin from billion)
        Anagram:
        "Madam Curie" = "Radium came
        */

        static int NUMBER_LETTERS = 26; // 26 chars in English alphabet

        string firstString = string.Empty;
        string secondString = string.Empty;

        public MakeAnagram(string s1, string s2)
        {
            firstString = s1;
            secondString = s2;
        }

        // How many times each char appears in each string
        private int[] GetCharCounts(string str)
        {
            int[] arr = new int[NUMBER_LETTERS];

            for (int i = 0; i < str.Length; i++)
            {
                // ASCII Code of lowercase chars
                /*
                 * 97  01100001 a
                 * 98  01100010	b
                 * ...
                 * 122 01111010	z
                 */
                // Using 'a' as an offset
                arr[str[i] - 'a']++;
            }

            return arr;
        }

        // Computes the difference of integer arrays
        private int CalculateDifference(int[] charArr1, int[] charArr2)
        {
            if (charArr1.Length != charArr2.Length)
                return -1; // ToDo: just to make sure both arrays have the same length

            int difference = 0;

            for (int i = 0; i < NUMBER_LETTERS; i++)
            {
                difference += Math.Abs(charArr1[i] - charArr2[i]);
            }

            return difference;
        }

        public int SolveAnagram()
        {
            int[] charCount1 = GetCharCounts(firstString);
            int[] charCount2 = GetCharCounts(secondString);

            return CalculateDifference(charCount1, charCount2);
        }
    }
}
