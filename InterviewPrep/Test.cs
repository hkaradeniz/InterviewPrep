using System;
using System.Diagnostics;

namespace InterviewPrep
{
    class Test
    {
        // Generic Type Parameter
        /*
         Use generic types to maximize code reuse, type safety, and performance.
         The most common use of generics is to create collection classes.
         The most common use of generics is to create collection classes.
         Generic classes may be constrained to enable access to methods on particular data types.
         Information on the types that are used in a generic data type may be obtained at run-time by using reflection.


         Generics were added to version 2.0 of the C# language and the common language runtime (CLR). 
         Generics introduce to the .NET Framework the concept of type parameters, which make it possible 
         to design classes and methods that defer the specification of one or more types until the class 
         or method is declared and instantiated by client code. For example, by using a generic type 
         parameter T you can write a single class that other client code can use without incurring the 
         cost or risk of runtime casts or boxing operations, as shown here:
         */
        public T[] Reverse<T>(T[] arr)
        {
            int n = arr.Length;
            var newArray = new T[n];

            for (int i = 0; i < n; i++)
            {
                newArray[n - 1 - i] = arr[i];
            }

            return newArray;
        }

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
