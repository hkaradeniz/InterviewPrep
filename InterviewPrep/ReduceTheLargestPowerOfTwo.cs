using System;
using System.Numerics;

namespace InterviewPrep
{
    class ReduceTheLargestPowerOfTwo
    {
        public int ShiftRight(int num)
        {
            return num >> 1;
        }

        public bool IsPowerOfTwo(int num)
        {
            return (num & (num - 1)) == 0;
            /*
                Any power of 2 minus 1 is all ones: (2^N - 1 = 111....b)

                2 = 2^1.  2-1 = 1 (1b)
                4 = 2^2.  4-1 = 3 (11b)
                8 = 2^3.  8-1 = 7 (111b)
                Take 8 for example. 1000 & 0111 = 0000
             */
        }

        public BigInteger Reduce(int num)
        {
            /*
            char[] arr = new char[32];
            int pointer = 31;
            bool found = false;
            int pos = 0;

            for (int i = 0; i < 32; i++)
            {
                arr[i] = '0';
            }

            while (found == false && pointer>=0)
            {
                //Console.WriteLine((num & (1 << pointer)));

                if ((num & (1 << pointer)) != 0)
                {
                    found = true;
                    arr[pos] = '1';
                }

                pointer--;
                pos++;
            }

            return new string(arr);
            */

            /*
            int pointer = 31;
            int result = 0;

            while (true && pointer >= 0)
            {
                result = (num & (1 << pointer));

                if (result != 0)
                {
                    break;
                }

                pointer--;
            }

            return result;
            */
            var numBits = (int)Math.Floor(BigInteger.Log(num, 2));
            return BigInteger.Pow(2, numBits);
        }
    }
}
