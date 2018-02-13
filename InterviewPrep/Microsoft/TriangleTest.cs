using System;

namespace InterviewPrep.Microsoft
{
    /*
        Write me a function that receives three integer inputs for the lengths of the sides of a triangle 
        and returns one of four values to determine the triangle type (1=scalene, 2=isosceles, 3=equilateral, 4=error). 
        Generate test cases for the function assuming another developer coded the function
        Please do not use existing class libraries in your answer
    */

    /*
    * Struct for results
    */
    public struct Result
    {
        public static int Scalene = 1;
        public static int Isosceles = 2;
        public static int Equilateral = 3;
        public static int Error = 4;
    }

    class TriangleTest
    {

        public void TriangleType(int a, int b, int c)
        {
            if (IsTriangle(a, b, c))
            {
                if ((a == b) && (a == c))
                {
                    Console.WriteLine(Result.Equilateral);
                }
                else if ((a == b) || (a == c) || (b == c))
                {
                    Console.WriteLine(Result.Isosceles);
                }
                else
                {
                    Console.WriteLine(Result.Scalene);
                }
            }
            else
            {
                Console.WriteLine(Result.Error);
            }
        }

        /*
         * Let's see if this is a triangle or not
         */
        private bool IsTriangle(int a, int b, int c)
        {
            /*
             * Triagle Rules:
             * a,b,c
             * a+b>c>|a-b|
             * a+c>b>|a-c|
             * b+c>a>|b-c|
             */

            if ((a + b) > c && c > getAbsoluteValue(a, b))
            {
                if ((a + c) > b && b > getAbsoluteValue(a, c))
                {
                    if ((c + b) > a && a > getAbsoluteValue(c, b))
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        /* Constraint: 
         * do not use existing class libraries 
         * (Otherwise Math.Abs)
         */

        private int getAbsoluteValue(int x, int y)
        {
            return (x - y) < 0 ? (x - y) * -1 : (x - y);
        }
    }
}
