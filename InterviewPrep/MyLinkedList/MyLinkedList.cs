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


        In this p roblem, you are not given access to the head of the linked list. You only have access to that node.
        The solution is simply to copy the data from the next node over to the current node, and then to delete the
        next node.
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

        /*
         Maintain two pointers – reference pointer and main pointer. Initialize both reference and main pointers to head. 
         First move reference pointer to n nodes from head. Now move both pointers one by one until reference pointer 
         reaches end. Now main pointer will point to nth node from the end. Return main pointer.
         */
        public Node FindKthNodeFromEnd2(Node head, int k)
        {
            if (head == null) return null;

            Node fast = head;
            Node slow = head;

            int counter = 1;
            while (counter <= k)
            {
                if (fast == null) return null;

                fast = fast.Next;
                counter++;
            }

            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            return slow;
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


        /*?
         *      Cracking the Coding Interview, 6th Edition
         * Intersection: Given two (singly) linked lists, determine if the two lists intersect. Return the
            intersecting node. Note that the intersection is defined based on reference, not value. That is, if the
            kth node of the first linked list is the exact same node (by reference) as the jth node of the second
            linked list, then they are intersecting.


            One thought is that we could traverse backwards through each linked list. When the linked lists"split'; that's
            the intersection. Of course, you can't really traverse backwards through a singly linked list.
            If the linked lists were the same length, you could just traverse through them at the same time. When they
            collide, that's your intersection.

            When they're not the same length, we'd like to just"chop off"-or ignore-those excess (gray) nodes.
            How can we do this? Well, if we know the lengths of the two linked lists, then the difference between those
            two linked lists will tell us how much to chop off.
            We can get the lengths at the same time as we get the tails of the linked lists (which we used in the first step
            to determine if there's an intersection).

            Putting it all together.
            We now have a multistep process.
            1. Run through each linked list to get the lengths and the tails.
            2. Compare the tails. If they are different (by reference, not by value), return immediately. There is no intersection.
            3. Set two pointers to the start of each linked list.
            4. On the longer linked list, advance its pointer by the difference in lengths.
            5. Now, traverse on each linked list until the pointers are the same.
         */
        public Node GetIntersectingNode(Node head1, Node head2)
        {
            if (head1 == null || head2 == null)
                return null;

            LinkedListInfo result1 = GetLinkedListInfo(head1);
            LinkedListInfo result2 = GetLinkedListInfo(head2);

            if (result1.LastNode != result2.LastNode)
                return null;

            Node shorter = result1.Size > result2.Size ? head2 : head1;
            Node longer = result1.Size > result2.Size ? head1 : head2;

            int difference = Math.Abs(result1.Size - result2.Size);

            /* Advance the pointer for the longer linked list by difference in lengths. */
            while (difference > 0 && longer!=null)
            {
                longer = longer.Next;
                difference--;
            }

            while (shorter != null && longer != null)
            {
                if (shorter == longer)
                    return longer;

                shorter = shorter.Next;
                longer = longer.Next;
            }

            return null;
        }

        public LinkedListInfo GetLinkedListInfo(Node head)
        {
            int size = 0;
            Node tail = null;

            Node current = head;
            while (current != null)
            {
                size++;
                tail = current;
                current = current.Next;
            }

            return new LinkedListInfo(size, tail);
        }

        /*?
          Cracking the Coding Interview, 6th Edition
        Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
        beginning of the loop.
        DEFINITION
        Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so
        as to make a loop in the linked list.
        
        To summarize, we move FastPointer twice as fast as SlowPointer. When SlowPointer enters
        the loop, after k nodes, FastPointer is k nodes into the loop. This means that FastPointer and
        SlowPointer are LOOP _SIZE - k nodes away from each other.
        Next, if FastPointer moves two nodes for each node that SlowPointer moves, they move one node
        closer to each other on each turn. Therefore, they will meet after LOOP _SIZE - k turns. Both will be k
        nodes from the front of the loop.
        The head of the linked list is also k nodes from the front of the loop. So, if we keep one pointer where it is,
        and move the other pointer to the head of the linked list, then they will meet at the front of the loop.
        Our algorithm is derived directly from parts 1, 2 and 3.

        1. Create two pointers, FastPointer and SlowPointer.
        2. Move FastPointer at a rate of 2 steps and SlowPointer at a rate of 1 step.
        3. When they collide, move SlowPointer to LinkedListHead. Keep FastPointer where it is.
        4. Move SlowPointer and FastPointer at a rate of one step. Return the new collision point.
        */
        public Node FindTheBeginningOfTheLoop(Node head)
        {
            if (head == null)
                return null;

            Node slow = head;
            Node fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                // Loop Detected?
                if (slow == fast)
                    break;
            }

            /* We don't know yet if the loop hit break point. That is why we do Error check - no meeting point, and therefore no loop*/
            if (fast == null || fast.Next == null)
                return null;

            /* Move slow to Head. Keep fast at Meeting Point. Each are k steps from the
                Loop Start. If they move at the same pace, they must meet at Loop Start . */
            slow = head;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            /* Both now point to the start of the loop. Return either fast or slow */
            return fast;
        }

        // Sorted LinkedList
        public void RemoveDuplicates(Node head)
        {
            if (head == null || head.Next == null) return;

            Node current = head;

            while (current.Next != null)
            {
                if (current.Value == current.Next.Value)
                {
                    if (current.Next.Next == null)
                    { current.Next = null; break; }
                    else
                    { current.Next = current.Next.Next; }
                }
                else
                {
                    current = current.Next;
                }
            }
        }
    }

    public class LinkedListInfo
    {
        public int Size { get; }
        public Node LastNode { get; }

        public LinkedListInfo(int size, Node node)
        {
            Size = size;
            LastNode = node;
        }
    }
}
