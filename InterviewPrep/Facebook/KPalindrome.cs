namespace InterviewPrep.Facebook
{
    /* K-Palindrome */
    /* Given a string, find out if the string is K-Palindrome or not. A k-palindrome string transforms into 
        a palindrome on removing at most k characters from it. */
    /* https://practice.geeksforgeeks.org/problems/k-palindrome/1 */
    class KPalindrome
    {
        public bool IsKPalindrome(string str, int k)
        {
            if (string.IsNullOrEmpty(str)) return false;

            return PalindromeCalculator(str, k);
        }

        private bool PalindromeCalculator(string str, int k)
        {
            if (str.Length <= 1)
                return true;

            while (str[0] == str[str.Length - 1])
            {
                str = str.Substring(1, str.Length - 2);

                if (str.Length <= 1)
                    return true;
            }

            if (k == 0)
                return false;

            return PalindromeCalculator(str.Substring(1, str.Length - 1), k - 1) || PalindromeCalculator(str.Substring(0, str.Length - 1), k - 1);
        }

    }
}
