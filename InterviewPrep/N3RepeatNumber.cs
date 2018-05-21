using System.Collections.Generic;

namespace InterviewPrep
{
    class N3RepeatNumber
    {
        // N/3 Repeat Number
        /*
            You’re given a read only array of n integers. Find out if any integer 
            occurs more than n/3 times in the array in linear time and constant additional space.

            If so, return the integer. If not, return -1.
         */
        /*
         * Stackoverflow
            Start with two empty candidate slots and two counters set to 0.
            for each item:
            if it is equal to either candidate, increment the corresponding count
            else if there is an empty slot (i.e. a slot with count 0), put it in that slot and set the count to 1
            else reduce both counters by 1
         */
        public int repeatedNumber(List<int> a)
        {
            int n = a.Count;

            int[] arr = new int[2];
            arr[0] = -1;
            arr[1] = -1;
            int count0 = 0;
            int count1 = 0;

            for (int i = 0; i < n; i++)
            {
                if (a[i] == arr[0])
                    count0++;
                else if (a[i] == arr[1])
                    count1++;
                else if (count0 == 0)
                {
                    arr[0] = a[i];
                    count0++;
                }
                else if (count1 == 0)
                {
                    arr[1] = a[i];
                    count1++;
                }
                else
                {
                    count0--;
                    count1--;
                }
            }

            count0 = 0;
            count1 = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == arr[0]) count0++;
                else if (a[i] == arr[1]) count1++;
            }

            if (count0 > n / 3) return arr[0];
            if (count1 > n / 3) return arr[1];
            return -1;
        }
    }
}
