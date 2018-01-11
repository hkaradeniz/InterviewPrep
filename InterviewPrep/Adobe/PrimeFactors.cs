using System;
using System.Text;

namespace InterviewPrep.Adobe
{
    /* Prime factors of a given number */
    class PrimeFactors
    {
        public void FindPrimeFactors(int num)
        {
            if (num == 0 || num==1) { Console.WriteLine(-1); return; }

            StringBuilder sb = new StringBuilder();

            int sqrt = (int)Math.Sqrt(num);

            for (int i = 2; i <= sqrt && i != 1; i++)
            {
                while (true)
                {
                    if (num % i != 0)
                        break;

                    num /= i;
                    sb.Append(i).Append(" ");
                }
            }

            if (num > 2)
                sb.Append(num);

            Console.WriteLine($" {sb.ToString()} ");
        }
    }
}
