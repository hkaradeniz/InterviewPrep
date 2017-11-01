using System;

namespace InterviewPrep.ArraysStrings
{
    class LongestConsecutiveCharacters
    {
        /*  Longest Consecutive Characters */
        /*  Given a string, find the longest subsequence consisting of a single character.  
         *  Example: longest("ABAACDDDBBA") should return {'D': 3}. */

        public void FindChar(string s)
        {
            if (String.IsNullOrEmpty(s))
                return;

            //char c = s[0];
            //int count = 1;
            char c = ' ';
            int max = 0;
            int pointer = 0;
            int scanner = 0;

            while (pointer < s.Length)
            {
                c = s[pointer];
                int count = 1;

                scanner = pointer + 1;
                while (scanner < s.Length)
                {
                    if (c == s[scanner])
                    {
                        count++;
                        scanner++;
                    } 
                    else
                        break;
                }

                if (count > max)
                    max = count;

                pointer = scanner;
            }

            Console.WriteLine($"Char: {c} Count: {max}");
        }
    }
}
