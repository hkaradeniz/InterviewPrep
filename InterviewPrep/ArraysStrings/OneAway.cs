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

            if (Math.Abs(n1 - n2) > 1)
                return false;

            int pointer1 = 0;
            int pointer2 = 0;
            int counter = 0;

            while (pointer1 < n1 && pointer2 < n2)
            {
                if (s1[pointer1] != s2[pointer2])
                {
                    if (counter == 1)
                        return false;

                    if (n1 > n2)
                        pointer1++;
                    else if (n2 > n1)
                        pointer2++;
                    else
                    {
                        pointer1++;
                        pointer2++;
                    }

                    counter++;
                }
                else
                {
                    pointer1++;
                    pointer2++;
                }
            }

            return true;
        }

    }
}
