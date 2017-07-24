using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep
{
    class GroupAnagrams
    {
        //http://blog.gainlo.co/index.php/2016/05/06/group-anagrams/
        // Group Anagrams
        // Given a set of random string, write a function that returns a set that groups all the anagrams together.
        // For example, suppose that we have the following strings:
        // “cat”, “dog”, “act”, “door”, “odor”
        // Then we should return these sets: {“cat”, “act”}, {“dog”}, {“door”, “odor”}.
        // Google, Facebook, Uber, Linkedin 

        // First String: Sorted string
        // Second String: Original string
        Dictionary<string, string> dict;

        public GroupAnagrams()
        {
            dict = new Dictionary<string, string>();
        }

        public void SolveGroupAnagrams(string text)
        {
            string[] strArr = text.Split(',');

            // Sort all words in the string
            // Place the sorted string in Dictionary as the key value and the original string as value
            // If sorted string matches with the original string, update the value (add the original string in the value with ',')  
            foreach (var word in strArr)
            {
                string sortedString = SortString(word);

                if (dict.ContainsKey(sortedString))
                    dict[sortedString] = dict[sortedString] + "," + word;
                else
                    dict.Add(sortedString, word);
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{" + item.Value + "}");
            }           
        }

        private string SortString(string str)
        {
            // Linq: String.Concat(str.OrderBy(c => c))

            if (!String.IsNullOrEmpty(str))
            {
                char[] charArr = str.ToArray();
                Array.Sort(charArr);
                return new string(charArr);
            }

            return string.Empty;
        }
    }
}
