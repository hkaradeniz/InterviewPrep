using System;
using System.Text;

namespace InterviewPrep.Amazon
{
    // Find the unique character from two strings
    // Assuming all chars are lowercase
    /*
     Find and print the uncommon characters of the two given strings in sorted order. Here uncommon character
     means that either the character is present in one string or it is present in other string but not in both. 
     The strings contain only lowercase characters and can contain duplicates.
     */
    // Complexity: O(M+N)
    class UniqueCharacter
    {
        private static int ALPHABET_SIZE = 26;

        public void FindUniqueCommonChars(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return;

            int[] arr1 = ConvertStringToIntArray(str1);
            int[] arr2 = ConvertStringToIntArray(str2);

            StringBuilder common = new StringBuilder();
            StringBuilder unique = new StringBuilder();

            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (arr1[i] == 0 && arr2[i] == 0)
                    continue;
                else if ((arr1[i] > 0 && arr2[i] == 0) || (arr1[i] == 0 && arr2[i] > 0))
                    unique.Append((char)(i + 97)).Append(' ');
                else
                    common.Append((char)(i + 97)).Append(' ');

            }

            Console.WriteLine($"Unique: {unique.ToString()}");
            Console.WriteLine($"Common: {common.ToString()}");
        }

        private int[] ConvertStringToIntArray(string str)
        {
            int[] alphabet = new int[ALPHABET_SIZE];

            for (int i = 0; i < str.Length; i++)
            {
                alphabet[str[i] - 'a']++;
            }

            return alphabet;
        }
    }
}
