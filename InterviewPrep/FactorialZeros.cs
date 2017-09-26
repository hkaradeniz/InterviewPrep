namespace InterviewPrep
{
    /*? 
     * Cracking the Coding Interview, 6th Edition 
     * Factorial Zeros: Write an algorithm which computes the number of trailing zeros in n factorial.
     * We can get the factorial of n then calculate the 0s but for big ints it is not sizeable
     * Get number of 5s in number n, that will give us number of 0s in the number
     */

    class FactorialZeros
    {
        public int GetTrailingZeros(int n)
        {
            int divider = 5;
            int total = 0;

            while (n/divider >= 1)
            {
                total += n / divider;
                divider *= 5;
            }

            return total;
        }
    }
}
