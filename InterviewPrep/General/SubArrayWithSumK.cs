namespace InterviewPrep.General
{
    class SubArrayWithSumK
    {
        /*
            Given an array A having positive and negative integers and a number k, 
            find the minimum length sub array of A with sum = k.
         */
        /*
        Test Data:
        General.SubArrayWithSumK sk = new General.SubArrayWithSumK();
           sk.FindMinimumSubArrayWithSumK(new int[] { 2, 3, 1, 1, - 1, 3, 4 }, 7);
           */
        public void FindMinimumSubArrayWithSumK(int[] arr, int k)
        {
            if (arr == null || arr.Length == 0) return;

            int head = 0;
            int scanner = 0;
            int currentNumberOfElements = 0;
            int minNumberOfElements = int.MaxValue;
            int currentTotal = 0;

            while (head < arr.Length)
            {
                while (scanner < arr.Length)
                {
                    currentTotal += arr[scanner];
                    currentNumberOfElements++;

                    if (currentTotal == k)
                    {
                        if (currentNumberOfElements < minNumberOfElements)
                            minNumberOfElements = currentNumberOfElements;
                        break;
                    }

                    scanner++;
                }

                currentNumberOfElements = 0;
                currentTotal = 0;
                head++;
                scanner = head;
            }

            System.Console.WriteLine($"Minimum Number of Elements: {minNumberOfElements}");
        }
    }
}
