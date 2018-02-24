using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    class PalindromicSubstrings
    {
        /*
        public void CheckPalindrome(string s)
        {
            int L = s.Length;
            HashSet<string> hs = new HashSet<string>();
            // add elements to the hash set
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < (L - i); j++)
                {
                    string substring = s.Substring(j, i + j + 1);
                    if (IsPalindrome(substring))
                        hs.Add(substring);
                }
            }

            PrintSet(hs);
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length <= 1)
                return true;

            return s[0] == s[s.Length - 1] && IsPalindrome(s.Substring(1, s.Length - 2));

        }
        */

        public void GetPalindromicSubtrings(string str)
        {
            if (string.IsNullOrEmpty(str)) return;

            HashSet<string> palindromes = new HashSet<string>();

            for (int i = 0; i < str.Length; i++)
            {
                Expand(str, i, i, palindromes);
                Expand(str, i, i + 1, palindromes);
            }

            PrintSet(palindromes);
        }

        private void Expand(string str, int left, int right, HashSet<string> palindromes)
        {
            while (left >= 0 && right < str.Length && str[left] == str[right])
            {
                palindromes.Add(str.Substring(left, right - left + 1));

                left--;
                right++;
            }
        }
   
        private void PrintSet(HashSet<string> palindromes)
        {
            foreach (var item in palindromes)
            {
                System.Console.Write($" { item } ");
            }
        }
        
    }
}
