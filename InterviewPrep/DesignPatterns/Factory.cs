namespace InterviewPrep.DesignPatterns
{
    /// <summary>
    /// Factory Method
    /// Creational Patterns
    /// </summary>
    /// 
    class Factory
    {

    }

    enum Employee
    {
        Manager,
        Director,
        Developer,
        Default
    }

    abstract class Position
    {
        public abstract string Title { get; }
    }

    class Manager
        : Position
    {
        public override string Title
        {
            get
            {
                return "Manager"; 
            }
        }
    }

    class Director
       : Position
    {
        public override string Title
        {
            get
            {
                return "Director";
            }
        }
    }

    class Developer
       : Position
    {
        public override string Title
        {
            get
            {
                return "Developer";
            }
        }
    }

    class Default
      : Position
    {
        public override string Title
        {
            get
            {
                return "Default";
            }
        }
    }

    class EmployeeFactory
    {
        public Position GetTitle(Employee employee)
        {
            switch (employee)
            {
                case Employee.Manager:
                    return new Manager();
                case Employee.Director:
                    return new Director();
                case Employee.Developer:
                    return new Developer();
                default:
                    return new Default();
            }
        }
    }

}

/*
 * 
    static void Main(string[] args)
    {
        Position newPosition = EmployeeFactory.GetTitle(Employee.Director);
        Console.WriteLine(newPosition.Title);
    }
    
    FACTORY PATTERN:

    Creational Pattern

    Creates objects without exposing the creation of a real instance logic to the client.

    Pros and Cons:
    + Allows you to hide implementation of the core interfaces that make up your application
    + Allows you to change the design of your application more readily (loose coupling)
    - Makes code more difficult to read as all of your code is behind an abstraction 
    that may in turn hide abstractions.

 */

