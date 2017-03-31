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
    }
}
