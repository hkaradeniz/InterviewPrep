using InterviewPrep.MyLinkedList;

namespace InterviewPrep.General
{
    class DeleteMiddleNodeFromLinkedList
    {
        /* Delete a middle node from linked list */
        /* Given a pointer to the middle node of the linked list delete that node. Head node is not given */

        /* 1 -> 2 -> 3 -> 4 -> 5 */
        /* Deleting Node 3 means, copying Node 4 to Node 3, changing its next node to Node 5 and deleting Node 4*/
        public void DeleteMidNode(Node node)
        {
            // Assuming node will not be Head node
            if (node == null) return;
            if (node.Next == null) node = null; // If it's the last node

            Node temp = node.Next;
            node = temp;
            node.Next = temp.Next;
            temp = null;
        }
    }
}
