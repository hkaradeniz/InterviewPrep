using System.Text;

namespace InterviewPrep.Amazon
{
    /* Remove all consecutive characters in a string. bottom -> boom-> bm (return "bm")   */
    class RemoveConsecutiveCharacters
    {
        public string Remove(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;

            int pointer = 0;
            StringBuilder sb = new StringBuilder();
            int scanner = 0;

            while (pointer < str.Length)
            {
                char c = str[pointer];

                scanner = pointer + 1;

                while (scanner < str.Length)
                {
                    if (c == str[scanner])
                    {
                        scanner++;
                    }
                    else
                        break;
                }

                if (pointer + 1 == scanner)
                    sb.Append(c);

                pointer = scanner;
            }

            return sb.ToString();
        }

    }
}
