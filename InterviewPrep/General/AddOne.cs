namespace InterviewPrep.General
{
    class AddOne
    {
        /* Add 1 to an int array */
        /*
         Example:
         [1,2,3] => [1,2,4]
         [1,2,9] => [1,3,0]
         [9,9,9] => [1,0,0,0]
        */
        /*
        Test Data:
         General.AddOne ad = new General.AddOne();
         ad.AddOneToArray(new int[] { 9, 9, 9 });
         */
        public int[] AddOneToArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return new int[] { -1 };

            int n = arr.Length;
            int[] result = new int[n];
            int carry = 1;

            for (int i = n-1; i >= 0; i--)
            {
                int sum = arr[i] + carry;

                int value = sum % 10;
                carry = sum / 10;

                result[i] = value;
            }

            if (carry == 1)
            {
                result = new int[n + 1];
                result[0] = 1;
            }

            return result;
        }
    }
}
