namespace InterviewPrep
{
    class MergeTwoSortedArrays
    {
        public int[] Solve(int[] arr1, int[] arr2)
        {
            // Create a new Array size of length of arr1+arr2;
            int[] newArray = new int[arr1.Length + arr2.Length];

            int i = 0, j = 0, k = 0;

            // Until you reach to an end in one of the arrays,
            // do comparison and assign values to new array
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] < arr2[j])
                    newArray[k++] = arr1[i++];
                else
                    newArray[k++] = arr2[j++];
            }

            // if there is remaining in arr1
            // then add them to new array
            while (i < arr1.Length)
            {
                newArray[k++] = arr1[i++];
            }


            // if there is remaining in arr2
            // then add them to new array
            while (j < arr2.Length)
            {
                newArray[k++] = arr2[j++];
            }

            return newArray;
        }

        // Assume the first array has enough space at the end to store both arrays..
        // E.g: arr1 = [] {1, 5, 10, 12, -1, -1, -1}
        //      arr2 = [] {3, 4, 6}
        public int[] MergeArrays(int[] arr1, int p, int[] arr2)
        {
            // p is the last valid element in array 1
            int pointer1 = p;
            int pointer2 = arr2.Length-1;
            int locator = arr1.Length-1;

            while (pointer1 >= 0 && pointer2 >= 0)
            {
                if (arr1[pointer1] > arr2[pointer2])
                {
                    arr1[locator] = arr1[pointer1];
                    pointer1--;
                }
                else
                {
                    arr1[locator] = arr2[pointer2];
                    pointer2--;
                }

                locator--;
            }

            if (pointer2 >= 0)
                while (pointer2 >= 0)
                {
                    arr1[locator] = arr2[pointer2];
                    pointer2--;
                    locator--;
                }

            PrintArray(arr1);
            return arr1;
        }

        private void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write($"{arr[i]} ");
            }
        }
    }
}
