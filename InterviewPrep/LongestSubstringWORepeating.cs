using System.Collections.Generic;

namespace InterviewPrep
{
    // Longest Substring Without Repeating Characters

    class LongestSubstringWORepeating
    {
        public string FindLongestSubstringWORepeating(string str)
        {
            // Test data: abcdhakljmnhhabnmkjoiuyt 

            // Keeps start index of string
            int start = 0;

            // How many chars are we getting after start index. We use this for substring.
            int counter = 0;

            // Size of the array
            int size = str.Length;

            // Storing the chars so we would know if the chars was already in the subtring or not.
            HashSet<char> hash = new HashSet<char>();

            // Return value
            string longest = string.Empty;

            // Test = abcdhakljmnhh
            // start  0
            // end    0 1
            for (int i = 0; i < size; i++)
            {
                counter++;
                char current = str[i];

                // First we look if the current char was in the substring or not
                // If not in the substring then we are good. We can increase the longest
                // substring another char long
                if (!hash.Contains(current))
                {
                    longest = str.Substring(start, counter);
                }
                // If the current char is in the hash, that means we cannot continue 
                // increasing the substring. We have to cut it. 
                // First we clear the hash, then, we check if the counter
                // is longer than the size of longest string, if so then the new longest string
                // will be the substring (start, counter).
                // Then after we have to assign a new start point. Since arrays start from 0
                // The new start point would be start+counter-1
                // Finally we reset the counter to 1 since the current char can be the head or
                // of the new substring.
                else
                {
                    hash.Clear();

                    if (counter-1 > longest.Length)
                    {
                        longest = str.Substring(start, counter);
                    }

                    start = start + counter - 1;
                    counter = 1;
                }

                // We can do hash-adding operation here
                // If, first if the case we don't have to worry. The new char will be added to
                // hash. If the char is already in hash, in else block all the chars in hash will be 
                // removed and the char will be added to hash here.
                hash.Add(current);
            }

            return longest;
        }
    }
}
