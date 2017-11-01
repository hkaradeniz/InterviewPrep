using System;

namespace InterviewPrep.Sorting
{
    class KnuthShuffle
    {
        /* Can You RANDOMLY Reorder Array in O(N)? */
        /*  The {@code Knuth} class provides a client for reading in a 
             *  sequence of strings and <em>shuffling</em> them using the Knuth (or Fisher-Yates)
             *  shuffling algorithm. This algorithm guarantees to rearrange the
             *  elements in uniformly random order, under
             *  the assumption that Math.random() generates independent and
             *  uniformly distributed numbers between 0 and 1. */

        /* Complexity: O(N) Space Complexity: In-Place*/
        static Random r = new Random();

        /*
         Test Data:
          KnuthShuffle ks = new KnuthShuffle();
          ks.ReOrder(new int[] { 1, 0, 3, 9, 2 });
         */
        public void ReOrder(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentNullException();

            PrintArray(arr);

            for (int i = arr.Length-1; i > 0; i--)
            {
                int pick = (int) (Random() * (i + 1));
                Swap(arr, i, pick);
            }

            PrintArray(arr);
        }

        private double Random()
        {
            /* According to the documentation, Next returns an integer random number between the 
             * (inclusive) minimum and the (exclusive) maximum: */
            /*
             Return Value
               A 32-bit signed integer greater than or equal to minValue and less than maxValue; 
               that is, the range of return values includes minValue but not maxValue. If minValue 
               equals maxValue, minValue is returned.

                The only integer number which fulfills

                0 <= x < 1
                is 0, hence you always get the value 0. In other words, 0 is the only integer that is within the half-closed interval [0, 1).

                So, if you are actually interested in the integer values 0 or 1, then use 2 as upper bound:

                var n = random.Next(0, 2);
                If instead you want to get a decimal between 0 and 1, try:

                var n = random.NextDouble();
             */
            return r.NextDouble();
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        private void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} * ");
            }

            Console.WriteLine();
        }
    }
}
