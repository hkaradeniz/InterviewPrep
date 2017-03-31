namespace InterviewPrep.DesignPatterns
{
    /// <summary>
    /// Creational Pattern
    /// </summary>
    /// 

    class Prototype
    {
    }

    abstract class AbstractPrototype
    {
        private string _id;

        public AbstractPrototype(string id)
        {
            this._id = id;
        }

        public string Id
        {
            get { return _id; }
        }

        public abstract AbstractPrototype Clone();
    }

    class ConcretePrototype1 : AbstractPrototype
    {
        public ConcretePrototype1(string id)
            : base(id)
        { }

        // Returns a shallow copy
        public override AbstractPrototype Clone()
        {
            return (AbstractPrototype)this.MemberwiseClone();
        }
    }

    class ConcretePrototype2 : AbstractPrototype
    {
        public ConcretePrototype2(string id)
            : base(id)
        { }

        // Returns a shallow copy
        public override AbstractPrototype Clone()
        {
            return (AbstractPrototype)this.MemberwiseClone();
        }
    }
}

/*
            // Create two instances and clone each
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();

            Console.WriteLine("Cloned: {0}", c1.Id);

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id); 
 */
