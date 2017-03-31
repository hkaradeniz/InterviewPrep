using System;

namespace InterviewPrep.DesignPatterns
{

    /// <summary>
    /// Behavioral Pattern
    /// </summary>
    ///

    enum Screen
    {
        Windows,
        Mobile
    }

    abstract class Strategy
    {
        public abstract void ProduceScreen();
    }

    class WindowsScreen
        : Strategy
    {
        public override void ProduceScreen()
        {
            Console.WriteLine("Windows Screen has been produced!");
        }
    }

    class MobileScreen
      : Strategy
    {
        public override void ProduceScreen()
        {
            Console.WriteLine("Mobile Screen has been produced!"); ;
        }
    }

    class Context
    {
        private Strategy strategy;
         
        public Context(Strategy newStrategy)
        {
            strategy = newStrategy; 
        }

        public void Produce()
        {
            strategy.ProduceScreen();
        }
    }
}

/*
            Context context;

            // Three contexts following different strategies
            context = new Context(new MobileScreen());
            context.Produce();


            context = new Context(new WindowsScreen());
            context.Produce();

    STRATEGY PATTERN:

    Behavioral Pattern

    In Strategy pattern, we create objects which represent various strategies and a context object 
    whose behavior varies as per its strategy object. The strategy object changes the executing 
    algorithm of the context object.

    Pros and Cons:
    + Prevents the conditional statements.
    + The algorithms and behaviors can be reused.
    + The algorithms are loosely coupled with the context entity. 
    They can be changed/replaced without changing the context entity.
    - Client must be aware of the various strategies, thus helping him decide the best strategy.
    - It increases the number of objects in the application.

 */
