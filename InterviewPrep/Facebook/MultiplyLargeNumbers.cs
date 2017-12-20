using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Facebook
{
    class MultiplyLargeNumbers
    {
        public string Multiply(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2)) return "-1";

            int carry;
            Dictionary<int, StringBuilder> dict = new Dictionary<int, StringBuilder>();

            // 40 * 20
            for (int i = str1.Length-1; i >=0; i--)
            {
                carry = 0;

                StringBuilder sb = new StringBuilder();
                dict.Add(str1.Length - 1 - i, sb);

                //int pad = 0;
                //while (pad < str1.Length - 1 - i)
                //{
                //    sb.Append('0');
                //    pad++;
                //}

                for (int j = str2.Length-1; j >=0; j--)
                {
                    int value = ((str1[i] - '0') * (str2[j] - '0')) + carry;
                    carry = value / 10;
                    value %= 10;

                    sb.Append(value);
                }

                if (carry > 0)
                    sb.Append(carry);
            }

            return string.Empty;
        }
    }
}
