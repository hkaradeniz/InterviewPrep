using System;

namespace InterviewPrep
{
    class UnknownLengthArray
    {
        public int findNumber(int[] arr, int number)
        {
            int left = 0;
            int right = 0;
            int exponent = 0;

            while (true)
            {
                try
                {
                    if (arr[right] == number) return number;
                    else if (arr[right] < number)
                    {
                        left = right;
                        right = (int)Math.Pow(2, exponent);
                        exponent++;
                    }
                }
                catch
                {
                    break;
                }
            }

            // now we know that the element is between left and right
            int middle;
            while (left <= right)
            {
                middle = left + (right - left) / 2;

                try
                {
                    if (arr[middle] == number) return number - 1;
                    else if (arr[middle] > number) right = middle - 1;
                    else left = middle + 1;
                }
                catch
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
