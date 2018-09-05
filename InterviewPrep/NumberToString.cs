namespace InterviewPrep
{
    class NumberToString
    {
        private static string[] digits = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        private static string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
            "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        private static string[] tens = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static string[] bigs = { "", "Thousand", "Million", "Billion" };

        public static string IntToString(int n)
        {
            if (n == 0) return "Zero";
            if (n < 0) return "Negative " + IntToString(n * -1);
            string ret = "";
            int i = 0;
            while (n > 0)
            {
                string hundredSegment = ConvertHundred(n % 1000);
                if (!string.IsNullOrEmpty(hundredSegment))
                {
                    ret = hundredSegment + bigs[i] + " " + ret;
                }
                n /= 1000;
                ++i;
            }
            return ret.Trim();
        }

        private static string ConvertHundred(int n)
        {
            string ret = "";
            if (n >= 100)
            {
                ret += digits[n / 100 - 1] + " Hundred ";
                n %= 100;
            }
            if (n >= 20)
            {
                ret += tens[n / 10 - 2] + " ";
                n %= 10;
            }
            if (n >= 10)
            {
                ret += teens[n % 10] + " ";
                n = 0;
            }
            if (n > 0)
            {
                ret += digits[n - 1] + " ";
            }
            return ret;
        }
    }
}
