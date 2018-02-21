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
            /*
             Cust1: n3,n7,n5,n2,n9
                Cust2: n5
                Cust3: n2,n3
                Cust4: n4
                Cust5: n3,n4,n3,n5,n7,n4
             */
            List<Amazon.Customer> list = new List<Amazon.Customer>();
            Amazon.Customer cust1 = new Amazon.Customer(1);
            cust1.AddDrink("n3");
            cust1.AddDrink("n7");
            cust1.AddDrink("n5");
            cust1.AddDrink("n2");
            cust1.AddDrink("n9");
            Amazon.Customer cust2 = new Amazon.Customer(2);
            cust2.AddDrink("n5");
            Amazon.Customer cust3 = new Amazon.Customer(3);
            cust3.AddDrink("n2");
            cust3.AddDrink("n3");
            Amazon.Customer cust4 = new Amazon.Customer(4);
            cust4.AddDrink("n4");
            Amazon.Customer cust5 = new Amazon.Customer(5);
            cust5.AddDrink("n3");
            cust5.AddDrink("n4");
            cust5.AddDrink("n3");
            cust5.AddDrink("n5");
            cust5.AddDrink("n7");
            cust5.AddDrink("n4");
            list.Add(cust1);
            list.Add(cust2);
            list.Add(cust3);
            list.Add(cust4);
            list.Add(cust5);

            Amazon.LazyBartender lz = new Amazon.LazyBartender();
            lz.GetMinNumberOfDrinks(list);
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
