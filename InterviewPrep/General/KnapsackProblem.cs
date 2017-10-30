using System;

namespace InterviewPrep.General
{
    class KnapsackProblem
    {
        /* Knapsack Problem Dynamic Programming */
        /* Given weights and values of n items, put these items in a knapsack of capacity W to get the maximum total value in 
         * the knapsack. In other words, given two integer arrays val[0..n-1] and wt[0..n-1] which represent values and 
         * weights associated with n items respectively. Also given an integer W which represents knapsack capacity, 
         * find out the maximum value subset of val[] such that sum of the weights of this subset is smaller than or 
         * equal to W. You cannot break an item, either pick the complete item, or don’t pick it (0-1 property). */

        /* Solution: For each value in weights array, either we include that to knapsack or not... */
        /* 
         
         Item           0       1       2       3
         Weight         2       2       4       5
         Value          3       7       2       9
         
         Weight = 10
             
                                    CASE 0
                                   Weight=10
                                   Pointer=0
                                     /      \
                                   /         \
                                  /           \
                                 /             \
                              CASE 1            CASE 2
                            Weight= 10           Weight = 8
                            Pointer= 1           Pointer = 1        
                            /       \                       /       \
                          /         \                      /        \
                      CASE 3         CASE 4             CASE 5       CASE 6
                      Weight=10      Weight=8           Weight=8      Weight=6 
                      Pointer=2      Pointer=2          Pointer=2     Pointer=2

            Pointer is the item number:
            Pointer 1: refers to first element in the array
      
         */

        /*
         * Test Data
           General.KnapsackProblem kp = new General.KnapsackProblem();
           Console.WriteLine(kp.KnapSack(10, new int[] {2,2,4,5}, new int[] {3,7,2,9}));
         */
        /* Knapsack Complexity: O(nW) */
        public int KnapSack(int weight, int[] weights, int[] values)
        {
            return KnapSack(weight, 0, weights, values);
        }

        private int KnapSack(int weight, int pointer, int[] weights, int[] values)
        {
            if (weight == 0 || pointer == weights.Length)
                return 0;

            if (weights[pointer] > weight)
              return KnapSack(weight, pointer + 1, weights, values);
            
            int includeValue = values[pointer] + KnapSack(weight - weights[pointer], pointer + 1, weights, values);
            int excludeValue = KnapSack(weight, pointer + 1, weights, values);
                
            return Math.Max(includeValue, excludeValue);
        }
    }
}
