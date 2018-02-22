using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Amazon
{
    /*
     There are N number of possible drinks.(n1,n2..)
        Has C number of fixed customers.
        Every customer has fixed favorite set of drinks.
        Bartender has to create least possible number of drinks to suffice need of all the customers
        Example:

        Cust1: n3,n7,n5,n2,n9  
        Cust2: n5  
        Cust3: n2,n3  
        Cust4: n4  
        Cust5: n3,n4,n3,n5,n7,n4    

        Output: 3(n3,n4,n5)  
     */
    
      /*
            Cust1: n3,n7,n5,n2,n9
               Cust2: n5
               Cust3: n2,n3
               Cust4: n4
               Cust5: n3,n4,n3,n5,n7,n4
            */
            /*
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
        */
    class LazyBartender
    {
        public void GetMinNumberOfDrinks(List<Customer> list)
        {
            if (list == null || list.Count == 0) return;

            BipartiteGraph graph = new BipartiteGraph();
            // Create bipatite graph
            foreach (var customer in list)
            {
                List<Drink> drinks = customer.Drinks;

                HashSet<string> temp = new HashSet<string>();
                foreach (var drink in drinks)
                {
                    if (!temp.Contains(drink.DrinkName))
                    {
                        // Update DrinkCounts
                        if (graph.DrinkCounts.ContainsKey(drink.DrinkName))
                            graph.DrinkCounts[drink.DrinkName]++;
                        else
                            graph.DrinkCounts.Add(drink.DrinkName, 1);

                        // Update DrinksCustomers
                        if (graph.DrinksCustomers.ContainsKey(drink.DrinkName))
                            graph.DrinksCustomers[drink.DrinkName].Add(customer.CustomerNumber);
                        else
                            graph.DrinksCustomers.Add(drink.DrinkName, new List<int>() { customer.CustomerNumber });
                    }

                    temp.Add(drink.DrinkName);
                }

                // Update distinct customers
                if (!graph.Customers.Contains(customer.CustomerNumber))
                    graph.Customers.Add(customer.CustomerNumber);
            }

            
        }

        private string GetMostCommonDrink(Dictionary<string, int> dict)
        {
            int max = -1;
            string drink = string.Empty;

            foreach (var item in dict)
            {
                if (item.Value > max)
                {
                    drink = item.Key;
                    max = item.Value;
                }
            }

            dict.Remove(drink);
            return drink;
        }
    }

    class BipartiteGraph
    {
        public Dictionary<string, int> DrinkCounts = new Dictionary<string, int>();
        public Dictionary<string, List<int>> DrinksCustomers = new Dictionary<string, List<int>>();
        public HashSet<int> Customers = new HashSet<int>();
    }

    class Customer
    {
        public int CustomerNumber { get; }
        public List<Drink> Drinks { get; }

        public Customer(int num)
        {
            CustomerNumber = num;
            Drinks = new List<Drink>();
        }

        public void AddDrink(string name)
        {
            Drinks.Add(new Drink(name));
        }
    }

    class Drink
    {
        public string DrinkName { get; }

        public Drink(string val)
        {
            DrinkName = val;
        }
    }
}
