using System;

namespace InterviewPrep.Yahoo
{
    /* Largest Product Palindrome */
    /* Given a value n, find out the largest palindrome number which is product of two n digit numbers. */
    /* Input  : n = 2
        * 1<=n<=6
        Output : 9009 
        9009 is the largest number which is product of two 
        2-digit numbers. 9009 = 91*99.

        Input : n = 1
        Output : 9 
     */
    /* https://practice.geeksforgeeks.org/problems/largest-product-pallindrome/0 */
    class LargestProductPalindrome
    {
        public void LargestPalindrome(int n)
        {
            int num1 = GetLargestInt(n);
            int num2, result;

            while (num1 > 0)
            {
                num2 = num1;

                while (num2 > 0)
                {
                    result = num1 * num2;

                    if (IsPalindrome(result))
                    {
                        Console.WriteLine($"Number 1: {num1} \t Number 2: {num2} \t Result: {result}");
                        return;
                    }

                    num2--;
                }

                num1--;
            }

            Console.WriteLine("Not found!");
        }

        private int GetLargestInt(int n)
        {
            int num = 1;

            while (n > 0)
            {
                num *= 10;
                n--;
            }

            return num-1;
        }

        private bool IsPalindrome(int number)
        {
            string s = number.ToString();

            return PalindromeHelper(s);
        }

        private bool PalindromeHelper(string str)
        {
            if (str.Length <= 1)
                return true;

            return str[0] == str[str.Length - 1] && PalindromeHelper(str.Substring(1, str.Length - 2));
        }
    }
}
