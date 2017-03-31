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
    }
}
