using System;
using System.Collections.Generic;
using InterviewPrep.Sorting;

namespace InterviewPrep
{
    class Program
    {
        // Top 10 algorithms in Interview Questions
        //! http://www.geeksforgeeks.org/top-10-algorithms-in-interview-questions/

        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(5);
            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);

            Console.WriteLine("Following are strongly connected components in given graph");
            g.StronglyConnectedComponents();
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
