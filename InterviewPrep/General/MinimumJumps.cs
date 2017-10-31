using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.General
{
    class MinimumJumps
    {
        /* Minimum Number of Jumps */
        /* Count the minimum number of jumps to reach the end of an array. */
        /* Example: 
         
         Array: 1,4,3,7,1,2,6,7,6,10 
         Output: 1->4->7->10
         3 Jumps (We start from arr[0])
         */

        public int ComputeMinimumJumps(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return -1;

            return 0;
        }
    }
}
