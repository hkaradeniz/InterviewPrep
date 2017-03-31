using System;

namespace InterviewPrep
{
    class ReverseWords
    {
        public String SolveReverseWords(String str)
        {
            // Split String and place it in a string array
            String[] splitted = str.Split(' ');
            String newStr = "";

            // Go through each word and reserve them 
            for (int i = 0; i < splitted.Length; i++)
            {
                String temp = splitted[i];

                // Get the word and reverse it
                // and assign it to newStr variable
                for (int j = temp.Length - 1; j >= 0; j--)
                {
                    newStr += temp[j];
                }

                // Leave a space in between words!
                newStr += " ";
            }

            return newStr;
        }

    }
}
