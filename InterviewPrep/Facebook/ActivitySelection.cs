using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep.Facebook
{
    /* Activity Selection */
    /* https://practice.geeksforgeeks.org/problems/activity-selection/0 */
    /* Given N activities with their start and finish times. Select the maximum number of activities that can be performed 
     * by a single person, assuming that a person can only work on a single activity at a time.

        Note : The start time and end time of two activities may coincide. 
     */
    /*
       Test Data:
       int[] s = { 1, 3, 0, 5, 8, 5 };
       int[] f = { 2, 4, 6, 7, 9, 9 };

       Facebook.ActivitySelection ac = new Facebook.ActivitySelection();
       Console.WriteLine(ac.MaxNumberOfActivities(s, f, 6)); 
    */
    class Activity
    {
        public int StartTime { get; }
        public int EndTime { get; }

        public Activity(int start, int end)
        {
            StartTime = start;
            EndTime = end;
        }
    }

    class ActivitySelection
    {

        public int MaxNumberOfActivities(int[] startTimes, int[] endTimes, int numberOfActivities)
        {
            if (startTimes == null || endTimes == null || startTimes.Length == 0 || endTimes.Length == 0)
                return 0;

            List<Activity> activities = new List<Activity>();

            // Adding a beginning activy starts at 0 ends at zero, or display the first activity by default
            Activity defaultBegining = new Activity(0, 0);
            activities.Add(defaultBegining);

            for (int i = 0; i < numberOfActivities; i++)
            {
                Activity newActivity = new Activity(startTimes[i], endTimes[i]);
                activities.Add(newActivity);
            }

            var sortedActivities = activities.OrderBy(o => o.EndTime).ToList();

            int endIndex = 0;
            int counter = 0;
            for (int i = 1; i < numberOfActivities; i++)
            {
                if (sortedActivities[i].StartTime >= sortedActivities[endIndex].EndTime)
                {
                    Console.WriteLine($"Activity starts at {sortedActivities[i].StartTime}.");
                    counter++;
                    endIndex = i;
                }
            }

            return counter;
        }
    }
}
