using InterviewPrep.MyTree;
using System;

namespace InterviewPrep.Amazon
{
    /*
     *      Amazon.SerializeDeserializeBinarySearchTree sd = new Amazon.SerializeDeserializeBinarySearchTree();
            MyTree.MyTree mt = new MyTree.MyTree();
            mt.InsertNumber(500);
            mt.InsertNumber(300);
            mt.InsertNumber(700);
            mt.InsertNumber(250);
            mt.InsertNumber(350);
            mt.InsertNumber(650);
            mt.InsertNumber(750);
            mt.InsertNumber(325);
            mt.InsertNumber(375);
            mt.InsertNumber(675);
            mt.InsertNumber(800);
            sd.Serilaze(mt.Root);
     Given a binary search tree (BST), how can you serialize and deserialize it? Serialization is 
     defined as storing a given tree in a file or an array. Deserialization is reverse of serialization 
     where we need to construct the binary tree if we are given a file or an array which stores the binary tree.
     */
    /*
                             500
                         /         \   
                       300         700
                     /   \         /  \
                    250  350     650   750
                        /  \           /  \
                      325  375       675   800
     */
    class SerializeDeserializeBinarySearchTree
    {
        int[] SerilizedArray;
        int Capacity = 10;
        int Pointer = -1;

        public SerializeDeserializeBinarySearchTree()
        {
            SerilizedArray = new int[Capacity];
        }

        public void Serilaze(TreeNode root)
        {
            PreOrder(root);
            TrimSerilizedArray();
            PrintSerilizedArray();
        }

        public TreeNode DeSerilize()
        {
            if (SerilizedArray.Length == 0) return null;

            return DeSerilize(0, SerilizedArray.Length-1);
        }

        private TreeNode DeSerilize(int left, int right)
        {
            if (left > right) return null;

            TreeNode root = new TreeNode(SerilizedArray[left]);

            int divisionIndex = FindDivision(root.ValueInt, left + 1, right);

            root.LeftChild = DeSerilize(left + 1, divisionIndex - 1);
            root.RightChild = DeSerilize(divisionIndex, right);

            return root;
        }

        private void PreOrder(TreeNode root)
        {
            if (root == null) return;

            Pointer++;

            EnsureExtraCapacity();
            SerilizedArray[Pointer] = root.ValueInt;

            PreOrder(root.LeftChild);
            PreOrder(root.RightChild);
        }

        private void EnsureExtraCapacity()
        {
            if (Pointer == Capacity)
            {
                Capacity *= 2;
                Resize(Capacity);
            }
        }

        private void Resize(int newCapacity)
        {
            int[] temp = new int[newCapacity];

            for (int i = 0; i < SerilizedArray.Length; i++)
            {
                temp[i] = SerilizedArray[i];
            }

            SerilizedArray = temp;
        }

        private void TrimSerilizedArray()
        {
            int[] temp = new int[Pointer + 1];

            for (int i = 0; i <= Pointer; i++)
            {
                temp[i] = SerilizedArray[i];
            }

            SerilizedArray = temp;
        }

        private int FindDivision(int value, int left, int right)
        {
            // Example:
            // { 500, 300, 250, 350, 325, 375, 700, 650, 750, 675, 800 }
            // First Iteration: left=0 right=10 value: 500 return:700
            for (int i = left; i <= right; i++)
            {
                if (value < SerilizedArray[i])
                    return i;
            }

            return -1;
        }

        private void PrintSerilizedArray()
        {
            foreach (var item in SerilizedArray)
            {
                Console.Write($" { item } ");
            }
        }
    }
}
