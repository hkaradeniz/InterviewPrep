using System;

namespace InterviewPrep.Amazon
{
    /* Return two prime numbers */
    /* https://practice.geeksforgeeks.org/problems/return-two-prime-numbers/0 */
    /* Given an even number (greater than 2 ), print two prime numbers whose sum will be equal to given number. 
    There may be several combinations possible. Print only first such pair. */
    /* Goldbach's conjecture is one of the oldest and best-known unsolved problems in number theory and all of mathematics. 
        It states:
        Every even integer greater than 2 can be expressed as the sum of two primes.[1]
        The conjecture has been shown to hold for all integers less than 4 × 1018, 
        but remains unproven despite considerable effort. */
    class GoldbachsConjecture
    {
        // Use Sieve Of Eratosthenes to identify the prime numbers from 2 to n
        // Find two numbers that add up to n

        public void GetTwoPrimes(int n)
        {
            int[] arr = SieveOfEratosthenes(n);
            int pointer = 2;

            while (pointer < n)
            {
                if (arr[pointer] != 0)
                {
                    if (arr[pointer] + arr[n - pointer] == n)
                    { Console.WriteLine($"{n} = {arr[pointer]} + {arr[n - pointer]}"); return; }
                }

                pointer++;
            }
        }

        private int[] SieveOfEratosthenes(int num)
        {
            int[] arr = new int[num + 1];

            for (int i = 2; i < num + 1; i++)
            {
                arr[i] = i;
            }

            int sqrt = (int)Math.Sqrt(num);

            for (int i = 2; i <= sqrt; i++)
            {
                if (arr[i] != 0)
                {
                    for (int j = 2; i * j < num; j++)
                    {
                        arr[i * j] = 0;
                    }
                }
            }

            return arr;
        }
    }
}
