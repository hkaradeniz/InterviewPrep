using System;

namespace InterviewPrep.Yahoo
{
    /* Largest prime factor */
    /* Given a no N, the task is to find the largest prime factor of the number. */
    /* https://practice.geeksforgeeks.org/problems/largest-prime-factor/0 */
    class LargestPrimeFactor
    {
        public int FindLargestPrimeFactor(int n)
        {
            if (n <= 1) return -1;

            int sqrt = (int)Math.Sqrt(n);

            int max = 1;
            bool divided;

            for (int i = 2; i <= sqrt && n != 1; i++)
            {
                divided = false;

                while (true)
                {
                    if (n % i != 0)
                        break;

                    n /= i;
                    divided = true;
                }

                if (divided)
                    max = Math.Max(max, i);
            }

            if (n > 1)
                max = n;

            return max;
        }
    }
}
