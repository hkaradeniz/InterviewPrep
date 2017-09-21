using System;
using System.Collections.Generic;

namespace InterviewPrep.ArraysStrings
{
    class IsUnique
    {
        /*? Cracking the Coding Interview, 6th Edition
            Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
            cannot use additional data structures?
        */

        public bool IsUniqueWithBuffer(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                HashSet<char> hash = new HashSet<char>();

                foreach (var item in str)
                {
                    if (hash.Contains(item))
                        return false;

                    hash.Add(item);
                }

                return true;              
            }

            return false;
        }

        public bool IsUniqueWithoutBuffer(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                // If an extra data structure is not allowed, convert string into an
                // char array and sort it, then look for the same chracters.
                char[] arr = str.ToCharArray();
                Array.Sort(arr);

                char previous = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    if (previous == arr[i])
                        return false;

                    previous = arr[i];
                }

                return true;
            }
            return false;
        }
    }
}
