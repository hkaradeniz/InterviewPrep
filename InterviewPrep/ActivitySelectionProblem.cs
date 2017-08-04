using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep
{
    /*
     You are given n activities with their start and finish times. Select the maximum number 
     of activities that can be performed by a single person, assuming that a person can only 
     work on a single activity at a time.
        Example 1 : Consider the following 3 activities sorted by
        by finish time.
             start[]  =  {10, 12, 20};
             finish[] =  {20, 25, 30};
        A person can perform at most two activities. The 
        maximum set of activities that can be executed 
        is {0, 2} [ These are indexes in start[] and 
        finish[] ]

        Example 2 : Consider the following 6 activities 
        sorted by by finish time.
             start[]  =  {1, 3, 0, 5, 8, 5};
             finish[] =  {2, 4, 6, 7, 9, 9};
        A person can perform at most four activities. The 
        maximum set of activities that can be executed 
        is {0, 1, 3, 4} [ These are indexes in start[] and 
        finish[] ]


        STEPS:
        1) Sort the activities according to their finishing time
        2) Select the first activity from the sorted array and print it.
        3) Do following for remaining activities in the sorted array.
            a) If the start time of this activity is greater than or equal to 
        the finish time of previously selected activity then select this activity and print it.


        TEST DATA:
         int[] s =  {1, 3, 0, 5, 8, 5};
         int[] f =  {2, 4, 6, 7, 9, 9};
         int n = s.Length;
        
         MaxActivities(s, f, n);
     */
    class ActivitySelectionProblem
    {
        public int MaxActivities(int[] startTime, int[] endTime, int totalActivity)
        {
            int maxNumberActivity = 1;
            int j = 0;

            //int s[] = { 1, 3, 0, 5, 8, 5 };
            //int f[] = { 2, 4, 6, 7, 9, 9 };

            for (int i = 1; i < totalActivity; i++)
            {
                if (startTime[i] >= endTime[j])
                {
                    maxNumberActivity++;
                    j = i;
                }
            }

            return maxNumberActivity;
        }

        // What do we do when given activities are not sorted?
        private List<Activity> SortActivitiesBasedonEndtime(int[] arr1, int[] arr2, int size)
        {
            List<Activity> timeline = new List<Activity>();

            for (int i = 0; i < size; i++)
            {
                Activity newActivity = new Activity(arr1[i], arr2[2]);
                timeline.Add(newActivity);
            }

            timeline = timeline.OrderBy(f => f.Endtime).ToList();
            return timeline;

            // How to use:
            // startTime = timeline.Select(f => f.Starttime).ToArray()
            // endTime = timeline.Select(f => f.Endtime).ToArray()
        }
    }

    class Activity
    {
        public int Starttime;
        public int Endtime;

        public Activity(int s, int e)
        {
            Starttime = s;
            Endtime = e;
        }
    }
}
