using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Largest Number formed from a Collection */
    /* https://practice.geeksforgeeks.org/problems/largest-number-formed-from-an-array/0 */
    /* Given a list of non negative integers, arrange them in such a manner that they form the largest number possible. */
    class FormTheBiggestNumber
    {
        public void PrintBiggestNumber(List<string> numbers)
        {
            if (numbers == null || numbers.Count == 0) Console.WriteLine("Empty...");

            BiggestNumberComparer bn = new BiggestNumberComparer();

            numbers.Sort(bn);

            foreach (var item in numbers)
            {
                Console.Write($"{item}");
            }
        }
    }

    class BiggestNumberComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string xy = x + y;

            string yx = y + x;

            return xy.CompareTo(yx) > 0 ? -1 : 1;
        }

        /*
            String Compare method results:

            String A: First alphabetically
            String B: Second alphabetically

            Compare(A, B): -1
            Compare(B, A):  1

            Compare(A, A):  0
            Compare(B, B):  0

            Ex:
            string a = "a";
            string b = "b";
    
            c = a.CompareTo(b);
            Console.WriteLine(c); => -1       (This means a is smaller than b)

            c = b.CompareTo(a);
            Console.WriteLine(c); => 1       (This means b is smaller than a)
        */
    }
}
