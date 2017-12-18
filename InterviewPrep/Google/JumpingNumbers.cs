using System;
using System.Collections.Generic;

namespace InterviewPrep.Google
{
    /* Jumping Numbers */
    /* https://practice.geeksforgeeks.org/problems/jumping-numbers/0 */
    /* Given a positive number x, print all Jumping Numbers smaller than or equal to x. 
    A number is called as a Jumping Number if all adjacent digits in it differ by 1. 
    The difference between ‘9’ and ‘0’ is not considered as 1. All single digit numbers 
    are considered as Jumping Numbers. For example 7, 8987 and 4343456 are Jumping 
    numbers but 796 and 89098 are not.*/

    class JumpingNumbers
    {
        public void PrintJumpingNumbers(int k)
        {
            if (k == 0) Console.WriteLine(k);

            for (int i = 1; i <= 9 && i<=k; i++)
            {
                BFS(k, i);       
            }
        }

        private void BFS(int k, int number)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(number);

            while (queue.Count > 0)
            {
                number = queue.Dequeue();

                if (number <= k)
                {
                    Console.Write($"{number}, ");

                    int lastDigit = number % 10;

                    if (lastDigit == 0)
                    {
                        queue.Enqueue(number * 10 + lastDigit + 1);
                    }
                    else if (lastDigit == 9)
                    {
                        queue.Enqueue(number * 10 + lastDigit + -1);
                    }
                    else
                    {
                        queue.Enqueue(number * 10 + lastDigit + 1);
                        queue.Enqueue(number * 10 + lastDigit - 1);
                    }
                }
            }
        }
    }
}
