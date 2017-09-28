using System;
using System.Diagnostics;

namespace InterviewPrep
{
    class Test
    {
        public void ArrayMaxBinarySearchTest()
        {
            /*?
            the maximum amount of memory that can be allocated to any single instance of an Array object 
            ( regardless of whether it's  int[], double[] or your own array) is 2GB. And no, if you 
            have a 64 bit machine, the 2GB limit is still there.

            As with 32-bit Windows operating systems, there is a 2GB limit on the size of an object you can 
            create while running a 64-bit managed application on a 64-bit Windows operating system.
            https://msdn.microsoft.com/en-us/library/ms241064(VS.80).aspx
              */

            /*?
            IN JAVA
            In a recent HotSpot VM, the correct answer is Integer.MAX_VALUE - 5. Once you go beyond that:

            public class Foo {
              public static void main(String[] args) {
                Object[] array = new Object[Integer.MAX_VALUE - 4];
              }
            }
            You get:

            Exception in thread "main" java.lang.OutOfMemoryError:
              Requested array size exceeds VM limit
            */
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch1.Start();

            int[] arr = new int[310000000]; // INT32.MAX This is equivalent of 17.1 GB. Objects in C# CANNOT be more than 2 GB.
            for (int i = 0; i < 310000000; i++)
            {
                arr[i] = i;
            }

            stopwatch1.Stop();
            Console.WriteLine("Time elapsed for preparetion: {0}", stopwatch1.Elapsed);

            int left = 0;
            int right = arr.Length - 1;
            int value = 2;
            stopwatch2.Start();
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == value)
                { Console.WriteLine($"{value} found!"); break; }
                else if (arr[mid] > value)
                    right = mid - 1;
                else
                    left = mid + 1;

            }

            stopwatch2.Stop();
            Console.WriteLine("Time elapsed for operation: {0}", stopwatch2.Elapsed);
        }

    }
}
