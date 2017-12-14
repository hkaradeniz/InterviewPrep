using System;

namespace InterviewPrep.General
{
    class MedianOfArrays
    {
        /*
         There are 2 sorted arrays A and B of size n each. Write an algorithm to find the median of the 
         array obtained after merging the above 2 arrays(i.e. array of length 2n). 
         The complexity should be O(log(n)).
         */

        /* Naive approach:  Merge these two arrays together and find the median. 
           Time: O(N+N) => O(N)
           Space: O(N+N) => O(N)
         */

        /*  
         The median
            The median is the middle number. To calculate the median of any set of numbers, you need to write the numbers in order.
            To find the median number:
            Put all the numbers in numerical order.
            If there is an odd number of results, the median is the middle number.
            If there is an even number of results, the median will be the mean of the two central numbers.
         */

        // Median of two sorted arrays of same size
        /*
            1) Calculate the medians m1 and m2 of the input arrays ar1[] 
               and ar2[] respectively.
            2) If m1 and m2 both are equal then we are done.
                 return m1 (or m2)
            3) If m1 is greater than m2, then median is present in one 
               of the below two subarrays.
                a)  From first element of ar1 to m1 (ar1[0...|_n/2_|])
                b)  From m2 to last element of ar2  (ar2[|_n/2_|...n-1])
            4) If m2 is greater than m1, then median is present in one    
               of the below two subarrays.
               a)  From m1 to last element of ar1  (ar1[|_n/2_|...n-1])
               b)  From first element of ar2 to m2 (ar2[0...|_n/2_|])
            5) Repeat the above process until size of both the subarrays 
               becomes 2.
            6) If size of the two arrays is 2 then use below formula to get 
              the median.
                Median = (max(ar1[0], ar2[0]) + min(ar1[1], ar2[1]))/2



            Example:

               ar1[] = {1, 12, 15, 26, 38}
               ar2[] = {2, 13, 17, 30, 45}
            
            For above two arrays m1 = 15 and m2 = 17

            For the above ar1[] and ar2[], m1 is smaller than m2. So median is present in one of the following two subarrays.
               [15, 26, 38] and [2, 13, 17]
            
            Let us repeat the process for above two subarrays:
                m1 = 26 m2 = 13.

            m1 is greater than m2. So the subarrays become
              [15, 26] and [13, 17]

            Now size is 2, so median = (max(ar1[0], ar2[0]) + min(ar1[1], ar2[1]))/2
                                   = (max(15, 13) + min(26, 17))/2 
                                   = (15 + 17)/2
                                   = 16
         */

        /*
            General.MedianOfArrays mo = new General.MedianOfArrays();
            int[] arr1 = { 1, 3, 8, 9, 15 };
            int[] arr2 = { 7, 11, 18, 19, 21 };
            Console.WriteLine(mo.GetMedian(arr1, arr2));
         */
        public double GetMedian(int[] arrX, int[] arrY)
        {
            /*
               Solution 2: Works for both same size and different size arrays

               x: 1    3       8       9       15      
               y: 7    11      18      19      21      25

               We will be performing binary search on the smaller size array and try to find a partition point where
                  x => x1      x2   |   x3      x4      x5        x6 
                  y => y1      y2       y3      y4      y5   |    y6      y7      y8

                               2 + 5 = 7                                   4 + 3 = 7

                                   if x2 < y6 AND 
                                      y5 < x3 
                                           This point is the median 
                                               if totalNumberOfElements: odd
                                                   avg(max(x2, y5), min(y6, x3));
                                               if  totalNumberOfElements: even
                                                   max(x2, y5);


             ------------------------------------------------------------------------------------
             
               x: 1    3   |   8       9       15      
               y: 7    11      18      19  |   21      25           x + y: 1   3   7   8   9   11  15  18  19  21  25  Median: 11

                 1   3           |   8    9    15                  Start: 0
                 7   11  18  19  |  21   25                        End: 4   
                                 |                                 Partition X: (0 + 4) / 2 => 2
                                                                   Partition Y: (5 + 6 + 1) / 2 - Partition X = 4   

                     3 < 21 True
                     19 < 8 False
               * We have to move X towards right
              ------------------------------------------------------------------------------------  
              
               x: 1    3       8   |   9       15      
               y: 7    11      18  |   19      21      25           

                 1   3   8    |  9    15                            Start: Partition X + 1 = 2 + 1 = 3
                 7   11  18   |  19   21   25                       End: 4   
                              |                                     Partition X: (3 + 4) / 2 => 3
                                                                    Partition Y: (5 + 6 + 1) / 2 - Partition X = 3   

                     8 < 19 True
                     18 < 9 False
               * We have to move X towards right
             ------------------------------------------------------------------------------------  
             
               x: 1    3       8       9   |   15      
               y: 7    11  |   18      19      21      25           

                 1   3   8    9     |   15                            Start: Partition X + 1 = 3 + 1 = 4
                 7   11             |   18   19   21   25             End: 4   
                                    |                                 Partition X: (4 + 4) / 2 => 4
                                                                      Partition Y: (5 + 6 + 1) / 2 - Partition X = 2   

                     9 < 18 True
                     11 < 15 True
               * We have found it
             ------------------------------------------------------------------------------------  
             ------------------------------------------------------------------------------------  

                EDGE CASE EXAMPLE:
                  x: 23   26      31      35
                  y: 3    5       7       9      11      16             Median: 13.5

                 
            
                    Start: 0
                    End: 4   
                    Partition X: (0 + 4) / 2 => 2
                    Partition Y: (4 + 6 + 1) / 2 - Partition X = 3   

                
                  x: 23   26  |   31      35
                  y: 3    5       7   |   9      11      16 
                   

                    23  26      |   31  35
                    3   5   7   |   9   11  16
                                |        

                    26 < 9  False
                    7  < 31 True
                    * We have to move X towards left
                     
             ------------------------------------------------------------------------------------
              
                    Start: 0
                    End: 1  (Partition X - 1) = 1
                    Partition X: (0 + 1) / 2 => 0
                    Partition Y: (4 + 6 + 1) / 2 - Partition X = 5   

                
                  x: | 23   26   31      35
                  y:    3    5   7       9      11  |    16 
                   

                    { }               |   23     26      31    35
                    3   5   7  9   11 |     16
                                |        

                    { } < 16  True  {} => Int.Min (-INF)
                    11  < 26 True  
                   * We have found it
                   avg (max(-INF, 11), min(23, 16))
                    => (11 + 16) / 2 = 13.5
             ------------------------------------------------------------------------------------  
             ------------------------------------------------------------------------------------  
             */


            if (arrX.Length < 1 && arrY.Length < 1) return 0;

            int[] minArray = arrX.Length < arrY.Length ? arrX : arrY;
            int[] maxArray = arrX.Length < arrY.Length ? arrY : arrX;

            int xSize = minArray.Length;
            int ySize = maxArray.Length;

            int left = 0;
            int right = xSize;

            while (left <= right)
            {
                int partitionX = (left + right) / 2;
                int partitionY = (xSize + ySize + 1) / 2 - partitionX;

                int leftX = partitionX == 0 ? int.MinValue : arrX[partitionX - 1];
                int rightX = partitionX == xSize ? int.MaxValue : arrX[partitionX];

                int leftY = partitionY == 0 ? int.MinValue : arrY[partitionY - 1];
                int rightY = partitionY == ySize ? int.MaxValue : arrY[partitionY];


                if (leftX < rightY && leftY < rightX)
                {
                    // We have found it...
                    // Make sure if the combined array has odd or even number of elements
                    if ((ySize + xSize) % 2 == 0)
                    {
                        // Even Number
                        return (double)(Math.Max(leftX, leftY) + Math.Min(rightX, rightY)) / 2;
                    }
                    else
                    {
                        return (Math.Max(leftX, leftY));
                    }
                }
                else if (leftX > rightY)
                {
                    right = partitionX - 1;
                }
                else
                {
                    left = partitionX + 1;
                }
            }

            return -1;
        }
    }
}
