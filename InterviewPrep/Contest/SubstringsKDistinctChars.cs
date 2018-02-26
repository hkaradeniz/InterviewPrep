using System.Collections.Generic;

namespace InterviewPrep.Contest
{
    /* Amazon Interview Question */
    /* Substrings with size of k with k-1 distinct chars */
    class SubstringsKDistinctChars
    {
        private static int ALPHABET_SIZE = 26;

        public List<string> subStringsLessKDist(string inputString, int num)
        {
            // WRITE YOUR CODE HERE

            List<string> list = new List<string>();
            int n = inputString.Length;

            for (int i = 0; i <= inputString.Length - num; i++)
            {
                string substring = inputString.Substring(i, num);

                int distinctChar = GetDistinctChars(substring);

                if (distinctChar == num - 1)
                    list.Add(substring);
            }

            return list;
        }

        // Calculate chars in the substring
        // See how many distinct chars it has
        private int GetDistinctChars(string str)
        {
            int result = 0;
            int[] arr = new int[ALPHABET_SIZE];

            for (int i = 0; i < str.Length; i++)
            {
                if (arr[str[i] - 'a'] == 0)
                {
                    arr[str[i] - 'a']++;
                    result++;
                }
            }

            return result;
        }
    }
}
