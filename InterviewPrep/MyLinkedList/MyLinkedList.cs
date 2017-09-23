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
    }
}
