using System;

namespace InterviewPrep.StringSearch
{
    // http://www.geeksforgeeks.org/searching-for-patterns-set-3-rabin-karp-algorithm/

    /*
        Complexity:
        The average and best case running time of the Rabin-Karp algorithm is O(n+m), 
        but its worst-case time is O(nm). Worst case of Rabin-Karp algorithm occurs 
        when all characters of pattern and text are same as the hash values of all 
        the substrings of txt[] match with hash value of pat[]. 
        For example pat[] = “AAA” and txt[] = “AAAAAAA”.
    */
    class RabinKarp
    {
        // A random prime number to calculate the hash value
        private static int q = 11;

        // Number of charcters in Extended-Ascii Table
        private static int d = 256;

        public void Search(string txt, string pat)
        {
            char[] text = txt.ToCharArray();
            char[] pattern = pat.ToCharArray();

            // Length of the text array
            int n = text.Length;

            // Length of the pattern array
            int m = pattern.Length;

            int p = 0; // Hash value of pattern
            int t = 0; // Hash value of text
            int h = 1; // The hash value

            // The value of h would be "pow(d, M-1)%q"
            for (int i = 0; i < m - 1; i++)
                h = (h * d) % q;

            // Calculate the hash value of the pattern and the first window of the text
            for (int i = 0; i < m; i++)
            {
                p = (d * p + pattern[i]) % q;
                t = (d * t + text[i]) % q;
            }
            /*
             EX: Text= "ABDCB"
               Pattern= "CD"
               q=11; m=2; n=5;
               h = (1*256) % 11 = 3;

               Iteration 1:
                   p = (256 * 0 + 68) % 11 = 2;
                   t = (256 * 0 + 65) % 11 = 10;

               Iteration 2:
                   p = (256 * 2 + 67) % 11 = 7;
                   t = (256 * 10 + 66) % 11 = 8;

             // Since m=2 we stop here and see if the pattern occurs in the text
           */

            // Slide the pattern over the text one by one
            for (int i = 0; i < n-m; i++)
            {

                // Check the hash values of current window of text
                // and pattern. If the hash values match then only
                // check for characters 

                if (p == t)
                {
                    bool match = true;

                    // If hashes match check the charcters
                    for (int j = 0; j < m; j++)
                    {
                        if (text[i + j] != pattern[j])
                        {
                            match = false;
                            break;
                        }
                    }

                    // if p == t and pat[0...m-1] = txt[i, i+1, ...i+m-1]
                    if (match)
                        Console.WriteLine("Match found at index: " +i);
                }

                // Calculate hash value for next window of text: Remove
                // leading digit, add trailing digit
                if (i < n - m)
                {
                    t = (d * (t - text[i] * h) + text[i + m]) % q;

                    // We might get negative value of t, converting it
                    // to positive
                    if (t < 0)
                        t = (t + q);
                }

            }

        }
    }
}
