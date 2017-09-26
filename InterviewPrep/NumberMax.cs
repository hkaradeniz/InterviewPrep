using System;

namespace InterviewPrep
{
    /*? Cracking the Coding Interview, 6th Edition
         Number Max: Write a method that finds the maximum of two numbers.You should not use if-else
        or any other comparison operator.
      */

    class NumberMax
    {
        public int FindMaxNumber(int a, int b)
        {
            return ((a + b) + Math.Abs(a - b)) / 2;
        }
    }
}
