namespace InterviewPrep.Adobe
{
    /* Trailing zeros in factorial */
    /* For an integer n find number of trailing zeros in n! .  */
    /* https://practice.geeksforgeeks.org/problems/trailing-zeroes-in-factorial/0 */
    class TrailingZeros
    {
        /*
         Solution:
         The above method can cause overflow for a slightly bigger numbers as factorial of a number is a 
         big number (See factorial of 20 given in above examples). The idea is to consider prime factors 
         of a factorial n. A trailing zero is always produced by prime factors 2 and 5. If we can count 
         the number of 5s and 2s, our task is done. Consider the following examples.
         */

        public int NumberOfTrailingZeros(int n)
        {
            if (n < 0) return -1;

            int total = 0;
            int multiplier = 5;

            while (multiplier <= n)
            {
                total += n / multiplier;
                multiplier *= 5;
            }

            return total;
        }
    }
}
