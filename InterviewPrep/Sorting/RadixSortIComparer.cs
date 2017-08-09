using System;
using System.Collections;

namespace InterviewPrep.Sorting
{
    class CompareClass : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            string s1 = (string)x;
            string s2 = (string)y;

            if (s1.Length < s2.Length) return -1;
            if (s1.Length > s2.Length) return 1;

            // If we get here, that means they have the equal length
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] < s2[i]) return -1;
                if (s1[i] > s2[i]) return 1;
            }

            return 0;
        }
    }

    class RadixSortIComparer
    {
        // Test array
        // string[] arr = new string[] {31415926535897932384626433832795,1,3,10,3,5};
        public void RadixSortWithIComparer(string[] arr)
        {
            CompareClass myCompare = new CompareClass();
            Array.Sort(arr, myCompare);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
