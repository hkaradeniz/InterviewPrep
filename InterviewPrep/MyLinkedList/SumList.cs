using System;

namespace InterviewPrep.MyLinkedList
{
    class SumList
    {
        /*? Cracking the Coding Interview, 6th Edition
             Sum Lists: You have two numbers represented by a linked list, where each node contains a single
            digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
            function that adds the two numbers and returns the sum as a linked list.
            EXAMPLE
            Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is,617 + 295.
            Output: 2 -> 1 -> 9. That is, 912.
       */

        public MyLinkedList GetSumListReverseOrder(MyLinkedList list1, MyLinkedList list2)
        {
            Node first = list1.Head;
            Node second = list2.Head;
            int carry = 0;
            int sum = 0;
            MyLinkedList newList = new MyLinkedList();

            while (first != null || second != null)
            {
                sum = carry + (first == null ? 0 : first.Value) + (second == null ? 0 : second.Value);

                carry = sum / 10;
                sum = sum % 10;

                newList.AddLast(sum);

                if (first != null)
                    first = first.Next;

                if (second != null)
                    second = second.Next;
            }

            if (carry > 0)
                newList.AddLast(carry);

            newList.DisplayAll();

            return newList;
        }

        /*? Cracking the Coding Interview, 6th Edition
            FOLLOW UP
            Suppose the digits are stored in forward order. Repeat the above problem.
            EXAMPLE
            lnput:(6 -> 1 -> 7) + (2 -> 9 -> 5).That is,617 + 295.
            Output: 9 - > 1 -> 2. That is, 912.
       */

        public MyLinkedList GetSumListForwardOrder(MyLinkedList list1, MyLinkedList list2)
        {
            /*?
            Hint:
             6 1 7
             2 9 5
            +------
             (600 + 200) + (10 + 90) + (7 + 5) => 912 
            */
            MyLinkedList newList = new MyLinkedList();
            Node first = list1.Head;
            Node second = list2.Head;
            int sum = 0;

            int len1 = 0;
            int len2 = 0;

            // Get the length of the first linkedlist
            while (first !=null)
            { first = first.Next; len1++; }
            // len1 = list1.Size;


            // Get the length of the second linkedlist
            while (second != null)
            { second = second.Next; len2++; }
            //len2 = list2.Size;
            
            // Padding if second linkedlist is smaller
            while (len1 > len2)
            {
                list2.AddFirst(0);
                len2++;
            }

            // Padding if second linkedlist is smaller
            while (len2 > len1)
            {
                list1.AddFirst(0);
                len1++;
            }

            first = list1.Head;
            second = list2.Head;
            int power = len1 - 1;

            // Get total sum
            while (first != null || second != null)
            {
                sum += ((first == null ? 0 : first.Value) + (second == null ? 0 : second.Value)) * Convert.ToInt32(Math.Pow(10, power));
                power--;

                first = first.Next;
                second = second.Next;
            }

            // Parse total sum and store it in linkedlist
            while (sum > 0)
            {
                int digit = sum % 10;
                sum = sum / 10;

                newList.AddFirst(digit);
            }

            newList.DisplayAll();

            return newList;
        }

        public MyLinkedList GetSumListForwardOrderOptimum(MyLinkedList list1, MyLinkedList list2)
        {
            /*?
            Hint:
             6 1 7
             2 9 5
            +------
            (600 + 200) + (10 + 90) + (7 + 5) => 912 
            */

            MyLinkedList newList = new MyLinkedList();
            Node first = list1.Head;
            Node second = list2.Head;
            int sum = 0;

            int len1 = 0;
            int len2 = 0;

            // Get the length of the first linkedlist
            while (first != null)
            { first = first.Next; len1++; }
            // len1 = list1.Size;


            // Get the length of the second linkedlist
            while (second != null)
            { second = second.Next; len2++; }
            //len2 = list2.Size;

            // Padding if second linkedlist is smaller
            while (len1 > len2)
            {
                list2.AddFirst(0);
                len2++;
            }

            // Padding if second linkedlist is smaller
            while (len2 > len1)
            {
                list1.AddFirst(0);
                len1++;
            }

            int total = 0;

            first = list1.Head;
            second = list2.Head;
            while (first != null)
            {
                total *= 10;
                total += first.Value + second.Value;
                first = first.Next;
                second = second.Next;
            }

            while (total > 0)
            {
                int digit = total % 10;
                total /= 10;

                newList.AddFirst(digit);
            }

            newList.DisplayAll();

            return newList;
        }
    }
 }
