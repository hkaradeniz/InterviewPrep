using System;
using System.Text;

namespace InterviewPrep.Contest
{
    // Decrypt Message
    // Solve the Decrypted Message
    /*
     * All chars lowercase (between 97-122 ASCII - 26 Chars)
     Here is how they drypt the message
     (crime) 
     1- Get ASCII values of the chars
     c      r      i       m      e
    99    114    105    109     101
    
     2- Add +1 to the first number and add previous value of previous letter
         c      r      i       m      e
        100    214    319    428     529

    
     3- Subtract 26 until the value of letter falls into a-z
      c      r      i       m      e
     100    110    111    116     113

     Message
     d  n o  t  q
        */
    class DecryptMessage
    {
        public void Decrypt(string message)
        {
            int previous = message[0];
            StringBuilder sb = new StringBuilder();

            sb.Append((char)(previous - 1));

            for (int i = 1; i < message.Length; i++)
            {
                int letter = message[i] - previous;

                if (letter < 97 || letter > 122)
                    letter = GetActualValue(letter);

                previous += letter;

                sb.Append((char)letter);
            }

            Console.WriteLine(sb.ToString());    
        }

        private int GetActualValue(int value)
        {
            while (value < 97)
                value += 26;

            return value;
        }
    }
}
