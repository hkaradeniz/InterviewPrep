using System;

namespace InterviewPrep.Contest
{
    // Array Quadruplet
    // Complexity: O(N^3)
    /*
            FourSumProblem fs = new FourSumProblem();
            fs.FindElements(new int[] { 2,7,4,0,9,5,1,3}, 20); 
    */
    class FourSumProblem
    {
        public void FindElements(int[] arr, int sum)
        {
            if (arr == null || arr.Length == 0) return;

            Array.Sort(arr);
            int n = arr.Length;

            for (int i = 0; i < n-4; i++)
            {
                for (int j = i + 1; j < n-3; j++)
                {
                    int low = j;
                    int high = n - 1;

                    int remaining = sum - (arr[j] + arr[i]);

                    while (low < high)
                    {
                        int total = arr[low] + arr[high];

                        if (total == remaining)
                        { Console.WriteLine($"{arr[i]}, {arr[j]}, {arr[low]}, {arr[high]}"); return; }
                        else if (total > remaining)
                            high--;
                        else
                            low++;
                    }
                }
            }

            Console.WriteLine("No Solution");
        }
    }
}
