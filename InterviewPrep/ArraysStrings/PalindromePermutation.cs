using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.ArraysStrings
{
    class PalindromePermutation
    {
        /*? Cracking the Coding Interview, 6th Edition
            Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
            A palindrome is a word or phrase that is the same forwards and backwards. A permutation
            is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
            1.5
            1.6
            EXAMPLE
            Input: Tact Coa
            Output: True (permutations: "taco cat", "atco eta", etc.)
        */
        static int NUMBER_LETTERS = 26; // 26 chars in English alphabet

        public bool CheckPalindromePermutation(string word)
        {
            bool centerCharUsed = false;

            int[] arr = GetCount(word);

            foreach (var item in arr)
            {
                if (item % 2 == 1)
                    if (centerCharUsed)
                        return false;
                    else
                        centerCharUsed = true;
            }

            return true;
        }

        private int[] GetCount(string s)
        {
            int[] arr = new int[NUMBER_LETTERS];

            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] != ' ')
                    arr[s[i] - 'a']++;
            }

            return arr;
        }
    }
}
