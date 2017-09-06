namespace InterviewPrep
{
    class Factorial
    {
        public int FactorialIterative(int num)
        {
            int result = 1;

            for (int i = num; i > 0; --i)
            {
                result *= num;
            }

            return result;
        }

        public int FactorialRecursive(int num)
        {
            return num == 0 ? 1 : num * FactorialRecursive(num - 1);
        }

        // Factorial Tail Recursion
        public int FactorialTailRecursion(int num)
        {
            return FactorialTailRecursionHelper(num, 1); 
        }

        private int FactorialTailRecursionHelper(int num, int result)
        {
            if (num == 0) return 1;
            return FactorialTailRecursionHelper(num - 1, num * result);
        }

    }

}
