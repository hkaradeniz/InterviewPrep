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

        public bool IsWordBreak(string str)
        {
            int size = str.Length;

            if (size == 0) return true;

            for (int i = 1; i <= size; i++)
            {
                if (dictionary.Contains(str.Substring(0, i))
                    && IsWordBreak(str.Substring(i, size - i)))
                    return true;
            }

            return false;
        }
    }
}
