using System;

namespace InterviewPrep.General
{
    class PowerOfX
    {
        /* Check if a number can be expressed as x raised to power y - Set 1 */
        /* Given a positive integer, find if it can be expressed by integers x and y as x^y 
        where y is greater than 1 and x is greater than 0. */

        /* Solution: 
         1- Get the square root of the number
         2- From 2 to sqrt start getting the mod of the number and dividing the number 
         3- If the mod is other than 0, that means the number is not divisible 
         4- If the number reaches 1 and the mod stays 0, that means the number can be represented as power of x */
        /* Test Data:
            General.PowerOfX px = new General.PowerOfX();
            Console.WriteLine(px.IsPowerOfX(129));
            */
        public bool IsPowerOfX(int number)
        {
            if (number < 1) return false;

            int sqrt = (int)Math.Sqrt(number);

            for (int i = 2; i <= sqrt; i++)
            {
                int temp = number;

                while (true)
                {
                    int remaining = temp % i;
                    temp = temp / i;

                    if (remaining > 0)
                        break;

                    if (temp == 1)
                        return true;
                }
            }

            return false;
        }

        /* Solution - 2: Check if log A / log i is an integer */
        public bool IsPowerOfY(int number)
        {
            if (number < 1) return false;

            int sqrt = (int)Math.Sqrt(number);

            /* Ex:  */
            for (int i = 2; i <= sqrt; i++)
            {
                double value = Math.Log(number) / Math.Log(i);

                if (value == Math.Floor(value))
                    return true;
            }

            return false;
        }
    }
}
