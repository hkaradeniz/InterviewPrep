using System;
using System.Text;

namespace InterviewPrep.Amazon
{
    /* Column name from a given column number */
    /* Given a positive integer, return its corresponding column title as appear in an Excel sheet.
     * MS Excel columns has a pattern like A, B, C, … ,Z, AA, AB, AC,…. ,AZ, BA, BB, … ZZ, AAA, AAB ….. etc. 
     * In other words, column 1 is named as “A”, column 2 as “B”, column 27 as “AA”. */
    /* https://practice.geeksforgeeks.org/problems/column-name-from-a-given-column-number/0 */
    class ExcelColumnName
    {
        private static int ALPHABET_SIZE = 26;

        // 1 ≤ N ≤ 4294967295
        public void PrintColumnName(int n)
        {
            // ASCII A = 65
            // ASCII Z = 90;

            int numberOfLeadingA = n / ALPHABET_SIZE;
            int actualCharIndex = n % ALPHABET_SIZE;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numberOfLeadingA; i++)
            {
                sb.Append("A");
            }

            sb.Append((char)(actualCharIndex + 64));

            Console.WriteLine($"Column Name: { sb.ToString() }");
            
        }
    }
}
