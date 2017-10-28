using System.Collections.Generic;

namespace InterviewPrep.General
{
    class FriendCircle
    {
        /* 
         Friend Circle Problem - Graph Theory
        Problem:
        There are n students in a class. Every student can have 0 or more friends. If A is a friend of B and B is 
        a friend of C then A and C are also friends. So we define a friend circle as a group of students 
        */
        int[] students;
        int[] size;
        int NumberOfStudents = 0;

        public FriendCircle(int n)
        {
            students = new int[n];
            size = new int[n];
            NumberOfStudents = n;
            InitializeArrays(n);
        }

        private void InitializeArrays(int n)
        {
            for (int i = 0; i < n; i++)
            {
                students[i] = i;
                size[i] = 1;
            }
        }

        /* Solution: Let's use Weighted Union-Find and then calculate the disjoint sets */
        /*
        Test Data:
         General.FriendCircle fc = new General.FriendCircle(10);
            fc.AddCircle(3, 4);
            fc.AddCircle(4, 9);
            fc.AddCircle(8, 0);
            fc.AddCircle(2, 3);
            Console.WriteLine(fc.CalculateNumberOfCircles());
            */
        public int CalculateNumberOfCircles()
        {
            if (students == null || NumberOfStudents == 0) return 0;

            int numberOfCircles = 0;
            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < NumberOfStudents; i++)
            {
                int value = Root(students[i]);

                if (!hash.Contains(value))
                {
                    hash.Add(value);
                    numberOfCircles++;
                }
            }

            return numberOfCircles;
        }

        public void AddCircle(int student1, int student2)
        {
            if (size[student1] > size[student2])
            {
                students[student2] = students[student1];
                size[student1] += students[student2];
            }
            else
            {
                students[student1] = students[student2];
                size[student2] += students[student1];
            }
        }

        private int Root(int student)
        {
            while (student != students[student])
            {
                // Path Compression
                // Quick union with path compression: Just after computing the root of p,
                // set the id of each examined node to point to that root
                students[student] = students[students[student]]; // --> only one extra line of code
                student = students[student];
            }

            return student;
        }

        public bool Find(int student1, int student2)
        {
            return Root(student1) == Root(student2);
        }
    }
}
