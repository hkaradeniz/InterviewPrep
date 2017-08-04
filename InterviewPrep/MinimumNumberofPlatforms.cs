using System;

namespace InterviewPrep
{
    class MinimumNumberofPlatforms
    {
        /*
         Minimum Number of Platforms Required for a Railway/Bus Station
         Given arrival and departure times of all trains that reach a railway station, 
         find the minimum number of platforms required for the railway station so that no train waits.
         We are given two arrays which represent arrival and departure times of trains that stop

         arr[]  = {9:00,  9:40, 9:50,  11:00, 15:00, 18:00}
         dep[]  = {9:10, 12:00, 11:20, 11:30, 19:00, 20:00}

        All events sorted by time.
        Total platforms at any time can be obtained by subtracting total 
        departures from total arrivals by that time.
         Time     Event Type     Total Platforms Needed at this Time                               
         9:00       Arrival                  1
         9:10       Departure                0
         9:40       Arrival                  1
         9:50       Arrival                  2
         11:00      Arrival                  3 
         11:20      Departure                2
         11:30      Departure                1
         12:00      Departure                0
         15:00      Arrival                  1
         18:00      Arrival                  2 
         19:00      Departure                1
         20:00      Departure                0

        Minimum Platforms needed on railway station = Maximum platforms 
                                                      needed at any time 
                                           = 3  
         */

        public int MinPlatformNeeded(int[] arrivals, int[] departures, int size)
        {
            int minPlatformNeeded = 1;
            int i = 1; int j = 0;

            Array.Sort(arrivals);
            Array.Sort(departures);

            while (i < size && j < size)
            {
                if (arrivals[i] < departures[j])
                {
                    minPlatformNeeded++;
                    i++;
                }
                else
                {
                    if (minPlatformNeeded > 1)
                        minPlatformNeeded--;
                    j++;
                }
            }

            return minPlatformNeeded;
        }
    }
}
