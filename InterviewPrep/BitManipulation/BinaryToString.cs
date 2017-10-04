using System.Text;

namespace InterviewPrep.BitManipulation
{
    /*?
    * Cracking the Coding Interview, 6th Edition
    * Binary to String: Given a real number between 0 and 1 (e.g., 0.72) that is passed in as a double,
        print the binary representation. If the number cannot be represented accurately in binary with at
        most 32 characters, print"ERROR:"

        Example & Explanation
        We will illustrate the method by converting the decimal value .625 to a binary representation..

        Step 1: Begin with the decimal fraction and multiply by 2. The whole number part of the result is 
        the first binary digit to the right of the point.
        Because .625 x 2 = 1.25, the first binary digit to the right of the point is a 1.
        So far, we have .625 = .1??? . . . (base 2) .


        Step 2: Next we disregard the whole number part of the previous result (the 1 in this case) and multiply by 2 once again. 
        The whole number part of this new result is the second binary digit to the right of the point. 
        We will continue this process until we get a zero as our decimal part or until we recognize an infinite repeating pattern.
        Because .25 x 2 = 0.50, the second binary digit to the right of the point is a 0.
        So far, we have .625 = .10?? . . . (base 2) .


        Step 3: Disregarding the whole number part of the previous result (this result was .50 so there actually 
        is no whole number part to disregard in this case), we multiply by 2 once again. The whole number part 
        of the result is now the next binary digit to the right of the point.
        Because .50 x 2 = 1.00, the third binary digit to the right of the point is a 1.
        So now we have .625 = .101?? . . . (base 2) .


        Step 4: In fact, we do not need a Step 4. We are finished in Step 3, because we had 0 as 
        the fractional part of our result there.

        Hence the representation of .625 = .101 (base 2) .

        Test
        BitManipulation.BinaryToString bs = new BitManipulation.BinaryToString();
        Console.WriteLine(bs.PrintBinary(0.625));

    */
    class BinaryToString
    {
        public string PrintBinary(double num)
        {
            // The real number must be between 0 and 1
            if (num >= 1 || num <= 0)
                return "ERROR";

            StringBuilder sb = new StringBuilder();
            sb.Append(".");

            while (num > 0)
            {
                if (sb.Length >= 32)
                    return "ERROR";

                num = num * 2;
                if (num >= 1)
                {
                    sb.Append("1");
                    num--;
                }
                else
                {
                    sb.Append("0");
                }
            }

            return sb.ToString();
        }
    }
}
