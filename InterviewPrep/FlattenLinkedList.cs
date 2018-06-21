using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    // Flatten a Linked List
    //http://blog.gainlo.co/index.php/2016/06/12/flatten-a-linked-list/
    /*
     Given a linked list, in addition to the next pointer, each node has a child pointer 
     that can point to a separate list. With the head node, flatten the list to a 
     single-level linked list.
     
        Linked list
                1 -> 2 -----> 3 -> 4
                    |             |
                    V             V
                    5 ->6         7  
                    |             |
                    V             V
                    8             9                  
            

    For instance, the above linked list should be flattened to 1→2->3→4->5->6->7->8->9.
    The idea is to flatten the linked list by level.Note: this question was 
    asked by Facebook a month ago.

        So a very straightforward solution can be described like this:

        + Start from the head node and traverse the linked list following the next pointer.
        + When a node has a child node, put the child node into the queue.
        + When the next pointer of the current node is null, pop the queue and 
        repeat from the step 1 using the popped node.

        The complexity is linear for both time and space since we only need to traverse 
        or store each node at most once.

    // Test
    FlattenLinkedList fl = new FlattenLinkedList();
    fl.FlattenTheList();
    fl.PrintList();
    Console.Read();

    */

    // LinkedList Node
    class FNode
    {
        public FNode Next { get; set; }
        public FNode Child { get; set; }
        public int Value { get; set; }

        public FNode(int val)
        {
            Value = val;
        }
    }

    //
    class FlattenLinkedList
    {
        public FNode Head { get; set; }
        public FNode Tail { get; set; }

        public FlattenLinkedList()
        {
            Head = new FNode(1);
            Head.Next = new FNode(2);
            Head.Next.Child = new FNode(5);
            Head.Next.Child.Next = new FNode(6);
            Head.Next.Child.Child = new FNode(8);
            Head.Next.Next = new FNode(3);
            Head.Next.Next.Next = Tail = new FNode(4); // Tail is here
            Head.Next.Next.Next.Child = new FNode(7);
            Head.Next.Next.Next.Child.Child = new FNode(9);

            /*    Linked list
                        1 -> 2 -----> 3 -> 4
                            |             |
                            V             V
                            5 ->6         7  
                            |             |
                            V             V
                            8             9                  
            */
        }

        public void Flatten()
        {
            FNode current = Head;
            FNode tail = Tail;

            Queue<FNode> queue = new Queue<FNode>();

            while (current != null)
            {
                if (current.Child != null)
                {
                    queue.Enqueue(current.Child);
                    Flatten(queue);
                    current.Child = null;
                }

                current = current.Next;
            }

            PrintList();
        }

        private void Flatten(Queue<FNode> queue)
        {
            while (queue.Count > 0)
            {
                FNode node = queue.Dequeue();
                Tail = Tail.Next = node;

                if (node.Child != null) queue.Enqueue(node.Child);
                if (node.Next != null) queue.Enqueue(node.Next);

                node.Child = null;
                node.Next = null;
            }
        }

        /*
        public void AddLast(int val)
        {
            FNode newNode = new FNode(val);

            if (Head == null)
            {
                Tail = newNode;
                Head = Tail;
            }
            else
            {
                Tail = Tail.Next = newNode;
            }
        }

        public void FlattenTheList()
        {
            FlattenTheLinkedList(Head);
        }

        private void FlattenTheLinkedList(FNode root)
        {
            // Base Cases
            if (root == null)
                return;

            // When we need to traverse a tree or graph or any data structure by level, 
            // the first thing comes to our mind should be breadth-first search 
            // (BFS) and the data structure associated with it is queue. 
            Queue<FNode> bfsQueue = new Queue<FNode>();

            // Iterate until you see a node with child
            // and add this child into the Queue
            while (root != null)
            {
                if (root.Child != null)
                {
                    bfsQueue.Enqueue(root.Child);
                    break;
                }

                root = root.Next;
            }

            // Treat this as tree and run BFS
            // get all the nodes and add them to the
            // end of the Linkedlist  
            while (bfsQueue.Count > 0)
            {
                FNode current = bfsQueue.Dequeue();

                AddLast(current.Value);

                if (current.Child != null)
                    bfsQueue.Enqueue(current.Child);

                if (current.Next != null)
                    bfsQueue.Enqueue(current.Next);
            }

            // If we are not at the end of the list
            // keep going
            if (root != null)
                FlattenTheLinkedList(root.Next);
        }
        */
        // Print the LinkedList
        public void PrintList()
        {
            FNode current = Head;

            while (current != null)
            {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }
    }
}
