using System;

namespace InterviewPrep
{
    class RotateArray
    {
        public void RotateRight()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int[] shiftedArray = new int[arr.Length];
            int numberOfShifts = 4;

            int length = arr.Length;

            Console.WriteLine("Rotating right...");

            foreach (var item in arr)
            {
                Console.Write($"{item}");
            }

            for (int i = 0; i < length; i++)
            {
                shiftedArray[(i + numberOfShifts + length) % length] = arr[i];
            }

            Console.WriteLine();

            foreach (var item in shiftedArray)
            {
                Console.Write($"{item}");
            }
        }

        public void RotateLeft()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            int[] shiftedArray = new int[arr.Length];
            int numberOfShifts = 4;

            int length = arr.Length;

            Console.WriteLine("Rotating left...");

            foreach (var item in arr)
            {
                Console.Write($"{item}");
            }

            for (int i = 0; i < length; i++)
            {
                shiftedArray[(length + i - numberOfShifts) % length] = arr[i];
            }

            Console.WriteLine();

            foreach (var item in shiftedArray)
            {
                Console.Write($"{item}");
            }
        }
    }
}
