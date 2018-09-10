using System.Collections.Generic;

namespace InterviewPrep
{
    /*
        Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

        Example:

        Input: n = 4, k = 2
        Output:
        [
          [2,4],
          [3,4],
          [2,3],
          [1,2],
          [1,3],
          [1,4],
        ]
     */
    class Combinations
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var results = new List<IList<int>>();
            Combine(n, 1, k, new List<int>(), results);
            return results;
        }

        private void Combine(int n, int pointer, int k, List<int> list, List<IList<int>> results)
        {
            if (k == 0)
            {
                results.Add(new List<int>(list));
                return;
            }
            else
            {
                for (int i = pointer; i <= n; i++)
                {
                    list.Add(i);
                    Combine(n, i + 1, k - 1, list, results);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
