using System;

namespace InterviewPrep.Adobe
{
    /* Non Repeating Character */
    /* Given a string s consisting of lowercase Latin Letters, find the first non repeating character in s. */
    /* https://practice.geeksforgeeks.org/problems/non-repeating-character/0 */
    class NonRepeatingCharacter
    {
        private static int ALPHABET_SIZE = 26;

        public void FindNonRepeatingChar(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            Console.WriteLine($"Text: {s}");

            int[] arr = new int[ALPHABET_SIZE];

            // ASCII a = 97
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                {
                    Console.WriteLine($"First non repeating character: {(char)(i + 97)}");
                    break;
                }
            }

            Console.WriteLine($"No non-repeating chars...");
        }
    }
}
