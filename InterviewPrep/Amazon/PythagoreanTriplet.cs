using System;

namespace InterviewPrep.Amazon
{
    /* Pythagorean Triplet */
    /* Given an array of integers, write a function that returns true if there is a triplet (a, b, c) that satisfies a2 + b2 = c2. */
    /* https://practice.geeksforgeeks.org/problems/pythagorean-triplet/0 */
    /* 
        Pythagorean triples 
        (3, 4, 5)	        (5, 12, 13)	    (8, 15, 17)	    (7, 24, 25)
        (20, 21, 29)	    (12, 35, 37)	    (9, 40, 41)	    (28, 45, 53)
        (11, 60, 61)	    (16, 63, 65)	    (33, 56, 65)	    (48, 55, 73)
        (13, 84, 85)	    (36, 77, 85)	    (39, 80, 89)	    (65, 72, 97)

    */
    class PythagoreanTriplet
    {
        public void FindPythagoreanTriplet(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            Array.Sort(arr);

            int left, right;

            for (int i = arr.Length-1; i >= 0; i--)
            {
                int c = arr[i] * arr[i];
                left = 0;
                right = i - 1;
                int a = 0;
                int b = 0;

                while (left < right && right > 0 && left < arr.Length - 1)
                {
                    a = (arr[left] * arr[left]);
                    b = (arr[right] * arr[right]);

                    if (a + b == c)
                    { Console.WriteLine($"Yes"); Console.WriteLine($"{a} + {b} = {c}"); return; }
                    else if (a + b > c)
                        right--;
                    else
                        left++;
                }
            }

            Console.WriteLine($"No");
        }
    }
}
