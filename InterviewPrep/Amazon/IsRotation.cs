using System;

namespace InterviewPrep.Amazon
{
    /* Given two words, find if second word is the round rotation of first word.
        For example: abc, cab */
    class IsRotation
    {
        public bool IsRotated(string word1, string word2)
        {
            if (String.IsNullOrEmpty(word1) || String.IsNullOrEmpty(word1)) return false;

            if (word1.Length != word2.Length) return false;

            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] != word2[word2.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
