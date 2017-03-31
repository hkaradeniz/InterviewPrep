using System;
using System.Collections.Generic;

namespace InterviewPrep.DesignPatterns
{
    /// <summary>
    /// Behavioral Pattern
    /// </summary>
    /// 

    class Observer
    {
    }

    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    interface IInvestor
    {
        void Update(Stock stock);
    }

    abstract class Stock
    {
        private string _symbol;
        private double _price;

        private List<IInvestor> _invenstors = new List<IInvestor>();


        public Stock(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;
        }

        public void Attach(IInvestor investor)
        {
            _invenstors.Add(investor);
        }

        public void DeAttach(IInvestor investor)
        {
            _invenstors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in _invenstors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }

        // Gets or sets the price
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify(); // Observer...
                }
            }
        }

        // Gets the symbol
        public string Symbol
        {
            get { return _symbol; }
        }
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class Investor : IInvestor
    {
        private string _name;
        private Stock _stock;

        public Investor(string name)
        {
            this._name = name;
        }

        #region IInvestor Members

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", _name, stock.Symbol, stock.Price);
        }

        #endregion

        public Stock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }

    class IBM : Stock
    {
        public IBM(string symbol, double price)
            : base(symbol, price)
        { }
    }
}

/*
            IBM ibm = new IBM("IBM", 120.00);

            ibm.Attach(new Investor("John"));
            ibm.Attach(new Investor("Alex"));
            ibm.Attach(new Investor("Huseyin"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;
 */
