using System;
using System.Collections.Generic;

namespace InterviewPrep.MergeOverlappingIntervals
{
    class MergeIntervals
    {
        public class Interval
        {
              public int start { get; set; }
              public int end { get; set; }
              Interval() { start = 0; end = 0; }
              public Interval(int s, int e) { start = s; end = e; }
        }

        /*
        Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

        You may assume that the intervals were initially sorted according to their start times.

        Example 1:

        Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
        Output: [[1,5],[6,9]]
        Example 2:

        Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
        Output: [[1,2],[3,10],[12,16]]
        Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
            
         */

        public List<Interval> insert(List<Interval> intervals, Interval newInterval)
        {

            List<Interval> result = new List<Interval>();

            foreach (Interval interval in intervals)
            {
                if (interval.end < newInterval.start)
                {
                    result.Add(interval);
                }
                else if (interval.start > newInterval.end)
                {
                    result.Add(newInterval);
                    newInterval = interval;
                }
                else if (interval.end >= newInterval.start || interval.start <= newInterval.end)
                {
                    newInterval = new Interval(Math.Min(interval.start, newInterval.start), Math.Max(newInterval.end, interval.end));
                }
            }

            result.Add(newInterval);

            return result;
        }
    }
}
