namespace InterviewPrep.Amazon
{
    /* Given two numbers, return the number of odd numbers between them as an array */
    class NumberOfOddNumbers
    {
        public int[] GetOddNumbers(int l, int r)
        {
            int n = 0;

            // If l is even, r is even then number of odd numbers will be  (r - l) / 2 
            // Else n = (r - l) / 2 + 1;
            if (l % 2 == 0 && r % 2 == 0)
                n = (r - l) / 2;
            else
                n = (r - l) / 2 + 1;

            int[] arr = new int[n];
            int pointer = 0;
            while (l <= r)
            {
                if (l % 2 == 1)
                {
                    arr[pointer] = l;
                    pointer++;
                }

                l++;
            }

            return arr;
        }
    }
}
