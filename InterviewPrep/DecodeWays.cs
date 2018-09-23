using System;

namespace InterviewPrep
{
    /*
        A message containing letters from A-Z is being encoded to numbers using the following mapping:

        'A' -> 1
        'B' -> 2
        ...
        'Z' -> 26
        Given a non-empty string containing only digits, determine the total number of ways to decode it.

        Example 1:

        Input: "12"
        Output: 2
        Explanation: It could be decoded as "AB" (1 2) or "L" (12).
        Example 2:

        Input: "226"
        Output: 3
        Explanation: It could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
     */
    class DecodeWays
    {
        public int NumDecodings(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            int[] arr = new int[str.Length + 1];

            arr[0] = 1;
            arr[1] = str[0] != '0' ? 1 : 0;

            for (int i = 2; i <= str.Length; i++)
            {
                int first = Convert.ToInt32(str.Substring(i - 1, 1));
                int second = Convert.ToInt32(str.Substring(i - 2, 2));

                if (first >= 1 && first <= 9)
                {
                    arr[i] += arr[i - 1];
                }

                if (second >= 10 && second <= 26)
                {
                    arr[i] += arr[i - 2];
                }
            }


            return arr[str.Length];
        }
    }
}
