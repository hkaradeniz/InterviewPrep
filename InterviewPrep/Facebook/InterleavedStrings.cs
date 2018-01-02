using System.Text;

namespace InterviewPrep.Facebook
{
    /* Interleaved Strings */
    /* Given three strings A, B and C your task is to complete the function isInterleave 
     * which returns true if C is an interleaving of A and B else returns false. 
     * C is said to be interleaving A and B, if it contains all characters of A and B 
     * and order of all characters in individual strings is preserved. */
    /* https://practice.geeksforgeeks.org/problems/interleaved-strings/1 */
    class InterleavedStrings
    {
        public bool IsInterleaved(string x, string y, string str)
        {
            StringBuilder xy = new StringBuilder();
            StringBuilder yx = new StringBuilder();

            xy.Append(x).Append(y);
            yx.Append(y).Append(x);

            return str == xy.ToString() || str == yx.ToString();
        }
    }
}
