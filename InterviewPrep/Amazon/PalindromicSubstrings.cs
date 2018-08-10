using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    class PalindromicSubstrings
    {
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
