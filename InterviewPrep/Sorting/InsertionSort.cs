using System;

namespace InterviewPrep.Sorting
{
    class InsertionSort
    {
        public void Sort(int[] ar)
        {
            int arraySize = ar.Length;
            int j, element;

            for (int i = 1; i < arraySize; i++)
            {
                element = ar[i];
                j = i;
                while (j > 0 && ar[j - 1] > element)
                {
                    ar[j] = ar[j - 1];
                    ar[j - 1] = element;
                    j--;
                }
            }

            foreach (var item in ar)
            {
                Console.WriteLine(item);
            }
        }
    }
}
    