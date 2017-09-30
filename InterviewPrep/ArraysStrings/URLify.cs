using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.ArraysStrings
{
    class URLify
    {
        /*
        Cracking the Coding Interview, 6th Edition
        URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        has sufficient space at the end to hold the additional characters, and that you are given the "true"
        length of the string. (Note: If implementing in Java, please use a character array so that you can
        perform this operation in place.)
        EXAMPLE
        Input: "Mr John Smith ", 13
        Output: "Mr%20John%20Smith"
        */

        // Test data
        // ArraysStrings.URLify u = new ArraysStrings.URLify();
        // u.ReplaceSpaces(new char[] { 'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', ' ', ' ', ' ', ' ' }, 13);
        public void ReplaceSpaces(char[] str, int length)
        {
            int spaceCount = 0;
            int newLength = 0;

            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                    spaceCount++;
            }

            newLength = length + spaceCount * 2;

            // length is the true length of the string
            //Input: "Mr John Smith    ", 13
            //Output: "Mr%20John%20Smith"
            /*
              Length of "Mr John Smith" = 13 (This is the actual length of the string without leading spaces)
              Number of spaces in this string is 2. For each space 3 char space. The space will be ' '=>'%20'
              Since the original string with the length of 13 already counts the spaces, we add spacecount*2
                to get the length of new string
              We start getting elements from index length and place them into newLength index.   
              */
            for (int i = length-1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[newLength - 1] = '0';
                    str[newLength - 2] = '2';
                    str[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else
                {
                    str[newLength - 1] = str[i];
                    newLength--;
                }
            }

            Console.WriteLine(str.ToString());
        }
    }
}
