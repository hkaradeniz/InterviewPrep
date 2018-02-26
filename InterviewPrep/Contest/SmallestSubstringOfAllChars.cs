using System.Collections.Generic;

namespace InterviewPrep.Contest
{
    // Smallest substring of all Character
    // Input: arr = ['x','y','z'] str= "xyyzyzyx"
    // output: zyx

    class SmallestSubstringOfAllChars
    {
        public string GetSmallestSubstring(char[] arr, string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            // Copy arr to a dictionary with index -1;
            for (int i = 0; i < arr.Length; i++)
            {
                dict.Add(arr[i], -1);
            }

            int count = 0;
            int total = arr.Length;
            int start = 0; int end = 0;
            int rangeDifference = int.MaxValue;
            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsKey(str[i]))
                {
                    int index = dict[str[i]];
                    dict[str[i]] = i;

                    if (index == -1) count++;

                    // This means all chars in dict have been found
                    if (count == total)
                    {
                        int minIndex = int.MaxValue;
                        foreach (var item in dict)
                        {
                            if (item.Value < minIndex)
                                minIndex = item.Value;
                        }

                        int tempRangeDifference = i - minIndex;
                        if (tempRangeDifference < rangeDifference)
                        {
                            rangeDifference = tempRangeDifference;
                            start = minIndex;
                            end = i;
                        }
                    }
                }
            }

            return str.Substring(start, end - start + 1);
        }
    }
}
