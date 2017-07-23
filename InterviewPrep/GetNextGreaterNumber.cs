using System;
using System.Text;

namespace InterviewPrep
{
    class GetNextGreaterNumber
    {
        /*
            Uber Interview Questions – Arrange Given Numbers To Form The Biggest Number Possible
        */
        int[] digits;

        private int[] InttoIntArr(int number)
        {
            int[] arr;
            string s = number.ToString();
            arr = new int[s.Length];
            int divider = 10;

            for (int i = s.Length-1; i >= 0; i--)
            {
                arr[i] = number % divider;
                number /= 10;
            }

            return arr;
        }

        private int IntArrtoInt(int[] arr)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in digits)
            {
                builder.Append(item.ToString());
            }

            return Convert.ToInt32(builder.ToString());
        }

        public int BiggestNumberPossible(int number)
        {
            digits = InttoIntArr(number);

            Array.Sort(digits);
            Array.Reverse(digits);

            return IntArrtoInt(digits);
        }

        /*
            Uber Interview Questions – Get Next Greater Number

            // Ex: 423862
            Go through each digit from right to left
            Find the first digit that is not in descending order. In the example, it’s 3.
            For all digits after the current digit (862), find the smallest one 
                that is also greater than the current digit, which is 6. Swap it with the current digit.
            So the current number is 426832.
            The last step is to sort all digits after the current digit (6) in ascending order, so we get 426238.
        */

        public int NextGreaterNumberPossible(int number)
        {
            digits = InttoIntArr(number);

            // 423862
            // Go through each digit from right to left
            for (int i = digits.Length-2; i > 0; i--)
            {
                // Find the first digit that is not in descending order. In the example, it’s 3.
                if (digits[i] < digits[i + 1])
                {
                    // For all digits after the current digit (862), find the smallest one 
                    // that is also greater than the current digit, which is 6.
                    for (int j = digits.Length - 1; j > i; j--)
                    {
                        // Swap it with the current digit. 
                        // So the current number is 426832 (from -> 423862).
                        if (digits[j] > digits[i])
                        {
                            int temp = digits[j];
                            digits[j] = digits[i];
                            digits[i] = temp;

                            // Sort all digits after the current digit (6) in ascending order, 
                            // so we get 426238.
                            Array.Sort(digits, i+1, digits.Length-i-1);
                            break;
                        }
                    }

                    break;
                }
            }

            return IntArrtoInt(digits);
        }
    }
}
