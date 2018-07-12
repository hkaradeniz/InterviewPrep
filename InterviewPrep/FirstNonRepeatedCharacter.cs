using System;

namespace InterviewPrep
{
    /*
    First Non-repeated character
    Write a function that accepts a single string input and returns the first non-repeated character.

    "AABBC" // "C"
    "AABBCCDEEFF" // "D"

     */
    class FirstNonRepeatedCharacter
    {
        public void FindChar(string s)
        { 
            int n = s.Length;

            int pointer = 0;
            int scanner;
            bool duplicate;

            while (pointer < n)
            {
                scanner = pointer + 1;
                duplicate = false;

                while (scanner < n)
                {
                    if (s[pointer] != s[scanner]) break;

                    duplicate = true;
                    scanner++;
                }

                if (!duplicate)
                { Console.WriteLine(s[pointer]); return; }

                pointer = scanner;
            }

            Console.WriteLine("No distinct char!");
        }
    }
}
