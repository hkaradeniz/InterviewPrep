using System.Collections.Generic;
using System.Text;

namespace InterviewPrep.Facebook
{
    /* Convert to Roman No */
    /* Given an integer n your task is to complete the function convertToRoman 
        which prints the corresponding roman number of n . */
    /* https://practice.geeksforgeeks.org/problems/convert-to-roman-no/1 */

    /*
    Symbol	I	V	X	L	C	D	M
    Value	1	5	10	50	100	500	1,000
     */
    class RomanNumerals
    {
        /*
            Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000
         */

        public string ConvertToRoman(int num)
        {
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] strs = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < values.Length; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    sb.Append(strs[i]);
                }
            }
            return sb.ToString();
        }

        public int romanToInt(string s)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            map.Add("I", 1); map.Add("IV", 4); map.Add("V", 5); map.Add("IX", 9);
            map.Add("X", 10); map.Add("XL", 40); map.Add("L", 50); map.Add("XC", 90);
            map.Add("C", 100); map.Add("CD", 400); map.Add("D", 500); map.Add("CM", 900);
            map.Add("M", 1000);

            string prevChar = " ";
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                string num = prevChar + s[i];

                if (map.ContainsKey(num))
                {
                    result -= map[prevChar];
                    result += map[num];
                }
                else
                {
                    string val = s[i].ToString();
                    result += map[val];
                    prevChar = val;
                }
            }
            return result;
        }
    }
}
