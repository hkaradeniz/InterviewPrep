using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    class Program
    {
        // Top 10 algorithms in Interview Questions
        //! http://www.geeksforgeeks.org/top-10-algorithms-in-interview-questions/

        static void Main(string[] args)
        {
            int[] arr1 = new int[2];
            int[] arr2 = new int[3];
            arr1[0] = 1;
            arr1[1] = 2;
            arr2[0] = 3;
            arr2[1] = 4;
            arr2[2] = 5;
            arr1 = arr2;
            foreach (var item in arr1)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }


        // Pretty Up your Code Comments with Better Comments
        //! https://channel9.msdn.com/coding4fun/blog/Pretty-Up-your-Code-Comments-with-Better-Comments

        // Better Comments Extension --> Nothing Special
        //! You should read this. It's important... -> Important
        //? Is this enough? Or should I write more... -> Question
        //x This code should not be here... -> Crossed
        //// This code should not be here... -> Crossed
        //TODO: Just do your job... -> Task

        /* C# multi-line 
           Normal comment */

        /*! C# multi-line 
          Important comment */

        /*? C# multi-line 
          Question comment */

        /*TODO C# multi-line 
          Task comment */
    }
}
