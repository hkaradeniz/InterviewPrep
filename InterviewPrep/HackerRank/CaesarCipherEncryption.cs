using System.Text;

namespace InterviewPrep.HackerRank
{
    /*
     * https://www.hackerrank.com/challenges/linkedin-practice-caesar-cipher/problem
     Julius Caesar protected his confidential information by encrypting it in a cipher. 
     Caesar's cipher rotated every letter in a string by a fixed number, K, making it unreadable by 
     his enemies. Given a string, S, and a number, K, encrypt S and print the resulting string.

        Input:
        11
        middle-Outz
        2

        Output
        okffng-Qwvb



 m (ASCII 109) becomes o (ASCII 111). 
 i (ASCII 105) becomes k (ASCII 107). 
 - remains the same, as symbols are not encoded. 
 O (ASCII 79) becomes Q (ASCII 81). 
 z (ASCII 122) becomes b (ASCII 98); because z is the last letter of the alphabet, a (ASCII 97) is the 
    next letter after it in lower-case rotation.
     */
    class CaesarCipherEncryption
    {
        public string Encrypt(string s, int n, int k)
        {
            StringBuilder sb = new StringBuilder();

            if (k >= 26) k = k % 26;

            for (int i = 0; i < n; i++)
            {
                sb.Append(GetNextChar(s[i], k));
            }

            return sb.ToString();
        }

        private char GetNextChar(int c, int k)
        {
            if (c >= 65 && c <= 90)
            {
                c += k;
                if (c > 90) c = 64 + (c % 90);
            }
            else if (c >= 97 && c <= 122)
            {
                c += k;
                if (c > 122) c = 96 + (c % 122);
            }

            return (char)c;
        }
    }
}
