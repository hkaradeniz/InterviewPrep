using System;

namespace InterviewPrep.Microsoft
{
    // Counting Sort
    // Counting sort is a sorting technique based on keys between a specific range.
    /*
     Test:            
     Microsoft.CountingSort cs = new Microsoft.CountingSort();
     cs.Sort(new char[] {'g', 'e', 'e', 'k', 's', 'f', 'o', 'r', 'g', 'e', 'e', 'k', 's' });
     */
    class CountingSort
    {
        private static int ASCII = 256;
        public void Sort(char[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            int[] countArr = new int[ASCII];

            for (int i = 0; i < arr.Length; i++)
            {
                countArr[arr[i] - 'a']++;
            }

            int scanner = 0;
            int pointer = 0;
            while (scanner < ASCII)
            {
                while (scanner < ASCII && countArr[scanner] > 0)
                {
                    arr[pointer] = (char) (scanner + 97);
                    pointer++;
                    countArr[scanner]--;
                }

                scanner++;
            }

            Print(arr);
        }

        private void Print(char[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item}");
            }
        }
    }
}
