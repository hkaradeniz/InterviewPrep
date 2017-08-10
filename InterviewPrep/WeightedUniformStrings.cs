using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    // Weighted Uniform Strings
    // https://www.hackerrank.com/challenges/weighted-uniform-string
    /*
      
    */
    class WeightedUniformStrings
    {
        public void SolveWeightedUniformStrings(string s, int x)
        {
            // s: string (Ex: abccddde)
            // w: weight (Ex: 6) -> make sure if it exists or not

            HashSet<int> hash = new HashSet<int>();
            int counter = 1;
            int lastchar = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int currentchar = s[i] - 96;

                if (currentchar == lastchar)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                    lastchar = currentchar;
                }

                int totalWeight = counter * (s[i] - 96);

                if (!hash.Contains(totalWeight))
                    hash.Add(totalWeight);
            }

            Console.WriteLine(hash.Contains(x) ? "Yes" : "No");
        }
    }
}
