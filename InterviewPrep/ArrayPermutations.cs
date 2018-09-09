using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    // Given a collection of distinct integers, return all possible permutations.
    /*
        Example:

        Input: [1,2,3]
            Output:
        [
          [1,2,3],
          [1,3,2],
          [2,1,3],
          [2,3,1],
          [3,1,2],
          [3,2,1]
        ]
     */
    class ArrayPermutations
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            var result = new List<IList<int>>();

            Permute(nums, 0, result);

            return result;
        }

        private void Permute(int[] arr, int pointer, List<IList<int>> result)
        {
            if (pointer == arr.Length)
            {
                result.Add(new List<int>(arr));
                return;
            }
            else
            {
                for (int i = pointer; i < arr.Length; i++)
                {
                    Swap(arr, pointer, i);
                    Permute(arr, pointer + 1, result);
                    Swap(arr, i, pointer);
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
