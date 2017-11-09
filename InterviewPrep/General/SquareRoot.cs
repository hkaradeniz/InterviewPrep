using System;

namespace InterviewPrep.General
{
    class SquareRoot
    {
        /* Given an integer, how do you find the square root of the number without using any built-in function?
            If the number is not a perfect square then take precision = 0.0005.
            The number can be a positive or negative integer.
         */

        /* Use Binary Search */
        /*

            Start       End     Mid     PreviousMid     Mid*Mid     Square      Abs(Mid-PreviousMid)<Precision (0.0005)
              0         1024    512         0           512*512  !=  1024           (512-0)<0.0005 (False)
             ...        ...     ...         ...             ...         ...                 ...
        */

        public void CalculareSquareRoot(int n, double precision)
        {
            double left = 0;
            double right = n;
            double difference = 0;
            double previousMid = 0;

            while (left <= right)
            {
                double mid = (right + left) / 2;
                double result = mid * mid;
                difference = Math.Abs(previousMid - mid);

                if (result == n || difference <= precision)
                {
                    Console.WriteLine(mid);
                    break;
                }
                else if (result > n)
                {
                    right = mid;
                    previousMid = mid;
                }
                else
                {
                    left = mid;
                    right = previousMid;
                }
            }
        }
    }
}
