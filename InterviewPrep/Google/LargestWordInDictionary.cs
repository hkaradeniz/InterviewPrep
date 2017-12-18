using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.Google
{
    /* Find largest word in dictionary */
    /* https://practice.geeksforgeeks.org/problems/find-largest-word-in-dictionary/0 */
    /* Giving a dictionary and a string ‘str’, your task is to find the longest string in dictionary of size x which can be formed by deleting some characters of the given ‘str’.

        Examples:

        Input : dict = {"ale", "apple", "monkey", "plea"}   
                str = "abpcplea"  
        Output : plea 

        Input  : dict = {"pintu", "geeksfor", "geeksgeeks", 
                                                " forgeek"} 
                 str = "geeksforgeeks"
        Output : geeksgeeks

        Test Data:
         Google.LargestWordInDictionary wd = new Google.LargestWordInDictionary();
         Console.WriteLine(wd.FindLargestWordInDictionary("geeksforgeeks"));
     */

    class LargestWordInDictionary
    {
        private string largestWord = string.Empty;
        HashSet<string> dictionary = new HashSet<string>();

        public LargestWordInDictionary()
        {
            dictionary.Add("pintu");
            dictionary.Add("geeksfor");
            dictionary.Add("geeksgeeks");
            dictionary.Add(" forgeek");
        }

        public string FindLargestWordInDictionary(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            FindLargestWordInDictionary(str, string.Empty, 0);

            return largestWord;
        }

        private void FindLargestWordInDictionary(string originalStr, string tempStr, int index)
        {
            if (index == originalStr.Length)
            {
                System.Console.WriteLine($": {tempStr.ToString()}");
                return;
            }

            if (tempStr.Length > largestWord.Length && dictionary.Contains(tempStr.ToString()))
                largestWord = tempStr.ToString();

            FindLargestWordInDictionary(originalStr, tempStr + originalStr[index], index + 1);
            FindLargestWordInDictionary(originalStr, tempStr, index + 1);
        }
    }
}
