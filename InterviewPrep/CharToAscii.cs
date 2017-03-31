using System;

namespace InterviewPrep
{
    class CharToAscii
    {
        public void charAscii()
        {
            string text = "Huseyin7";

            for (int i = 0; i < text.Length; i++)
            {
                int asciivalue = (char)text[i];
                Console.WriteLine("> {0}", asciivalue);
            }
        }
    }
}
