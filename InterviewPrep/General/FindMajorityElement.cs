namespace InterviewPrep.General
{
    class FindMajorityElement
    {
        /* Find Majority Element in an Array */

        /* Use Boyer–Moore majority vote algorithm since we check if the element appears more than 
        half of the size of the array n/2 */

        public int FindElement(int[] arr)
        {
            if (arr == null) return -1;

            int candidate = -1; 
            int count = 0;

            /* With this we find a candidate which appears the most */
            for (int i = 0; i < arr.Length; i++)
            {
                if (count == 0)
                {
                    candidate = arr[i];
                    count = 1;
                }
                else
                {
                    if (candidate == arr[i])
                        count++;
                    else
                        count--;
                }
            }

            /* Let's make sure if the candidate appears more than n/2 */
            int pointer = 0;
            count = 0;
            bool found = false;

            while (pointer < arr.Length)
            {
                if (arr[pointer] == candidate)
                    count++;

                if (count > arr.Length / 2)
                {
                    found = true;
                    break;
                }

                pointer++;
            }

            if (found)
                return candidate;

            return -1;
        }
    }
}
