using System;

namespace InterviewPrep
{
    class MinimumNumberOfRooms
    {
        /* You are given a set of check-in and check-out days as an array. How will you calculate the 
         * minimum number of rooms required to accommodate all the guests.*/
        /* If there is someone checking in at day 2 and another person checking out at day 2, you will need a new room */


        public int ComputeMinimumNumberOfRoomsRequired(int[] checkins, int[] checkouts)
        {
            if (checkins == null || checkouts == null) return 0;
            if (checkins.Length != checkouts.Length) return -1; // Inconsistent data

            /* Since we don't actually need to match up the births and deaths, let's sort both. A sorted version of the years
                 might help us solve the problem.*/
            Array.Sort(checkins);
            Array.Sort(checkouts);

            int currentNeed = 0;
            int minimumNeed = 0;

            int pointerCheckIn = 0;
            int pointerCheckOut = 0;

            while (pointerCheckIn < checkins.Length && pointerCheckOut < checkouts.Length)
            {
                if (checkins[pointerCheckIn] <= checkouts[pointerCheckOut])
                {
                    currentNeed++;
                    if (currentNeed > minimumNeed)
                    {
                        minimumNeed = currentNeed;
                    }
                    pointerCheckIn++;
                }
                else
                {
                    currentNeed--;
                    pointerCheckOut++;
                }
            }

            return minimumNeed;
        }
    }
}
