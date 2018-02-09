namespace InterviewPrep.Facebook
{
    /* Interleaved Strings */
    /* Given three strings A, B and C your task is to complete the function isInterleave 
     * which returns true if C is an interleaving of A and B else returns false. 
     * C is said to be interleaving A and B, if it contains all characters of A and B 
     * and order of all characters in individual strings is preserved. */
    /* https://practice.geeksforgeeks.org/problems/interleaved-strings/1 */
    /*
     Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

        Example,
        Given:

        s1 = "aabcc",
        s2 = "dbbca",
        When s3 = "aadbbcbcac", return true.
        When s3 = "aadbbbaccc", return false.

        Return 0 / 1 ( 0 for false, 1 for true ) for this problem
     */
    class InterleavedStrings
    {
        private string A, B, C;

        public InterleavedStrings(string x, string y, string str)
        {
            A = x;
            B = y;
            C = str;
        }

        public bool IsInterleaved()
        {
            return IsInterleaved(0, 0, 0);
        }

        private bool IsInterleaved(int indexA, int indexB, int indexC)
        {
            if (indexA >= A.Length || indexB >= B.Length || indexC >= C.Length)
                return true;

            return (C[indexC] == A[indexA] && IsInterleaved(indexA + 1, indexB, indexC + 1))
                || (C[indexC] == B[indexB] && IsInterleaved(indexA, indexB + 1, indexC + 1));
        }
    }
}
