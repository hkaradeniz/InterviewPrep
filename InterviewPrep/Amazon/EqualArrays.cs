namespace InterviewPrep.Amazon
{
    /* Check if two arrays are equal or not */
    /* Given two arrays of equal length, the task is to find if given arrays are equal or not. 
     * Two arrays are said to be equal if both of them contain same set of elements, arrangements 
     * (or permutation) of elements may be different though. */
    /* https://practice.geeksforgeeks.org/problems/check-if-two-arrays-are-equal-or-not/0 */
    class EqualArrays
    {
        public bool AreArraysEqual(int[] arr1, int[] arr2)
        {
            int result = arr1[0] ^ arr2[0];

            int pointer = 1;
            while(pointer < arr1.Length && pointer < arr2.Length)
            {
                result ^= arr1[pointer] ^ arr2[pointer];
                pointer++;
            }

            return result == 0;
        }
    }
}
