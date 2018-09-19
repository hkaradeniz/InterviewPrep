using System;

namespace InterviewPrep
{
    /*
        Michelle has created a word game for her students. The word game begins with Michelle 
        writing a string and a number, K, on the board. The students have to find the substrings 
        of size K with K distinct characters.

        Write an algorithm to help the students find the correct answer.
     */
    class SizeKWithKDistinctCharacters
    {
        public void FindSubstrings(string str, int k)
        {
            if (string.IsNullOrEmpty(str)) return;
            int n = str.Length;

            if (n < k) return;

            int head = 0;
            int tail = k;

            string substring = str.Substring(0, k);

            int[] countArr = new int[26];
            int numberOfDistinctChars = 0;

            for (int i = 0; i < k; i++)
            {
                if (countArr[str[i] - 'a'] == 0)
                    numberOfDistinctChars++;

                countArr[str[i] - 'a']++;
            }

            Print(str, head, tail, numberOfDistinctChars, k);

            while (tail < n)
            {

                if (countArr[str[head] - 'a'] == 1)
                    numberOfDistinctChars--;

                countArr[str[head] - 'a']--;

                if (countArr[str[tail] - 'a'] == 0)
                    numberOfDistinctChars++;

                countArr[str[tail] - 'a']++;

                Print(str, head + 1, tail, numberOfDistinctChars, k);

                head++;
                tail++;
            }
        }

        private void Print(string str, int head, int tail, int numberOfDistinctChars, int k)
        {
            Console.WriteLine($"Head: {head} ** Tail: {tail}");
            Console.WriteLine($"Head: {str[head]} ** Tail: {str[tail]}");

            if (numberOfDistinctChars == k) Console.WriteLine("VALID:" + str.Substring(head, k));
            else Console.WriteLine("NOT VALID:" + str.Substring(head, k));
        }
    }
}
