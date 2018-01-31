namespace InterviewPrep.Amazon
{
    /*  Greatest Common Divisor (GCD) of an Array */
    /* For a given array find out the GCD of the array. */
    /* https://practice.geeksforgeeks.org/problems/gcd-of-array/0 */
    class GreatestCommonDivisor
    {
        /*
         * Euclid's Algorithm
         In mathematics, the Euclidean algorithm, or Euclid's algorithm, is an efficient method for 
         computing the greatest common divisor (GCD) of two numbers, the largest number that divides 
         both of them without leaving a remainder. 

        The Euclidean algorithm is based on the principle that the greatest common divisor of two 
        numbers does not change if the larger number is replaced by its difference with the smaller number. 
        For example, 21 is the GCD of 252 and 105 (as 252 = 21 × 12 and 105 = 21 × 5), and the same number 21 
        is also the GCD of 105 and 252 − 105 = 147. Since this replacement reduces the larger of the two numbers, 
        repeating this process gives successively smaller pairs of numbers until the two numbers become equal. 
        When that occurs, they are the GCD of the original two numbers. By reversing the steps, the GCD can be 
        expressed as a sum of the two original numbers each multiplied by a positive or negative integer, 
        e.g., 21 = 5 × 105 + (−2) × 252. The fact that the GCD can always be expressed in this way is known 
        as Bézout's identity.
         */
        public int GetGCD(int[] arr)
        {
            if (arr == null || arr.Length == 0) return -1;

            int result = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                result = GCD(arr[i], result);
            }

            return result;
        }

        private int GCD(int a, int b)
        {
            return a == 0 ? b : GCD(b % a, a);
        }
    }
}
