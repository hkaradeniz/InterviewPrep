using System;
using System.Collections.Generic;
using System.Linq;

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

        public void ConvertToRoman(int number)
        {
            if (number < 1) Console.WriteLine();

            int pointer = dict.Count - 1;
            LinkedList<string> numeral = new LinkedList<string>();
            bool prepend = false;

            while (pointer >= 0 && number > 0)
            {
                int key = dict.Keys.ElementAt(pointer);

                if (dict.ContainsKey(number))
                {
                    if (prepend)
                        numeral.AddFirst(dict[number]);
                    else
                        numeral.AddLast(dict[number]);

                    break;
                }
                else if (numeral.Count == 0 && dict.ContainsKey(key - number))
                { numeral.AddFirst(dict[key]); prepend = true; number = key - number; }
                else if (key < number)
                {
                    numeral.AddLast(dict[key]);
                    number -= key;
                }
                else
                {
                    pointer--;
                }     
            }

            foreach (var item in numeral)
            {
                Console.Write($"{item}");
            }
        }
    }
}
