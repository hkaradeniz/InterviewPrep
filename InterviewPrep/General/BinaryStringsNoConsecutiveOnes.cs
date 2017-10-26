namespace InterviewPrep.General
{
    class BinaryStringsNoConsecutiveOnes
    {
        /* Binary Strings with no Consecutive Ones */
        /*  */
        public int ComputeBinaryStringsNoConsecutiveOnes(int N)
        {
            if (N < 1) return 0;

            int c0 = 1; // Number of binary strings ending with 0 (N=1) 
            int c1 = 1; // Number of binary strings ending with 1 (N=1)

            for (int i = 1; i < N; i++)
            {
                int temp = c1;
                c1 = c0;
                c0 += temp;
            }

            return c0 + c1;
        }

        /*
         Ex:
                        N=1             N=2             N=3              N=4
         Ends with 0:   0             00, 10        000, 100, 010       0000, 1000, 0100, 0010, 1010
         Ends with 1:   1               01            001, 101             0001, 1001, 0101, 
         */
    }
}
