﻿namespace InterviewPrep.Amazon
{
    /* Convert a given Binary Tree to Doubly Linked List */
    /* https://www.geeksforgeeks.org/convert-a-given-binary-tree-to-doubly-linked-list-set-4/ */
    /* Given a Binary Tree (BT), convert it to a Doubly Linked List(DLL) In-Place. 
        The left and right pointers in nodes are to be used as previous and next pointers 
        respectively in converted DLL. The order of nodes in DLL must be same as Inorder 
        of the given Binary Tree. The first node of Inorder traversal (left most node in BT) 
        must be head node of the DLL. */
    class BinaryTreeToDLL
    {
        MyLinkedList.DoublyLinkedList newList = new MyLinkedList.DoublyLinkedList();

        public void ConvertBinaryTreeToDLL(MyTree.TreeNode root)
        {
            InorderInsert(root);
            PrintDLL();
        }

        private void InorderInsert(MyTree.TreeNode node)
        {
            if (node == null) return;

            InorderInsert(node.LeftChild);
            newList.InsertTail(node.ValueInt);
            InorderInsert(node.RightChild);
        }

        private void PrintDLL()
        {
            MyLinkedList.DLLNode current = newList.Head;

            while (current != null)
            {
                System.Console.Write($" { current.Data } ");
                current = current.Next;
            }
        }
    }
}
