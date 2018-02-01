using System;

namespace InterviewPrep.Amazon
{
    /* N meetings in one room */
    /* These problems called: Activity Selection Problem */
    /* There is one meeting room in Flipkart. There are n meetings in the form of (S [ i ], F [ i ]) where 
     * S [ i ] is start time of meeting i and F [ i ] is finish time of meeting i
     * 
     * What is the maximum number of meetings that can be accommodated in the meeting room ? */
    /* https://practice.geeksforgeeks.org/problems/n-meetings-in-one-room/0 */
    class MaxMeetingsInOneRoom
    {
        /* Solution:
        1) Sort the activities according to their finishing time
        2) Select the first activity from the sorted array and print it.
        3) Do following for remaining activities in the sorted array.
            a) If the start time of this activity is greater than or equal to the finish time of 
            previously selected activity then select this activity and print it. */

        public void MaxNumberOfMeetings(int[] startTimes, int[] endTimes, int n)
        {
            // Assuming arrays are not empty or null and they are ordered according to their end times.
            // E.g:  int startTimes[] =  {1, 3, 0, 5, 8, 5}; int endTimes[] = { 2, 4, 6, 7, 9, 9 };

            int headPointer = 1;
            int tailPointer = 0;

            int maxNumberOfMeetings = 1; // First meeting is always selected...

            while (headPointer < n)
            {
                if (startTimes[headPointer] > endTimes[tailPointer])
                {
                    maxNumberOfMeetings++;
                    tailPointer = headPointer;
                }

                headPointer++;
            }

            Console.WriteLine(maxNumberOfMeetings);
        }
    }
}
