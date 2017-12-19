using System;
using System.Text;

namespace InterviewPrep.Google
{
    /* Longest Common Subsequence */
    /* http://www.geeksforgeeks.org/longest-common-subsequence/ */
    /* LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
        LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4. 
     */
    /* Complexity: O(N*M) */
    /*
     Test Data:
     Google.LongestCommonSubsequence lcs = new Google.LongestCommonSubsequence("abcdaf", "acbcf");
     lcs.GetLongestCommonSubsequence();
     */
    class LongestCommonSubsequence
    {
        private int[,] matrix;
        private string str1;
        private string str2;

        public LongestCommonSubsequence(string s1, string s2)
        {
            str1 = s1;
            str2 = s2;
            matrix = new int[s2.Length + 1, s1.Length + 1];

            // Set Row 0 to 0
            for (int i = 0; i <= s1.Length; i++)
            {
                matrix[0, i] = 0;
            }

            // Set Col 0 to 0
            for (int i = 0; i <= s2.Length; i++)
            {
                matrix[i, 0] = 0;
            }
        }

        public void GetLongestCommonSubsequence()
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return;

            for (int i = 1; i <= str2.Length; i++)
            {
                for (int j = 1; j <= str1.Length; j++)
                {
                    if (str2[i - 1] == str1[j - 1])
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    else
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);

                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }

            StringBuilder sb = new StringBuilder();

            int row = str2.Length;
            int col = str1.Length;

            while (col != 0 && row != 0)
            {
                if (matrix[row, col - 1] == matrix[row - 1, col])
                {
                    // Go diagonal
                    sb.Append(str1[col - 1]);
                    col--;
                    row--;
                }
                else
                {
                    if (matrix[row, col - 1] > matrix[row - 1, col])
                    {
                        col--;
                    }
                    else
                    {
                        row--;
                    }
                }

            }

            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));
        }
    }
}
