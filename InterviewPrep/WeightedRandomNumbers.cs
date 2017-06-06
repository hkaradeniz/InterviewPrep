using System;

namespace InterviewPrep
{
    class WeightedRandomNumbers
    {
        /*
         * http://blog.gainlo.co/index.php/2016/11/11/uber-interview-question-weighted-random-numbers/
         * Write a function that returns values randomly, according to their weight.
          Suppose we have 3 elements with their weights: A (1), B (1) and C (2). 
          The function should return A with probability 25%, B with 25% and C with 50% based on the weights.

            The sampling is like randomly select a point and see which area it falls into. Going into this idea, 
            we can have the following algorithm:
            1- W is the sum of all the weights (length of the horizontal line)
            2= Get a random number R from [0, W] (randomly select a point)
            3- Go over each element in order and keep the sum of weights of visited elements. 
            Once the sum is larger than R, return the current element. This is finding which area includes the point.
         */

        public int SolveWeightedRandomNumbers(int[] arr)
        {
            int w = 0;
            int r = 0;
            int sum = 0;

            foreach (var item in arr)
            {
                w += item;
            }

            r = (new Random()).Next(0, w);

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (sum > r)
                    return i;
            }

            return -1;
        }
    }
}
