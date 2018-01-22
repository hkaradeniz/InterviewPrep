using System;
using InterviewPrep.MyLinkedList;

namespace InterviewPrep.Adobe
{
    /* Finding middle element in a linked list */
    /*
    Test Data:
        Adobe.LinkedListMiddleElement lm = new Adobe.LinkedListMiddleElement();
        MyLinkedList.Node head = new MyLinkedList.Node(5);
        //head.Next = new MyLinkedList.Node(10);
        //head.Next.Next = new MyLinkedList.Node(12);
        //head.Next.Next.Next = new MyLinkedList.Node(20);
        //head.Next.Next.Next.Next = new MyLinkedList.Node(25);
        lm.FindMiddleElement(head);
     */
    class LinkedListMiddleElement
    {
        public void FindMiddleElement(Node head)
        {
            if (head == null) return;

            Node slow = head;
            Node fast = head.Next;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next; 
            }

            // if fast.next is null, the list has odd number of elements
            // if fast is null, the list has even number of elements
            
            if(fast == null)
                Console.WriteLine(slow.Value);
            else if(fast.Next == null)
                Console.WriteLine((slow.Value + slow.Next.Value) / 2);
        }  
    }
}
