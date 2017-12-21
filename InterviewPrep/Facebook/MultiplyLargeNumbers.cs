using System;
using System.Collections.Generic;

namespace InterviewPrep.Facebook
{
    class MultiplyLargeNumbers
    {
        public void Multiply(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return;

            int carry;
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            // 40 * 20
            for (int i = str1.Length-1; i >=0; i--)
            {
                carry = 0;

                List<int> list = new List<int>();
                dict.Add(str1.Length - 1 - i, list);

                for (int j = str2.Length-1; j >=0; j--)
                {
                    int value = ((str1[i] - '0') * (str2[j] - '0')) + carry;
                    carry = value / 10;
                    value %= 10;

                    list.Add(value);
                }

                if (carry > 0)
                    list.Add(carry);
            }

            List<int> result = dict[0];
            int resultPointer;
            int c;
            for (int i = 1; i < dict.Count; i++)
            {
                List<int> temp = dict[i];

                resultPointer = i;
                int pointer = 0;
                c = 0;
                int resultCount = result.Count;
                while (pointer < temp.Count)
                {
                    int sum = (temp[pointer]) + c;

                    if (resultPointer < resultCount)
                    {
                        sum += result[resultPointer];
                        c = sum / 10;
                        sum %= 10;

                        result[resultPointer] = sum;
                        resultPointer++;
                    }
                    else
                    {
                        c = sum / 10;
                        sum %= 10;
                        result.Add(sum);
                    }

                    pointer++;
                }

                if(c > 0)
                    result.Add(c);
            }

            for (int i = result.Count-1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
        } 
    }
}
