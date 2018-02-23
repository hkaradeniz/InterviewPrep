namespace InterviewPrep.Amazon
{
    class CharOccuringOddNumberOfTimes
    {
        // Char odd number of times
        public char FindChar(string str)
        {
            if (string.IsNullOrEmpty(str)) return '\0';

            int result = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                result ^= str[i];
            }

            return (char)result;
        }
    }
}
