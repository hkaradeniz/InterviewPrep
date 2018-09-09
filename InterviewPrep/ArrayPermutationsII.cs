using System.Collections.Generic;

namespace InterviewPrep
{
    // Given a collection of numbers that might contain duplicates, return all possible unique permutations.

    /*
        Example:

        Input: [1,1,2]
        Output:
        [
          [1,1,2],
          [1,2,1],
          [2,1,1]
        ]
     */
    class ArrayPermutationsII
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var results = new List<IList<int>>();
            PermuteUnique(nums, 0, results);
            return results;
        }

        private void PermuteUnique(int[] arr, int pointer, List<IList<int>> results)
        {
            if (pointer == arr.Length)
            {
                results.Add(new List<int>(arr));
                return;
            }
            else
            {
                HashSet<int> hash = new HashSet<int>();

                for (int i = pointer; i < arr.Length; i++)
                {
                    if (!hash.Contains(arr[i]))
                    {
                        hash.Add(arr[i]);
                        Swap(arr, pointer, i);
                        PermuteUnique(arr, pointer + 1, results);
                        Swap(arr, i, pointer);
                    }
                }
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
