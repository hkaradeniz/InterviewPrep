using System.Collections.Generic;

namespace InterviewPrep
{
    /*
     Merge k sorted linked lists and return it as one sorted list.

        Example :

        1 -> 10 -> 20
        4 -> 11 -> 13
        3 -> 8 -> 9
        will result in

     1 -> 3 -> 4 -> 8 -> 9 -> 10 -> 11 -> 13 -> 20
    */
    public class MergeKSortedLists
    {
        public class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int v) { val = v; }
        }

        public ListNode Merge(List<ListNode> list)
        {
            ListNode list1 = list[1];

            if (list.Count == 1) return list1;

            ListNode newHead = null;

            for (int i = 1; i < list.Count; i++)
            {
                ListNode sorting = null;
                ListNode list2 = list[i];

                if (list1.val < list2.val)
                {
                    newHead = list1;
                    list1 = list1.next;
                }
                else
                {
                    newHead = list2;
                    list2 = list2.next;
                }

                while (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        sorting = sorting.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        sorting = sorting.next = list2;
                        list2 = list2.next;
                    }
                }

                if (list1 == null) sorting.next = list2;
                if (list1 == null) sorting.next = list1;

                list1 = newHead;
            }

            return newHead;
        }
    }
}
