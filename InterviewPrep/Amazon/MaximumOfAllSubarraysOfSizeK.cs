using System;

namespace InterviewPrep.Amazon
{
    /* Maximum of all subarrays of size k */
    /* Given an array and an integer k, find the maximum for each and every contiguous subarray of size k. */
    /* https://practice.geeksforgeeks.org/problems/maximum-of-all-subarrays-of-size-k/0 */
    /* Input:
        9 3
        1 2 3 1 4 5 2 3 6

        10 4
        8 5 10 7 9 4 15 12 90 13

        Output:
        3 3 4 5 5 5 6

        10 10 10 15 15 90 90 
     */
     /*
        Amazon.MaximumOfAllSubarraysOfSizeK m = new Amazon.MaximumOfAllSubarraysOfSizeK();
        m.PrintMaximumOfAllSubarraysOfSizeK(new int[] { 12, 1, 78, 90, 57, 89, 56 }, 3, 7);
     */
    class MaximumOfAllSubarraysOfSizeK
    {
        internal class MyLinkedList
        {
            public LinkedListNode Head { get; set; }
            public LinkedListNode Tail { get; set; }

            public void AddLast(int value, int index)
            {
                LinkedListNode newNode = new LinkedListNode(value, index);

                if (Head == null)
                {
                    Head = Tail = newNode;
                    return;
                }

                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }

            public void RemoveFirst()
            {
                if (Head == null)
                    return;
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
            }

            public void RemoveLast()
            {
                if (Head == null)
                    return;
                else if (Head == Tail)
                    Clear();
                else
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }
            }

            public bool IsEmpty()
            {
                return Head == null;
            }

            public void Clear()
            {
                Head = null;
            }
        }

        internal class LinkedListNode
        {
            public LinkedListNode Next { get; set; }
            public LinkedListNode Previous { get; set; }
            public int Value { get; }
            public int Index { get; }

            public LinkedListNode(int value, int index)
            {
                Value = value;
                Index = index;
            }
        }

        public void PrintMaximumOfAllSubarraysOfSizeK(int[] arr, int k, int n)
        {
            if (arr == null || arr.Length == 0) return;

            MyLinkedList list = new MyLinkedList();

            for (int i = 0; i < k; i++)
            {
                while (!list.IsEmpty() && arr[list.Tail.Index] < arr[i])
                    list.RemoveLast();

                list.AddLast(arr[i], i);
            }


            for (int i = k; i < n; i++)
            {
                // The head of the list is the maximum element in the window
                Console.WriteLine($" { list.Head.Value } ");

                while (!list.IsEmpty() && list.Head.Index <= i - k)
                    list.RemoveFirst();

                while (!list.IsEmpty() && arr[list.Tail.Index] < arr[i])
                    list.RemoveLast();

                list.AddLast(arr[i], i);
            }

            Console.WriteLine($" { list.Head.Value } ");
        }
    }
}
