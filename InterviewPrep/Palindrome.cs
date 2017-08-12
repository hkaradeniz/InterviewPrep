using System;

namespace InterviewPrep
{
    class Palindrome
    {
        // A palindrome has the same letters on both ends of the string. 
        // This means "civic" is a palindrome, but "perks" is not.
        // https://en.wikipedia.org/wiki/Palindrome

        public bool IsPalindrome(string word)
        {
            int head = 0;
            int tail = word.Length - 1;

            if (!String.IsNullOrEmpty(word))
            {
                while (true)
                {
                    if (head > tail)
                        return true;

                    char a = word[head];
                    char b = word[tail];

                    if (char.ToLower(a) != char.ToLower(b))
                        return false;

                    head++;
                    tail--;
                }
            }

            return false;
        }

        public bool IsBinaryPalindrome(int x)
        {

            // Convert int to binary string
            var binary = Convert.ToString(x, 2);
            string str = binary.ToString();

            if (!String.IsNullOrEmpty(str))
            {
                // Removing leading 0's
                str = str.TrimStart(new Char[] { '0' });

                int head = 0;
                int tail = str.Length - 1;

                while (head < tail)
                {
                    if (str[head] == str[tail])
                    {
                        head++;
                        tail--;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public bool IsPalindromeRecursive(string s)
        {
            if (s.Length <= 1) return true;
            return s[0] == s[s.Length - 1] && IsPalindromeRecursive(s.Substring(1, s.Length - 2));
        }
    }
}
