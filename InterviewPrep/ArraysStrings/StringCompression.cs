using System.Text;

namespace InterviewPrep.ArraysStrings
{
    class StringCompression
    {
        /*? Cracking the Coding Interview, 6th Edition
            String Compression: Implement a method to perform basic string compression using the counts
            of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
            "compressed" string would not become smaller than the original string, your method should return
            the original string. You can assume the string has only uppercase and lowercase letters (a - z).
       */

        public string CompressString(string s)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(s))
            {
                // Test: aabcccccaaa a2blc5a3
                char previous = s[0];
                int counter = 1;
                sb.Append(previous);

                for (int i = 1; i < s.Length; ++i)
                {
                    char current = s[i];

                    if (current == previous)
                    {
                        counter++;
                    }
                    else
                    {
                        previous = current;
                        sb.Append(counter);
                        sb.Append(current);
                        counter = 1;
                    }
                }

                sb.Append(counter);
            }

            string newStr = sb.ToString();

            return newStr.Length < s.Length ? newStr : s;
        }

        public string Compress(string s)
        {
            StringBuilder sb = new StringBuilder();

            int pointer = 0;
            int scanner = 1;
            int counter = 0;

            while (pointer < s.Length)
            {
                char c = s[pointer];
                sb.Append(c);
                counter = 1;

                scanner = pointer + 1;
                while (scanner < s.Length)
                {
                    if (c == s[scanner])
                    {
                        counter++;
                        scanner++;
                    }
                    else
                        break;
                }

                sb.Append(counter);
                pointer = scanner;

            }

            return sb.ToString();
        }
    }
}
