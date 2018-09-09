using System.Collections.Generic;

namespace InterviewPrep
{
    // Given a set of candidate numbers (candidates) (without duplicates) and a target number (target), 
    // find all unique combinations in candidates where the candidate numbers sums to target.
    /*
    The same repeated number may be chosen from candidates unlimited number of times.

        Note:

        All numbers (including target) will be positive integers.
        The solution set must not contain duplicate combinations.
        Example 1:

        Input: candidates = [2,3,6,7], target = 7,
        A solution set is:
        [
          [7],
          [2,2,3]
        ]
        Example 2:

        Input: candidates = [2,3,5], target = 8,
        A solution set is:
        [
          [2,2,2,2],
          [2,3,3],
          [3,5]
        ]
     */
    class CombinationSum
    {
        public IList<IList<int>> ComputeCombinationSum(int[] candidates, int target)
        {
            var results = new List<IList<int>>();
            Compute(results, new List<int>(), candidates, 0, target);
            return results;
        }

        private void Compute(List<IList<int>> results, List<int> list, int[] arr, int pointer, int remaning)
        {
            if (remaning < 0) return;
            else if (remaning == 0) { results.Add(new List<int>(list)); return; }
            else
            {
                for (int i = pointer; i < arr.Length; i++)
                {
                    list.Add(arr[i]);
                    Compute(results, list, arr, i, remaning - arr[i]);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
    }
}
