namespace InterviewPrep
{
    class MinimumWindowSubstring
    {
        /*
            Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

            Example:

            Input: S = "ADOBECODEBANC", T = "ABC"
            Output: "BANC"
            Note:

            If there is no such window in S that covers all characters in T, return the empty string "".
            If there is such window, you are guaranteed that there will always be only one unique minimum window in S.
         */
        public string ReturnMinWindow(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return string.Empty;

            int size = pattern.Length;
            int[] charCount = new int[128];
            bool[] charSet = new bool[128];

            for (int i = 0; i < size; ++i)
            {
                charCount[pattern[i]]++;
                charSet[pattern[i]] = true;
            }

            int tail = -1;
            int head = 0;

            int minLength = int.MaxValue;
            int minIndex = 0;

            while (tail < input.Length && head < input.Length)
            {
                //Console.WriteLine($"Head: {head} ** Tail: {tail} ** Size: {size}");
                if (size != 0)
                {
                    tail++;

                    if (tail == input.Length) break;

                    charCount[input[tail]]--;

                    if (charSet[input[tail]] && charCount[input[tail]] >= 0) size--;
                }
                else
                {
                    if (minLength > tail - head + 1)
                    {
                        minLength = tail - head + 1;
                        minIndex = head;
                    }

                    charCount[input[head]]++;

                    if (charSet[input[head]] && charCount[input[head]] > 0) size++;

                    head++;
                }
            }
            if (minLength == int.MaxValue) return string.Empty;

            return input.Substring(minIndex, minLength);
        }
    }
}
