using System;
using System.Collections.Generic;

namespace InterviewPrep.MyLinkedList
{
    class MyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Size { get; set; }

        public MyLinkedList()
        {
            Head = null;
            Size = 0;
        }

        public void ClearLinkedList()
        {
            Head = null;
        }

        public Node First()
        {
            return Head;
        }

        private void IncreaseSize()
        {
            Size++;
        }

        private void DecreaseSize()
        {
            Size--;
        }

        public void AddLast(int Value)
        {
            Node newNode = new Node(Value);

            if (Head == null)
            {
                Tail = newNode;
                Head = Tail;
            }
            else
            {
                Tail = Tail.Next = newNode;
            }

            IncreaseSize();
        }

        public void AddFirst(int value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Tail = newNode;
                Head = Tail;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            IncreaseSize();
        }

        public Node FindNode(int value)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void DisplayAll()
        {
            Node current = Head;

            while (current != null)
            {
                current.DisplayNode();
                current = current.Next;
            }
        }

        public void Remove(int value)
        {
            Node current = Head;

            if (current.Value == value)
            { Head = Head.Next; return; }

            while (current.Next != null)
            {
                if (current.Next.Value == value)
                { current.Next = current.Next.Next; return; }

                current = current.Next;
            }

            DecreaseSize();
        }

        public void ReverseList()
        {
            Stack<Node> stack = new Stack<Node>();
            Node current = Head;

            while(current != null)
            {
                stack.Push(current);
                current = current.Next;
            }

            Head = stack.Pop();
            current = Head;

            while (stack.Count > 0)
            {
                current.Next = stack.Pop();
                current = current.Next;
            }

            current.Next = null;
        }

        public void InsertAfter(int value, int insertAfterValue)
        {
            Node insertAfterNode = FindNode(insertAfterValue);
            Node newNode = new Node(value);

            if (insertAfterNode != null)
            {
                newNode.Next = insertAfterNode.Next;
                insertAfterNode.Next = newNode;
                IncreaseSize();
            }
            else
            {
                Console.WriteLine("Node is not in the list!");
            }
        }

        public void InsertBefore(int value, int insertBeforeValue)
        {
            Node newNode = new Node(value);
            Node current = Head;
            Node previous = null;

            // Insert Before Head
            if (current.Value == insertBeforeValue)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            while (current != null)
            {
                if (current.Value == insertBeforeValue)
                {
                    newNode.Next = current;
                    previous.Next = newNode;
                    IncreaseSize();
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            } 
        }

        /*? 
       Cracking the Coding Interview, 6th Edition
      Remove Dups! Write code to remove duplicates from an unsorted linked list.
       */
        public void RemoveDuplicatesUsingBuffer()
        {
            HashSet<int> bufferHash = new HashSet<int>();
            Node current = Head;

            if (current == null)
            {
                return;
            }

            bufferHash.Add(current.Value);

            while (current.Next != null)
            {
                if (bufferHash.Contains(current.Next.Value))
                {
                    //// Delete it...
                    current.Next = current.Next.Next;
                }
                else
                {
                    bufferHash.Add(current.Next.Value);
                    current = current.Next;
                }
            }

            DisplayAll();
        }

        /*?
        Cracking the Coding Interview, 6th Edition
        Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
        the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
        that node.
        EXAMPLE
        lnput:the node c from the linked list a->b->c->d->e->f
        Result: nothing is returned, but the new linked list looks like a ->b->d- >e- >f
         */
        public void DeleteNodeFromTheMiddle(Node node)
        {
            if (node == null || node.Next == null)
                throw new InvalidOperationException();

            Node next = node.Next;
            node.Value = next.Value;
            node.Next = next.Next;
        }


        /*? 
        Cracking the Coding Interview, 6th Edition
        Remove Dups! Write code to remove duplicates from an unsorted linked list.
        FOLLOW UP
        How would you solve this problem if a temporary buffer is not allowed?
        */

        public void RemoveDuplicatesWithoutBuffer()
        {
            Node current = Head; 

            // If head is null, list is empty
            if (current == null)
            { return; }

            while (current.Next != null)
            {
                Node pointer = current.Next;
                Node previous = current;
    
                while (pointer != null)
                {
                    if (pointer.Value == current.Value)
                    {
                        pointer = pointer.Next;
                        previous.Next = pointer;
                    }
                    else
                    {
                        previous = pointer;
                        pointer = pointer.Next;
                    }
                }

                current = current.Next;
            }

            DisplayAll();
         
        }

        /*? 
        Cracking the Coding Interview, 6th Edition
        Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
        */
        // Recursive
        public int FindKthNodeFromEnd(Node node, int k)
        {
            if (node == null)
                return 0;

            int i = FindKthNodeFromEnd(node.Next, k) + 1;

            if (i == k)
            {
                Console.WriteLine(node.Value);
            }

            return i; 
        }

        public void FindKthNodeFromEnd(int k)
        {
            Node current = Head;

            if (Head == null)
            { Console.WriteLine("Empty list!"); return; }

            int len = 0;

            while (current.Next != null)
            {
                current = current.Next;
                len++;
            }

            current = Head;

            if (len < k)
            {
                Console.WriteLine($"{k} is bigger than the size of the linkedlist");
                return;
            }

            current = Head;
            for (int i = 0; i < len-k+1; i++)
            {
                current = current.Next;
            }

            Console.WriteLine(current.Value);
        }

        /*? 
     Cracking the Coding Interview, 6th Edition
    Palindrome: Implement a function to check if a linked list is a palindrome.
     */
        Node left;
        // Time is O(n) and space is O(1).
        public bool IsPalindrome()
        {
            left = Head;
            return PalindromeHelper(Head);
        }


        private bool PalindromeHelper(Node node)
        {
            // Stop recursion if we hit the last node
            if(node == null)
                return true;

            bool result = PalindromeHelper(node.Next);

            if (!result)
                return false;

            //compare left with right (as left gets left.next we compare left and right)
            bool compare = node.Value == left.Value;

            left = left.Next;

            return compare; 
        }
    }
}
