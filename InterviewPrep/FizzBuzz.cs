using System;

namespace InterviewPrep
{
    class FizzBuzz
    {
        public void PrintFizzBuzz(int num)
        {
            for (int i = 1; i < num; i++)
            {
                var output = "";

                if (i % 3 == 0) output = "Fizz";
                if (i % 5 == 0) output += "Buzz";

                if(String.IsNullOrEmpty(output))
                    Console.WriteLine(i);
                else
                    Console.WriteLine(output);
                
            }
        }
    }
}
