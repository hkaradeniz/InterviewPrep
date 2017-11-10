namespace InterviewPrep.General
{
    class NumberOccuringOddNumberOfTimes
    {
        /* Find the number which occurs odd number of times */
        /* In an integer array, except for one number which occurs odd number of times, 
            all other numbers occur even number of times. Find the number.  */

        /* Solution: XOR all numbers in the array. If you XOR a number with itself you get 0. If there
            is a number occuring odd number of times, the number will be the output */
        /* Test Data:
            General.NumberOccuringOddNumberOfTimes no = new General.NumberOccuringOddNumberOfTimes();
            Console.WriteLine(no.FindNumber(new int[] {2, 2, 3, 4, 4, 4, 5, 5, 3}));
         */
        /*
            Time Complexity: O(N)
            Space Complexity: O(1)
         */
        public int FindNumber(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            int result = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                result = result ^ arr[i];
            }

            return result;
        }
    }
}
