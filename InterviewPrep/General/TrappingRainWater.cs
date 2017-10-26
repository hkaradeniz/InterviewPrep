using System;

namespace InterviewPrep.General
{
    class TrappingRainWater
    {
        /* Trapping Rain Water between Towers Problem */
        /* Given n non-negative integers representing an elevation map where the width of each bar is 1, 
         * compute how much water it is able to trap after raining. */

        /*
         Sample Tower

            **
            **    **
            **  ****
            ********
            ********
            5 1 3 4
            
            
            -1 5 5 5
             4 4 4 -1
           = 0 3 1 0 
               | ||
               Min of 5 and 4 is 4 = 4-1(array[1]) is 3
                 ||
                 Min of 5 and 4 is 4 = 4-3(array[2]) is 1
                        |||
                        Don't need to calculate the edges
         */
        /*
         Test Data:
          General.TrappingRainWater tp = new General.TrappingRainWater();
           Console.WriteLine(tp.ComputeTrappingRainWater(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
         */
        public int ComputeTrappingRainWater(int[] towers)
        {
            if (towers == null || towers.Length==0) return 0;

            int totalWater = 0;
            int n = towers.Length;
            int[] left = new int[n];
            int[] right = new int[n];

            // Filling left array
            left[0] = towers[0];
            for (int i = 1; i < n; i++)
            {
                left[i] = Math.Max(left[i - 1], towers[i]);
            }

            // Filling Right array
            right[n-1] = towers[n-1];
            for (int i = n-2; i >= 0; i--)
            {
                right[i] = Math.Max(right[i + 1], towers[i]);
            }

            // Don't need to calculate the edges
            for (int i = 1; i < n-1; i++)
            {
                totalWater += Math.Min(left[i], right[i]) - towers[i];
            }

            return totalWater;
        }
    }
}
