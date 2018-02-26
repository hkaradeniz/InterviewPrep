using System;
using System.Collections.Generic;

namespace InterviewPrep.Contest
{
    /* Amazon Interview Question */
    /* Shortest distance of a string containing all given words */
    /*
     targetList = ["2abc","bcd","cab"]
     availableTagList = ["abc", "2abc", "cab", "bcd", "bcb"]
     
     Output: 1, 3

     Test:
        List<string> targetList = new List<string>();
        List<string> availableTagList = new List<string>();
        targetList.Add("2abc");
        targetList.Add("bcd");
        targetList.Add("cab");
        availableTagList.Add("abc");
        availableTagList.Add("2abc");
        availableTagList.Add("cab");
        availableTagList.Add("bcd");
        availableTagList.Add("bcb");


        // targetList = ["2abc", "bcd", "cab"]
        // availableTagList = ["abc", "2abc", "cab", "bcb", "afd", "abs", "pol", "cab", "bcd", "2abc"]

        List<string> targetList = new List<string>();
        List<string> availableTagList = new List<string>();
        targetList.Add("2abc");
        targetList.Add("bcd");
        targetList.Add("cab");
        availableTagList.Add("abc");
        availableTagList.Add("2abc");
        availableTagList.Add("cab");
        availableTagList.Add("bcb");
        availableTagList.Add("afd");
        availableTagList.Add("abs");
        availableTagList.Add("pol");
        availableTagList.Add("cab");
        availableTagList.Add("bcd");
        availableTagList.Add("2abc");
        Contest.ShortestSubstring ss = new Contest.ShortestSubstring();
        ss.SubSequenceTags(targetList, availableTagList);
     */
    class ShortestSubstring
    {
        public List<int> SubSequenceTags(List<string> targetList, List<string> availableTagList)
        {
            List<int> resultSet = new List<int>();

            Dictionary<string, int> targetDict = new Dictionary<string, int>();

            // Add targetList into Dictionary
            // -1, not found yet
            foreach (var item in targetList)
            {
                targetDict.Add(item, -1);
            }

            int total = targetList.Count;
            int count = 0;
            int rangeDifference = int.MaxValue;
            int start = 0; int end = 0;

            // targetList = ["2abc", "bcd", "cab"]
            // availableTagList = ["abc", "2abc", "cab", "bcb", "afd", "abs", "pol", "cab", "bcd", "2abc"]

            for (int i = 0; i < availableTagList.Count; i++)
            {
                if (targetDict.ContainsKey(availableTagList[i]) == true)
                {
                    int index = targetDict[availableTagList[i]];

                    if (index == -1) count++;

                    targetDict[availableTagList[i]] = i;

                    // This means all tags in targetDict is found
                    if (count == total)
                    {
                        // Find the min index
                        int minIndex = int.MaxValue;
                        foreach (var item in targetDict)
                        {
                            if (item.Value < minIndex)
                                minIndex = item.Value;
                        }

                        // Check if current range smaller than the existing
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

            resultSet.Add(start);
            resultSet.Add(end);

            Console.WriteLine($"{start}, {end}");

            return resultSet;
        }
    }
}
