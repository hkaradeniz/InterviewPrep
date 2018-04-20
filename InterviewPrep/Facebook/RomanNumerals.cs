using System;
using System.Collections.Generic;
using System.Linq;
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
        Dictionary<int, string> dict = new Dictionary<int, string>();

        public RomanNumerals()
        {
            dict.Add(1, "I");
            dict.Add(5, "V");
            dict.Add(10, "X");
            dict.Add(50, "L");
            dict.Add(100, "C");
            dict.Add(500, "D");
            dict.Add(1000, "M");
        }

        public void ConvertToRoman(int A)
        {
            if (A < 1) Console.WriteLine();

            int pointer = dict.Count - 1;
            LinkedList<string> numeral = new LinkedList<string>();
            StringBuilder sb = new StringBuilder();

            while (pointer >= 0 && A > 0)
            {
                int key = dict.Keys.ElementAt(pointer);

                if (dict.ContainsKey(A))
                {
                    sb.Append(dict[A]);
                    break;
                }
                else if (dict.ContainsKey(key - A))
                {
                    sb.Append(dict[key - A]);
                    sb.Append(dict[key]);
                    break;
                }
                else if (key < A)
                {
                    sb.Append(dict[key]);
                    A = A - key;
                }
                else
                {
                    pointer--;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
