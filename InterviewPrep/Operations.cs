using System;

namespace InterviewPrep
{
    class Operations
    {
        /*? Cracking the Coding Interview, 6th Edition 
         * Operations: Write methods to implement the multiply, subtract, and divide operations for integers.
            The results of all of these are integers. Use only the add operator.
         */
        public int Substract(int a, int b)
        {
            return a + NegateNumber(b);
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new ArithmeticException("Division by zero is undefined!");

            int absA = Abs(a);
            int absB = Abs(b);

            int result = 0;
            int temp = absB;

            while (temp <= absA)
            {
                temp += absB;
                result++;
            }

            if (!((a < 0 && b < 0) || (a > 0 && b > 0)))
                result = NegateNumber(result);

            return result;
        }

        public int Multiply(int a, int b)
        {
            int result = 0;

            for (int i = 0; i < Abs(b); i++)
            {
                result += a;
            }

            // Make sure if b was really negative
            // If so, the result needs to be multiply by (-1)
            if (b < 0)
                result = NegateNumber(result);

            return result;
        }

        // Bitwise operation reverse number
        private int NegateNumber(int num)
        {
            return ~num + 1;
        }

        // Get Absolute value of a number
        private int Abs(int num)
        {
            if (num < 0)
                num = NegateNumber(num);

            return num;
        }
    }
}
