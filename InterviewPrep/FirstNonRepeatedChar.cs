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

            Dictionary<char, int> dictSolution = new Dictionary<char, int>();

            int length = s.Length;

            for (int i = 0; i < length; i++)
            {
                if (dictSolution.ContainsKey(s[i]))
                {
                    dictSolution[s[i]]++;
                }
                else
                {
                    dictSolution.Add(s[i], 1);
                }
            }

            foreach (var item in dictSolution)
            {
                if (item.Value == 1)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
