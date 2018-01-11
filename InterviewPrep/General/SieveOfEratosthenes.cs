using System;

namespace InterviewPrep.General
{
    /*
    In mathematics, the sieve of Eratosthenes is a simple, ancient 
    algorithm for finding all prime numbers up to any given limit. 

        To find all the prime numbers less than or equal to a given integer n by Eratosthenes' method:

        1- Create a list of consecutive integers from 2 through n: (2, 3, 4, ..., n).
        2- Initially, let p equal 2, the smallest prime number.
        3- Enumerate the multiples of p by counting to n from 2p in increments of p, and 
            mark them in the list (these will be 2p, 3p, 4p, ...; the p itself should not be marked).
        4- Find the first number greater than p in the list that is not marked. If there was 
            no such number, stop. Otherwise, let p now equal this new number (which is the next prime), and repeat from step 3.
        5- When the algorithm terminates, the numbers remaining not marked in the list are all the primes below n.
    */
    class SieveOfEratosthenes
    {
        // Find prime numbers up to any given limit
        // array [2,3,4,5,6,7,8,9,10,11] n=11
        public void CalculatePrimeNumbers(int[] arr, int n)
        {
            if (n <= 1) return;
            if (n <= 3) { Console.WriteLine(n); return; }

            int sqrt = (int)Math.Sqrt(n);
            int pointer;

            for (int i = 2; i <= sqrt; i++)
            {
                int num = i;
                pointer = i - 1;

                while (pointer < arr.Length)
                {
                    if (arr[pointer] != -1)
                    {
                        if (arr[pointer] % num == 0)
                            arr[pointer] = -1;
                    }

                    pointer++;
                }
            }

            PrintPrimeNumbers(arr);
        }

        /*
        public void CalculatePrimeNumbers(int[] arr, int n)
        {
            if (arr == null || arr.Length == 0) return;

            int sqrt = (int)(Math.Sqrt(n));

            for (int i = 1; i < sqrt; i++)
            {
                bool isPrime = IsPrime(arr[i]);

                int counter = i + 1;

                while (counter < arr.Length && isPrime)
                {
                    if (arr[counter] % arr[i] == 0)
                        arr[counter] = -1;

                    counter++;
                }
            }

            PrintPrimeNumbers(arr);
        }

        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;

            if (num % 2 == 0 || num % 3 == 0) return false;

            int sqrt = (int)(Math.Sqrt(num));

            for (int i = 5; i <= sqrt; i+=6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                    return false;
            }

            return true;
        }
        */

        private void PrintPrimeNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] != -1)
                    Console.Write($" {arr[i]} ");
            }
        }
    }
}
