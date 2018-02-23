using System;

namespace InterviewPrep.Amazon
{
    class PalindromesInRange
    {
        public void Find(int left, int right)
        {
            if (left > right)
                return;

            int count = 0;

            for (int i = left; i <= right; i++)
            {
                if (IsPalindrome(i.ToString()))
                    count++;
            }

            Console.WriteLine($"Number of Palindromes: {count}");
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;

            return s[0] == s[s.Length - 1] && IsPalindrome(s.Substring(1, s.Length - 2));
        }
    }
}
