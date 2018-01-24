using System;

namespace InterviewPrep.Yahoo
{
    /* Surpasser Count */
    /* A surpasser of an element of an array is a greater element to its right, therefore x[j] is a surpasser of x[i] if i < j and x[i] < x[j]. The surpasser count of an element is the number of surpassers. */
    /* https://practice.geeksforgeeks.org/problems/surpasser-count/0 */
    class SurpasserCount
    {
        // Time Complexity: O(n log(n))
        // Space Complexity: O(n)
        // Create a tree and insert values there...
        // While inserting keep a right leaf count...
        // Right leaf count will give us how many bigger elements there are after the current value... 
        public void PrintSurpasserList(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            CTree tree = new CTree();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} \t");
                tree.Insert(arr[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{tree.GetRightElementCount(arr[i])} \t");
            }

        }

        internal class CTreeNode
        {
            public int Value { get; }
            public CTreeNode Left { get; set; }
            public CTreeNode Right { get; set; }
            public int RightCount { get; set; }

            public CTreeNode(int val)
            {
                Value = val;
                RightCount = 0;
            }
        }

        internal class CTree
        {
            public CTreeNode Root { get; set; }

            public void Insert(int value)
            {
                CTreeNode newNode = new CTreeNode(value);

                if (Root == null) { Root = newNode; return; }

                CTreeNode current = Root;

                while (true)
                {
                    if (value > current.Value)
                    {
                        current.RightCount++;

                        if (current.Right == null)
                        { current.Right = newNode; break; }

                        current = current.Right;
                    }
                    else if (value < current.Value)
                    {
                        if (current.Left == null)
                        { current.Left = newNode; break; }

                        current = current.Left;
                    }
                }
            }

            public int GetRightElementCount(int n)
            {
                CTreeNode current = Root;

                while (current != null)
                {
                    if (current.Value == n)
                    { return current.RightCount; }
                    else if (n > current.Value)
                    { current = current.Right; }
                    else
                    { current = current.Left; }
                }

                return -1;
            }
        }
    }
}
