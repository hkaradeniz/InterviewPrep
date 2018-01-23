namespace InterviewPrep.Oracle
{
    /* Integer Palindrome */
    /* Given an integer, check whether it is a palindrome or not. */
    class IntegerPalindrome
    {
        // Palindrome is a lexical property (relating to the words or vocabulary of a language.) rather than a mathematical one
        // Converting number into string - as long as there is no performance issue - is acceptable. 
        public bool IsIntegerPalindrome(int n)
        {
            string s = n.ToString();

            return PalindromeRecursive(s);
        }

        // Without conversion
        public bool IsPalindrome(int n)
        {
            int reverse = 0;
            int digit = 0;
            int num = n;

            while (n > 0)
            {
                digit = n % 10;
                reverse = reverse * 10 + digit;
                n = n / 10;
            }

            return num == reverse;
        }

        private bool PalindromeRecursive(string str)
        {
            if (str.Length <= 1)
                return true;

            return str[0] == str[str.Length - 1] && PalindromeRecursive(str.Substring(1, str.Length - 2));
        }
    }
}
