using System;

namespace InterviewPrep.Contest
{
    /*
        Find the number of ways that a given integer, X, can be expressed as the 
        sum of the N^th powers of unique, natural numbers.

        Sample Input 0
        10
        2

        Sample Output 0
        1

        10 = 1^2 + 3^2
     */
    class ThePowerSum
    {
        public double GetPowerSum(double X, int N, int number)
        {
            if (Math.Pow(number, N) < X)
                return GetPowerSum(X, N, number + 1) + GetPowerSum(X - Math.Pow(number, N), N, number + 1);
            else if (Math.Pow(number, N) == X)
                return 1;
            else
                return 0;
        }
    }
}
