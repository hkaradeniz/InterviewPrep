using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.Google
{
    /* Word Break */
    /* Given an input string and a dictionary of words, find out if the input string can be segmented into a space-separated 
       sequence of dictionary words. See following examples for more details.
        Consider the following dictionary
        { i, like, sam, sung, samsung, mobile, ice,
          cream, icecream, man, go, mango}

        Input:  ilike
        Output: Yes
        The string can be segmented as "i like".
        */
    /* https://practice.geeksforgeeks.org/problems/word-break/0 */
    /*
     Question Model:
     1-) Can we assume everything is lowercase?
        Assuming lowercase...
     */

    class WordBreak
    {
        HashSet<string> dictionary = new HashSet<string>();

        public WordBreak()
        {
            dictionary.Add("i");
            dictionary.Add("like");
            dictionary.Add("sam");
            dictionary.Add("sung");
            dictionary.Add("samsung");
            dictionary.Add("mobile");
            dictionary.Add("icecream");
            dictionary.Add("ice");
            dictionary.Add("cream");
            dictionary.Add("man");
            dictionary.Add("go");
            dictionary.Add("mango");
        }

        // using hash for memoization
        HashSet<string> set = new HashSet<string>();

        public bool IsBreakable1(string str)
        {
            if (str.Length == 0) return true;
            if (set.Contains(str)) return false;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(str[i]);

                if (dictionary.Contains(sb.ToString()) && IsBreakable1(str.Substring(i + 1)))
                    return true;
            }

            set.Add(str);
            return false;
        }

        // Second method
        public bool IsBreakable2(string str)
        {
            if (dictionary.Contains(str)) return true;

            if (set.Contains(str)) return false;

            foreach (var word in dictionary)
            {
                if(str.StartsWith(word)
                    && IsBreakable2(str.Substring(word.Length))) return true;
            }

            set.Add(str);
            return false;
        }
    }
}
