using System.Collections.Generic;
using System.Linq;

namespace InterviewPrep.Amazon
{
    class ObjectOrientedDesign
    {
    }

    public class Company
    {
        private EmployeeGraph graph = new EmployeeGraph();

        public LinkedList<Staff> DirectReports(short id)
        {
            return graph.GetDirectReports(id);
        }

        public void AddDirectReports(Staff newEmployee)
        {
            graph.AddStaff(newEmployee);
        }

    }

    #region Employee
    public abstract class Staff
    {
        private short id;
        private short managerId;
        private string name;
        public abstract string Title { get; }

        public Staff(string stuffName, short stuffId, short stuffManagerId)
        {
            name = stuffName;
            id = stuffId;
            managerId = stuffManagerId;
        }

        public short Id
        {
            get { return id; }
            set { id = value; }
        }

        public short ManagerId
        {
            get { return managerId; }
            set { managerId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    public class Manager : Staff
    {
        public Manager(string stuffName, short stuffId, short stuffManagerId)
            : base(stuffName, stuffId, stuffManagerId)
        {
        }

        public override string Title
        {
            get
            {
                return "Manager";
            }
        }
    }

    public class SoftwareDeveloper
        : Staff
    {
        public SoftwareDeveloper(string stuffName, short stuffId, short stuffManagerId)
            : base(stuffName, stuffId, stuffManagerId)
        {
        }

        public override string Title
        {
            get
            {
                return "Software Developer";
            }
        }
    }

    public class SoftwareTester
        : Staff
    {
        public SoftwareTester(string stuffName, short stuffId, short stuffManagerId)
            : base(stuffName, stuffId, stuffManagerId)
        {
        }

        public override string Title
        {
            get
            {
                return "Software Tester";
            }
        }
    }
    #endregion

    #region Hierarchy
    // Binary Tree will not work, let's create a Graph
    public class EmployeeGraph
    {
        private Dictionary<Staff, LinkedList<Staff>> graph = new Dictionary<Staff, LinkedList<Staff>>();

        public void AddStaff(Staff newStaff)
        {
            foreach (var employee in graph)
            {
                if (employee.Key.Id == newStaff.ManagerId)
                {
                    employee.Value.AddLast(newStaff);
                }
            }

            graph.Add(newStaff, new LinkedList<Staff>());
        }

        public Dictionary<Staff, LinkedList<Staff>> GetGraph
        {
            get { return graph; }
        }

        public LinkedList<Staff> GetDirectReports(short managerId)
        {
            foreach (var employee in graph)
            {
                if (employee.Key.Id == managerId)
                {
                    return employee.Value;
                }
            }

            return null;
        }

        public Staff GetLowestCommonManagers(Staff staff1, Staff staff2)
        {
            return LowestCommonManagers(graph.ElementAt(0).Key, staff1, staff2);
        }

        private Staff LowestCommonManagers(Staff staff, Staff staff1, Staff staff2)
        {
            if (staff == null) return null;
            if (staff.Id == staff1.ManagerId || staff.Id == staff2.ManagerId) return staff;

            Staff s1 = LowestCommonManagers(GetManager(staff1.Id), staff1, staff2);
            Staff s2 = LowestCommonManagers(GetManager(staff2.Id), staff1, staff2);

            if (s1.Id == s2.Id) return staff;
            if (s1 == null && s2 == null) return null;

            return s1 == null ? s2 : s1;
        }

        private Staff GetManager(int id)
        {
            foreach (var employee in graph)
            {
                LinkedList<Staff> list = employee.Value;

                foreach (var item in list)
                {
                    if (id == item.Id)
                        return item;
                }
            }

            return null;
        }


    }
    #endregion
}
