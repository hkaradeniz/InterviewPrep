using System.Collections.Generic;

namespace InterviewPrep
{
    class FibonacciMemoization
    {
        static Dictionary<int, int> fibmemo = new Dictionary<int, int>();

        /*
          fib(n) = fib(n-1) + fib(n-2)
          fib(0) = 0
          fib(1) = 1
              2  = 1
              3  = 2
              4  = 3
              5  = 5
              6  = 8
              7  = 13
              8  = 21;

            F0	F1	F2	F3	F4	F5	F6	F7	F8	F9	F10	 F11	 
            0	1	1	2	3	5	8	13	21	34	55	 89 	
            
            F12  F13  F14  F15  F16	 F17   F18	 F19   F20
            144  233  377  610  987	 1597  2584	 4181  6765

         */
        // Memoization => O(N) Time
        public int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else if (!fibmemo.ContainsKey(n))
                fibmemo.Add(n, Fibonacci(n - 1) + Fibonacci(n - 2));

            return fibmemo[n];
        }
    }
}
