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
            if (string.IsNullOrEmpty(s)) return;

            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<char> list = new List<char>();

            int length = s.Length;

            for (int i = 0; i < length; i++)
            {
                if (dict.ContainsKey(s[i]))
                    dict[s[i]]++;
                else
                {
                    dict.Add(s[i], 1);
                    list.Add(s[i]);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (dict[list[i]] == 1)
                {
                    Console.WriteLine(list[i]);
                    break;
                }
            }
        }
    }
}
