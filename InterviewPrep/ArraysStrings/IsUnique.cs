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

        // Another Solution with an Array
        /*?
        You should first ask your interviewer if the string is an ASCII string or a Unicode string. Asking this question
        will show an eye for detail and a solid foundation in computer science. We'll assume for simplicity the character
        set is ASCII.If this assumption is not valid, we would need to increase the storage size.

        One solution is to create an array of boolean values, where the flag at index i indicates whether character
        i in the alphabet is contained in the string. The second time you see this character you can immediately
        return false.
        */

        public bool IsUnique2(string str)
        {
            if (String.IsNullOrEmpty(str) || str.Length > 256)
                return false;

            bool[] arr = new bool[256];

            for (int i = 0; i < str.Length; i++)
            {
                if (arr[str[i]])
                    return false;

                arr[str[i]] = true;
            }

            return true;
        }
    }
}
