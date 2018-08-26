namespace InterviewPrep
{
    class ValidPalindrome
    {
        /*
             Given a non-empty string s, you may delete at most one character. 
             Judge whether you can make it a palindrome.

             Example 1:
             Input: "aba"
             Output: True
             Example 2:
             Input: "abca"
             Output: True
             Explanation: You could delete the character 'c'.
             Note:
             The string will only contain lowercase characters a-z. The maximum length of the string is 50000.
         */

        public bool IsValidPalindrome(string s)
        {
            if (s.Length <= 1) return true;
            return IsValidPalindrome(0, s.Length - 1, s, false);
        }

        private bool IsValidPalindrome(int left, int right, string s, bool flag)
        {
            if (left >= right) return true;

            if (s[left] != s[right])
            {
                if (flag) return false;
                flag = true;
                return IsValidPalindrome(left + 1, right, s, flag) || IsValidPalindrome(left, right - 1, s, flag);
            }

            return IsValidPalindrome(left + 1, right - 1, s, flag);
        }
    }
}
