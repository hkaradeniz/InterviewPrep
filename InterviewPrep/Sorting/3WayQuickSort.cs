using System;

namespace InterviewPrep.Sorting
{
    class _3WayQuickSort
    {
        int[] arr = { 7, 10, 5, 3, 8, 4, 2, 9, 6 };

        public void Run3WayQuickSort()
        {
            Sort(arr, 0, 8);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }        
        }

        private static void Sort(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            int lt = lo, gt = hi, v = a[lo], i = lo;

            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);

                if (cmp < 0)
                {
                    int temp = a[i];
                    a[i] = a[lt];
                    a[lt] = temp;
                    i++; lt++;
                }
                else if (cmp > 0)
                {
                    int temp = a[i];
                    a[i] = a[gt];
                    a[gt] = temp;
                    gt--;
                }
                else
                    i++;
            }

            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }
    }
}
