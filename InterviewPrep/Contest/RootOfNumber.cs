using System;
using System.Diagnostics;

namespace InterviewPrep.Contest
{
    class RootOfNumber
    {
        private static double margin = 0.0001;
        // Calculate the nth root of a number with 0.0001 error margin
        public double FindRoot(int number, int n)
        {
            double left = 0;
            double right = number;
            double middle = -1;

            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();

            while (left <= right)
            {
                middle = left + (double)((right - left) / 2);

                double result = Calculate(number, n, middle);

                if (result <= number + margin && result >= number - margin)
                    break;
                else if (result > number)
                    right = middle;
                else
                    left = middle;
            }
            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Milliseconds);

            Console.WriteLine($"{n}th root of {number}: {middle}");

            return middle;
        }

        private double Calculate(int number, int n, double value)
        {
            double result = 1;

            for (int i = 0; i < n; i++)
            {
                result *= value;

                if (result > number)
                    break;
            }

            return result;
        }
    }
}
