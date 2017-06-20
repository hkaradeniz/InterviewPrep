using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep.MergeOverlappingIntervals
{
    class MergeOverlappingIntervals
    {
        /* (Similar with Meeting Room Scheduling Problem - Asked by Facebook)
         * Given a list of meeting times, checks if any of them overlaps. 
         * The follow-up question is to return the minimum number of rooms required 
           to accommodate all the meetings.
           Let’s start with an example. Suppose we use interval (start, end) 
           to denote the start and end time of the meeting, we have the 
           following meeting times: (1, 4), (5, 6), (8, 9), (2, 6).
           In the above example, apparently we should return true for the 
           first question since (1, 4) and (2, 6) have overlaps. For the follow-up question,
           we need at least 2 meeting rooms so that (1, 4), (5, 6) will be put in 
           one room and (2, 6), (8, 9) will be in the other.
           The meeting room scheduling problem was asked by Facebook very recently and 
           there are quite a few similar problems.

           http://blog.gainlo.co/index.php/2016/07/12/meeting-room-scheduling-problem/
        */

        List<Interval> intervals = new List<Interval>();
        //[1,3],[2,6],[8,10],[15,18],

        List<Interval> sortedIntervals = new List<Interval>();

        public void Solve()
        {
            Interval i1 = new Interval() { startTime = 1, endTime = 3 };
            Interval i2 = new Interval() { startTime = 2, endTime = 6 };
            Interval i3 = new Interval() { startTime = 8, endTime = 10 };
            Interval i4 = new Interval() { startTime = 15, endTime = 18 };

            intervals.Add(i1);
            intervals.Add(i3);
            intervals.Add(i2);
            intervals.Add(i4);

            OrderIntervals(intervals, 0, intervals.Count - 1);
            //[1,3]
            //[2,6]
            //[8,10]
            //[15,18]

            //int count = intervals.Count;
            int pointer = 1;

            while (pointer != intervals.Count)
            {
                if (intervals[pointer].startTime < intervals[pointer - 1].endTime
                    && intervals[pointer].endTime > intervals[pointer - 1].endTime)
                {
                    intervals[pointer - 1].endTime = intervals[pointer].endTime;
                    intervals.RemoveAt(pointer);
                }
                else
                {
                    pointer++;
                }
            }

            foreach (var item in intervals)
            {
                Console.WriteLine("{0} {1}", item.startTime, item.endTime);
            }
        }

        // QuickSort elements in the list. So we get ascending startTime order
        private void OrderIntervals(List<Interval> list, int left, int right)
        {

            int i = left; int j = right;
            int pivot = list.ElementAt((i + j) / 2).startTime;

            while (i <= j)
            {
                while (list[i].startTime < pivot)
                {
                    i++;
                }

                while (list[j].startTime > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Interval temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++; j--;
                }
            }

            if (left < j)
            {
                OrderIntervals(list, left, j);
            }
            if (i < right)
            {
                OrderIntervals(list, i, right);
            }
        }
    }
}
