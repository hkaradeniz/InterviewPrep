using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
