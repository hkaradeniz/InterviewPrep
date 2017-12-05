namespace InterviewPrep.DesignPatterns
{
    /// <summary>
    /// Singleton Pattern
    /// Creational Pattern
    /// </summary>
    /// 

    class Singleton
    {
        private static Singleton instance;

        // Construction method is protected. Cannot use new
        protected Singleton()
        { }

        // Uses lazy initialization.
        // Note: this is not thread safe.
        public static Singleton GetInstance()
        {
            if (instance == null)
               instance = new Singleton();

            return instance;
        }
    }
}

/*
             // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance!");
            }

 SINGLETON PATTERN:

    Creational Pattern

    This pattern involves a single class which is responsible to create an object while making 
    sure that only single object gets created. This class provides a way to access its only 
    object which can be accessed directly without need to instantiate the object of the class.

    Pros and Cons:
    - They violate the single responsibility principle: by virtue of the fact that they control 
    their own creation and life-cycle.
    -They are generally used as a global instance, why is that so bad? Because you hide the 
    dependencies of your application in your code, instead of exposing them through the 
    interfaces. Making something global to avoid passing it around is a code smell.

*/
