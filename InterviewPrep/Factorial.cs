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
    }
}
