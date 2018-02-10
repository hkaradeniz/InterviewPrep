using System;

namespace InterviewPrep.Google
{
    /* Suffix Search */
    /* Given a string of N characters, find the longest reoeated substring */

    /* Brute Force 
        + Try all indices i and j for start of possible match
        + Compute the longest common prefix (LCP) for each pair
     */
    /* Suffix Search */
    /* 
       String: a a c a a g t t t a c a a g c (15) 


       From Suffixes:                                           Sort Suffixes to bring reoeated substrings together:
      0-  a a c a a g t t t a c a a g c                             a a c a a g t t t a c a a g c
      1-  a c a a g t t t a c a a g c                               a a g c
      2-  c a a g t t t a c a a g c                                 a a g t t t a c a a g c
      3-  a a g t t t a c a a g c                                   *a c a a g c
      4-  a g t t t a c a a g c                                     *a c a a g t t t a c a a g c 
      5-  g t t t a c a a g c                                       a g c
      6-  t t t a c a a g c                                         a g t t t a c a a g c
      7-  t t a c a a g c                                           c
      8-  t a c a a g c                                             c a a g c
      9-  a c a a g c                                               c a a g t t t a c a a g c   
     10-  c a a g c                                                 g c
     11-  a a g c                                                   g t t t a c a a g c
     12-  a g c                                                     t a c a a g c 
     13-  g c                                                       t t a c a a g c 
     14-  c                                                         t t t a c a a g c
    */
    class SuffixSearch
    {
        public string LongestRepeatedSubstring(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            string prefix = string.Empty;

            int n = str.Length;
            string[] suffixes = new string[n];

            // Create suffixes
            for (int i = 0; i < n; i++)
            {
                suffixes[i] = str.Substring(i, n-i);
            }

            Array.Sort(suffixes);

            for (int i = 0; i < n-1; i++)
            {
                string temp = LongestCommonPrefix(suffixes[i], suffixes[i + 1]);

                if (temp.Length > prefix.Length)
                    prefix = temp;
            }

            return prefix;
        }

        private string LongestCommonPrefix(string s1, string s2)
        {
            string prefix = string.Empty;
            int pointer = 0;

            // Second string must have a smaller length
            while (pointer < s2.Length && pointer < s1.Length)
            {
                if (s1[pointer] != s2[pointer])
                    break;

                pointer++;
            }

            return s2.Substring(0, pointer);
        }
    }
}
