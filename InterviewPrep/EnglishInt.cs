using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewPrep
{
    /*? Cracking the Coding Interview, 6th Edition
    English Int: Given any integer, print an English phrase that describes the integer (e.g., "One Thousand,
    Two Hundred Thirty Four").
    */
    class EnglishInt
    {
        Dictionary<int, string> dict = new Dictionary<int, string>();

        public EnglishInt()
        {
            dict.Add(0, "");
            dict.Add(1, "One");
            dict.Add(2, "Two");
            dict.Add(3, "Three");
            dict.Add(4, "Four");
            dict.Add(5, "Five");
            dict.Add(6, "Six");
            dict.Add(7, "Seven");
            dict.Add(8, "Eight");
            dict.Add(9, "Nine");
            dict.Add(10, "Ten");
            dict.Add(11, "Eleven");
            dict.Add(12, "Twelve");
            dict.Add(13, "Thirteen");
            dict.Add(14, "Fourteen");
            dict.Add(15, "Fifteen");
            dict.Add(16, "Sixteen");
            dict.Add(17, "Seventeen");
            dict.Add(18, "Eighteen");
            dict.Add(19, "Nineteen");

            dict.Add(20, "Tweenty");
            dict.Add(30, "Thirty");
            dict.Add(40, "Forty");
            dict.Add(50, "Fifty");
            dict.Add(60, "Sixty");
            dict.Add(70, "Seventy");
            dict.Add(80, "Eighty");
            dict.Add(90, "Ninety");
        }
        
        public void PrintIntegerPhase(int n)
        {
            Console.WriteLine(n);

            StringBuilder sb = new StringBuilder();
            Stack<int> stack = new Stack<int>();

            while (n > 0)
            {
                int division = n % 10;
                n = n / 10;
                stack.Push(division);
            }

            int count = stack.Count;
            while (count > 0)
            {
                switch (count)
                {
                    case 4:
                        if(stack.Peek() > 0)
                        sb.Append($"{dict[stack.Pop()]} Thousand, ");
                        break;
                    case 3:
                        if (stack.Peek() > 0)
                        sb.Append($"{dict[stack.Pop()]} Hundred ");
                        break;
                    case 2:
                        if (stack.Peek() <= 1)
                        {
                            // Its between 0-19 
                            sb.Append($"{dict[stack.Pop()]} ");
                        }
                        else
                        {
                            // Its between 20-99
                            sb.Append($"{dict[stack.Pop() * 10]} ");
                            sb.Append($"{dict[stack.Pop()]} ");
                        }
                        break;
                    default:
                        break;
                }

                count--;
            }

            Console.WriteLine(sb.ToString());
        }

       
    }
}
