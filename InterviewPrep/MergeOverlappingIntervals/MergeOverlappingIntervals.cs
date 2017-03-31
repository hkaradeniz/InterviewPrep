using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep.MergeOverlappingIntervals
{
    class MergeOverlappingIntervals
    {
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
