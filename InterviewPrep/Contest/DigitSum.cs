namespace InterviewPrep.Contest
{
    // The Digit Sum of a Number to Base 10 is Equivalent to Its Remainder Upon Division by 9
    // http://applet-magic.com/digitsummod9.htm
    /*
    digit_sum(9875) = digit_sum(9+8+7+5) 
                  = digit_sum(29) 
                  = digit_sum(2+9)
                  = digit_sum(11)
                  = digit_sum(1+1)
                  = digit_sum(2)
                  = 2.
    
     You are given n and k 
     n = 123 k = 3     p= 123123123
     */
    class DigitSum
    {
        public int CalculateDigitSum(string n, int k)
        {
            if (k == 0) return 0;

            int pointer = 0;
            int temp = 0;
            while (pointer < n.Length)
            {
                temp += (n[pointer] - '0') % 9;
                pointer++;
            }

            int total = (temp + CalculateDigitSum(temp.ToString(), k - 1)) % 9;

            return total == 0 ? 9 : total;
        }
    }
}
