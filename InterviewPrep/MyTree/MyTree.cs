using System;
using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class MyTree
    {
        /* Create BST
          MyTree mt = new MyTree();
            mt.Add(400);
            mt.Add(200);
            mt.Add(100);
            mt.Add(120);
            mt.Add(160);
            mt.Add(220);
            mt.Add(300);
            mt.Add(500);
            mt.Add(450);
         */

        public TreeNode Root;
        int numberOfVisitedNodes = 0;
        int maxLevel = -1;
        int maxLevelResult = -1;

        public MyTree()
        {
            Root = null;
        }

        public TreeNode First
        {
            get { return Root; }
        }

        // Insert Recursively
        public void Insert(int value)
        {
            Root = InsertElement(Root, value);
        }

        private TreeNode InsertElement(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
                return node;
            }

            if (value < node.ValueInt)
                node.LeftChild = InsertElement(node.LeftChild, value);
            else if (value > node.ValueInt)
                node.RightChild = InsertElement(node.RightChild, value);

            return node;
        }

        /*
        *** BST DELETE SCENARIOS ***

        1) Node to be deleted is leaf: Simply remove from the tree.

             50                             50
           /     \         delete(20)      /   \
          30      70       --------->    30     70 
         /  \    /  \                     \    /  \ 
       20   40  60   80                   40  60   80


        2) Node to be deleted has only one child: Copy the child to the node and delete the child
             50                             50
           /     \         delete(30)      /   \
          30      70       --------->    40     70 
            \    /  \                          /  \ 
            40  60   80                       60   80


        3) Node to be deleted has two children: Find inorder successor of the node. 
        Copy contents of the inorder successor to the node and delete the inorder successor. 
        Note that inorder predecessor can also be used.
             50                             60
           /     \         delete(50)      /   \
          40      70       --------->    40    70 
                 /  \                            \ 
                60   80                           80
            
        */
        // Delete Recursively
        public void Delete(int value)
        {
            Root = DeleteElement(Root, value);
        }

        private TreeNode DeleteElement(TreeNode node, int value)
        {
            /* Base Case: If the tree is empty */
            if (node == null)
                return node;

            /* Otherwise, recur down the tree */
            if (value < node.ValueInt)
                node = DeleteElement(node.LeftChild, value);
            else if (value > node.ValueInt)
                node = DeleteElement(node.RightChild, value);

            // if key is same as node's key, then This is the node
            // to be deleted
            else
            {
                // node with only one child or no child
                if (node.LeftChild == null)
                    return node.RightChild;
                else if (node.RightChild == null)
                    return node.LeftChild;

                // node with two children: Get the smallest in the right subtree
                node.ValueInt = MinValue(node).ValueInt;

                // Delete the smallest in the right subtree
                node.RightChild = DeleteElement(node.RightChild, node.ValueInt);
            }

            return node;
        }

        private TreeNode MinValue(TreeNode node)
        {
            if (node.LeftChild != null)
                return MinValue(node.LeftChild);
            else
                return node;
        }

        public void InsertNumber(int value)
        {
            TreeNode newNode = new TreeNode(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                TreeNode pointer = Root;

                while (true)
                {
                    if (newNode.ValueInt > pointer.ValueInt)
                    {
                        if (pointer.RightChild == null)
                        {
                            pointer.RightChild = newNode;
                            return;
                        }

                        pointer = pointer.RightChild;
                    }
                    else if (newNode.ValueInt < pointer.ValueInt)
                    {
                        if (pointer.LeftChild == null)
                        {
                            pointer.LeftChild = newNode;
                            return;
                        }

                        pointer = pointer.LeftChild;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public void InsertString(string str)
        {
            TreeNode newNode = new TreeNode(str);

            if (Root == null)
                Root = newNode;
            else
            {
                TreeNode pointer = Root;

                while (true)
                {
                    if (pointer.ValueStr.CompareTo(newNode.ValueStr) < 0)
                    {
                        if (pointer.RightChild == null)
                        {
                            pointer.RightChild = newNode;
                            return;
                        }
                        else
                        {
                            pointer = pointer.RightChild;
                        }
                    }
                    else if (pointer.ValueStr.CompareTo(newNode.ValueStr) > 0)
                    {
                        if (pointer.LeftChild == null)
                        {
                            pointer.LeftChild = newNode;
                            return;
                        }
                        else
                        {
                            pointer = pointer.LeftChild;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

        }

        /*  k-th largest element of the BST
         *  
         * http://blog.gainlo.co/index.php/2016/06/03/second-largest-element-of-a-binary-search-tree/
           * You don’t need to store all the visited elements into an array and find the k-th element. Instead, use a global variable i to record the index of visited elements. Inside the traversal function, every time when you visit an element, just increment i by one and when i == k, output the current element.
           * Be careful about cases where there are less than k elements in the BST.
           * You should handle empty tree as well.
           * Don’t forget to check if left and right are null when traversing the tree.
         */

        // Second Largest Element of a Binary Search Tree
        public void FindKthLargestElement(int k)
        {
            numberOfVisitedNodes = 0;
            FindKthLargestElement(Root, k);
        }

        public void FindKthLargestElement(TreeNode node, int k)
        {
            if (node == null || numberOfVisitedNodes >= k)
                return;

            FindKthLargestElement(node.RightChild, k);

            numberOfVisitedNodes++;

            if (numberOfVisitedNodes == k)
            {
                Console.Write(node.ValueInt);
                return;
            }

            FindKthLargestElement(node.LeftChild, k);
        }

        // Deepest Node In a Tree
        // Find the height of a tree. This can also be solved both recursively or non-recursively.
        // Find the longest path from the root to leaf in a tree.
        // Find the deepest left leaf of a tree.
        // http://blog.gainlo.co/index.php/2016/04/26/deepest-node-in-a-tree/

        public int FindDeepestNode()
        {
            maxLevel = -1;
            maxLevelResult = -1;

            DeepestNode(Root, 0);
            return maxLevelResult;
        }

        private void DeepestNode(TreeNode node, int currentLevel)
        {
            if (node != null)
            {
                DeepestNode(node.LeftChild, ++currentLevel);

                if (currentLevel > maxLevel)
                {
                    maxLevel = currentLevel;
                    maxLevelResult = node.ValueInt;
                }

                DeepestNode(node.RightChild, currentLevel);
            }
        }

        #region Traveling
        /* 
         * Preorder traversal sequence: F, B, A, D, C, E, G, I, H (root, left, right)
         * Inorder traversal sequence: A, B, C, D, E, F, G, H, I (left, root, right)
         * Postorder traversal sequence: A, C, E, D, B, H, I, G, F (left, right, root)
         */

        // Travel preOrder
        public void PreOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                localRoot.DisplayStr();
                PreOrder(localRoot.LeftChild);
                PreOrder(localRoot.RightChild);
            }
        }

        // Travel InOrder
        public void InOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                InOrder(localRoot.LeftChild);
                localRoot.DisplayStr();
                InOrder(localRoot.RightChild);
            }
        }

        // Travel PostOrder
        public void PostOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                PostOrder(localRoot.LeftChild);
                PostOrder(localRoot.RightChild);
                localRoot.DisplayStr();
            }
        }

        // Travel LevelOrder
        public void LevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                Console.WriteLine(node.ValueInt);
                Console.WriteLine(node.ValueStr);

                if (node.LeftChild != null)
                {
                    queue.Enqueue(node.LeftChild);
                }

                if (node.RightChild != null)
                {
                    queue.Enqueue(node.RightChild);
                }
            }
        }
        #endregion

        // Check if the Binary Tree is a BST or not 
        /*
         The recursive call makes sure that subtree nodes are within the range of its ancestors, 
         which is important. The running time complexity will be O(n) since every node is examined once.

         The other solution would be to do an inorder traversal and check if the sequence is sorted, 
         especially since you already know that a binary tree is provided as an input. 
        */
        public bool IsBST()
        {
            return IsValidBST(Root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsValidBST(TreeNode node, int min, int max)
        {
            if (node == null) return true;

            if (node.ValueInt > min && node.ValueInt < max
                && IsValidBST(node.LeftChild, min, node.ValueInt)
                && IsValidBST(node.RightChild, node.ValueInt, max))
                return true;
            else
                return false;
        }

        // Print All Paths Of a Binary Tree
        /*
         * http://blog.gainlo.co/index.php/2016/04/15/print-all-paths-of-a-binary-tree/
           Given a binary tree, print all of the paths from the root to leaf nodes.

            After visiting a node, we put the left child (or the right child if left doesn’t exist) into the stack.
            Repeat step 1 until we hit the leaf node.
            Once we hit the leaf, just print everything in the stack. Then pop the leaf node from the stack, 
                repeat from step 1 (the current node is the top of stack)

            Test Data:
            InterviewPrep.MyTree.MyTree mt = new InterviewPrep.MyTree.MyTree();
            mt.Insert(100);
            mt.Insert(60);
            mt.Insert(50);
            mt.Insert(70);
            mt.Insert(65);
            mt.Insert(80);
            mt.Insert(110);
            mt.Insert(120);
            mt.Insert(115);
            mt.PrintBST();
        */
        public void PrintBST()
        {
            if (Root == null)
                Console.WriteLine("Empty tree...");
            else
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                stack.Push(Root);
                PrintAllPaths(Root, stack);
            }
        }

        private void PrintAllPaths(TreeNode root, Stack<TreeNode> elements)
        {
            // Base Case
            if (root == null)
                return;
           
            // If there is no child then print the list
            if (root.LeftChild == null && root.RightChild == null)
            {
                foreach (var element in elements)
                    Console.Write($"{element.ValueInt} ");

                Console.WriteLine();
                elements.Pop();
            }

            if (root.LeftChild != null)
                elements.Push(root.LeftChild);

            PrintAllPaths(root.LeftChild, elements);

            if (root.RightChild != null)
                elements.Push(root.RightChild);

            PrintAllPaths(root.RightChild, elements);
          
        }


        /*?
            Cracking the Coding Interview, 6th Edition    
            List of Depths: Given a binary tree, design an algorithm which creates a linked list of all the nodes
            at each depth (e.g., if you have a tree with depth D, you'll have D linked lists).
        */
        public void ListOfDepths()
        {
            if (Root != null)
            {
                LinkedList<TreeNode> list = new LinkedList<TreeNode>();
                Queue<TreeNode> queue = new Queue<TreeNode>();
                list.AddLast(Root);
                queue.Enqueue(Root);
                ListOfDepthsPrintLinkedList(list);
                ListOfDepthsHelper(queue);
            }
        }

        private void ListOfDepthsHelper(Queue<TreeNode> queue)
        {
            if (queue.Count == 0)
                return;

            LinkedList<TreeNode> list = new LinkedList<TreeNode>();
            Queue<TreeNode> newLevel = new Queue<TreeNode>();

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();

                if (node.LeftChild != null)
                {
                    newLevel.Enqueue(node.LeftChild);
                    list.AddLast(node.LeftChild);
                }


                if (node.RightChild != null)
                {
                    newLevel.Enqueue(node.RightChild);
                    list.AddLast(node.RightChild);
                }
            }

            ListOfDepthsPrintLinkedList(list);
            ListOfDepthsHelper(newLevel);
        }

        private void ListOfDepthsPrintLinkedList(LinkedList<TreeNode> list)
        {
            foreach (var item in list)
            {
                    Console.Write(item.ValueInt + " - ");
            }

            Console.WriteLine();
        }

        /*?   Cracking the Coding Interview, 6th Edition    
        First Common Ancestor: Design an algorithm and write code to find the first common ancestor
        of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
        necessarily a binary search tree.

    */
        public TreeNode FirstCommonAncestor(TreeNode root, TreeNode n1, TreeNode n2)
        {
            if (root == null) { return null; }

            if (root == n1 || root == n2) return root;

            TreeNode left = FirstCommonAncestor(root.LeftChild, n1, n2);
            TreeNode right = FirstCommonAncestor(root.RightChild, n1, n2);

            if (left != null && right != null) return root;
            if (left == null && right == null) return null;

            return left == null ? right : left;
        }


        // Height of a tree
        public int Height(TreeNode node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));
        }
    }
}
