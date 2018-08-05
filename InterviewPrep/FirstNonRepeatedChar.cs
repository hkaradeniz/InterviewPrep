using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    class FirstNonRepeatedChar
    {
        /*
         Write an efficient method to find the first non-repeated character in a string. 
         Example: the first non-repeated character in “teeters” is “r”.   
         */
        public void FindFirstNonRepeatedChar(string s)
        {
            // Solution

            //Dictionary<char, int> dictSolution = new Dictionary<char, int>();
            int[] arr = new int[26];

            int length = s.Length;

            for (int i = 0; i < length; i++)
            {
                arr[s[i] - 'a']++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                {
                    Console.WriteLine((char)(i+'a'));
                    break;
                }
            }
        }
    }
}
