namespace InterviewPrep.Sorting
{
    // Bubble Sort
    class BubbleSort
    {
        public void Sort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return;

            bool isSorted = false;
            int lastIndex = arr.Length - 1;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < lastIndex; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                        isSorted = false;
                    }
                }

                lastIndex--;
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /*
         First Pass
         ( 5 1 4 2 8 ) ->  ( 1 5 4 2 8 ), Here, algorithm compares the first two elements, and swaps since 5 > 1.
         ( 1 5 4 2 8 ) ->  ( 1 4 5 2 8 ), Swap since 5 > 4
         ( 1 4 5 2 8 ) ->  ( 1 4 2 5 8 ), Swap since 5 > 2
         ( 1 4 2 5 8 ) ->  ( 1 4 2 5 8 ), Now, since these elements are already in order (8 > 5), algorithm does not swap them.


         Second Pass
         ( 1 4 2 5 8 ) ->  ( 1 4 2 5 8 )
         ( 1 4 2 5 8 ) ->  ( 1 2 4 5 8 ), Swap since 4 > 2
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
         Now, the array is already sorted, but the algorithm does not know if it is completed. 
         The algorithm needs one whole pass without any swap to know it is sorted.


         Third Pass
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
         ( 1 2 4 5 8 ) ->  ( 1 2 4 5 8 )
          
         */
    }
}
