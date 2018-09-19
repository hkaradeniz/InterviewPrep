using System;
using System.Collections;
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

        private TreeNode DeleteElement(TreeNode root, int value)
        {
            /* Base Case: If the tree is empty */
            if (root == null) return null;

            /* Otherwise, recur down the tree */
            if (value < root.ValueInt) root.LeftChild = DeleteElement(root.LeftChild, value);
            else if (value > root.ValueInt) root.RightChild = DeleteElement(root.RightChild, value);
            // if key is same as node's key, then This is the node
            // to be deleted
            else
            {
                // node with only one child or no child
                if (root.LeftChild == null) return root.RightChild;
                else if (root.RightChild == null) return root.LeftChild;
                else
                {
                    // node with two children: Get the smallest in the right subtree
                    root.ValueInt = MinValue(root.RightChild).ValueInt;

                    // Delete the smallest in the right subtree
                    root.RightChild = DeleteElement(root.RightChild, root.ValueInt);
                }
            }

            return root;
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
           * You don’t need to store all the visited elements into an array and find the k-th element. Instead, use 
           a global variable i to record the index of visited elements. Inside the traversal function, every time when you 
           visit an element, just increment i by one and when i == k, output the current element.
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
                PrintAllPaths(stack);
            }
        }

        private void PrintAllPaths(Stack<TreeNode> elements)
        {
            // Base Case
            if (elements.Count == 0)
                return;

            TreeNode value = elements.Pop();

            Console.WriteLine(value.ValueInt);

            if (value.LeftChild != null)
                elements.Push(value.LeftChild);

            if (value.RightChild != null)
                elements.Push(value.RightChild);

            PrintAllPaths(elements);
        }


        /*?
            Cracking the Coding Interview, 6th Edition    
            List of Depths: Given a binary tree, design an algorithm which creates a linked list of all the nodes
            at each depth (e.g., if you have a tree with depth D, you'll have D linked lists).


            Though we might think at first glance that this problem requires a level-by-level traversal, this isn't actually
            necessary. We can traverse the graph any way that we'd like, provided we know which level we're on as we
            do so.
            We can implement a simple modification of the pre-order traversal algorithm, where we pass in level +
            1 to the next recursive call. The code below provides an implementation using depth-first search.

            // Test Data
             MyTree.MyTree mt = new MyTree.MyTree();
            mt.Insert(50);
            mt.Insert(40);
            mt.Insert(55);
            mt.Insert(60);
            mt.Insert(30);
            mt.Insert(45);
            mt.Insert(20);
            mt.Insert(41);
            mt.Insert(47);
            mt.ListOfDepths();
        */
        public void ListOfDepths()
        {
            if (Root != null)
            {
                Dictionary<int, LinkedList<TreeNode>> lists = new Dictionary<int, LinkedList<TreeNode>>();
                ListOfDepths(Root, lists, 0);
                ListOfDepthsPrintLinkedLists(lists);
            }
            else
            {
                Console.WriteLine("Empty Tree!");
            }
        }

        private void ListOfDepths(TreeNode root, Dictionary<int, LinkedList<TreeNode>> lists, int level)
        {
            if (root == null)
                return;

            LinkedList<TreeNode> list = null;

            /*
             * Levels are always traversed in order. So, if this is the first time we've
               visited level i, we must have seen levels 0 through i - 1. We can
               therefore safely add the level at the end.
             */
            if (lists.ContainsKey(level))
            {
                // Level is already in the dictionary
                list = lists[level];
            }
            else
            {
                // Level is NOT in the dictionary
                list = new LinkedList<TreeNode>();
                lists.Add(level, list);
            }

            list.AddLast(root);
            Console.WriteLine($"Adding * Level {level} *, *Value {root.ValueInt} *");
            ListOfDepths(root.LeftChild, lists, level + 1);
            ListOfDepths(root.RightChild, lists, level + 1);
        }

        private void ListOfDepthsPrintLinkedLists(Dictionary<int, LinkedList<TreeNode>> lists)
        {
            foreach (var item in lists)
            {
                int listNumber = item.Key;
                LinkedList<TreeNode> list = item.Value;

                Console.WriteLine($"List Number: {listNumber}");
                foreach (var node in list)
                {
                    Console.Write($"{node.ValueInt} * ");
                }

                Console.WriteLine();
            }
        }

        /*Min depth of a binary three*/
        /*Use breadth first search*/
        public int MinDepth(TreeNode root)
        {
            return GetMinDepth(root);
        }

        private int GetMinDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            int depth = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                depth++;

                while (size > 0)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
                    if (node.RightChild != null) queue.Enqueue(node.RightChild);
                    if (node.LeftChild == null && node.RightChild == null) return depth;
                    size--;
                }
            }

            return -1;
        }

        /*?   Cracking the Coding Interview, 6th Edition    
        First Common Ancestor: Design an algorithm and write code to find the first common ancestor
        of two nodes in a binary tree. Avoid storing additional nodes in a data structure. NOTE: This is not
        necessarily a binary search tree.

    */
        public TreeNode FirstCommonAncestor(TreeNode root, TreeNode n1, TreeNode n2)
        {
            if (root == null || root == n1 || root == n2) { return root; }

            TreeNode left = FirstCommonAncestor(root.LeftChild, n1, n2);
            TreeNode right = FirstCommonAncestor(root.RightChild, n1, n2);

            if (left != null && right != null) return root;

            return left == null ? right : left;
        }

        /*?
         * Check Balanced: Implement a function to check if a binary tree is balanced. For the purposes of
            this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any
            node never differ by more than one.
            We can simply recurse through the entire tree, and for each node, compute the heights of each subtree.
            Complexity: O(N log N)
         */
        // Height of a tree
        // Complexity:  O(n) 
        public int Height(TreeNode node)
        {
            if (node == null) return 0;

            int leftHeight = Height(node.LeftChild);
            int rightHeight = Height(node.RightChild);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        // Is Binary tree balanced?
        public bool IsBalanced(TreeNode node)
        {
            int lh; /* for height of left subtree */

            int rh; /* for height of right subtree */

            /* If tree is empty then return true */
            if (node == null)
                return true;

            /* Get the height of left and right sub trees */
            lh = Height(node.LeftChild);
            rh = Height(node.RightChild);

            if (Math.Abs(lh - rh) <= 1
                    && IsBalanced(node.LeftChild)
                    && IsBalanced(node.RightChild))
                return true;

            /* If we reach here then tree is not height-balanced */
            return false;
        }

        /*?  Checked Balanced - More Efficient */
        /*?
         * Although this works. it's not very efficient. On each node. we recurse through its entire subtree. This means
           that Height is called repeatedly on the same nodes. The algorithm isO(N log N) since each node is
           touched" once per node above it.

           We need to cut out some of the calls to Height.

        If we inspect this method, we may notice that getHeight could actually check if the tree is balanced at
        the same time as it's checking heights. What do we do when we discover that the subtree isn' t balanced?
        Just return an error code.

        This improved algorithm works by checking the height of each subtree as we recurse down from the root.
        On each node, we recursively get the heights of the left and right subtrees through the checkHeight
        method. If the subtree is balanced, then checkHeight will return the actual height of the subtree. If the
        subtree is not balanced, then c h ec kHeight will return an error code. We will immediately break and
        return an error code from the current call.
         */
        public bool IsBinaryTreeBalanced(TreeNode root)
        {
            return CheckHeight(root) == int.MinValue ? false : true;
        }

        private int CheckHeight(TreeNode root)
        {
            if (root == null)
                return -1;

            int leftHeight = CheckHeight(root.LeftChild);
            if (leftHeight == int.MinValue)
                return int.MinValue; // It means the hight difference is more than 1

            int rightHeight = CheckHeight(root.RightChild);
            if (rightHeight == int.MinValue)
                return int.MinValue; // It means the hight difference is more than 1

            int difference = Math.Abs(leftHeight - rightHeight);
            if (difference > 1)
                return int.MinValue; // difference is more than 1
            else
                return Math.Max(leftHeight, rightHeight) + 1;
        }

        Stack<int> stack = new Stack<int>();
        public void GetPath(TreeNode head, int value)
        {
            GetPathHelper(head, value);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private bool GetPathHelper(TreeNode node, int value)
        {
            if (node == null) return false;

            if (node.ValueInt == value || GetPathHelper(node.LeftChild, value) || GetPathHelper(node.RightChild, value))
            {
                stack.Push(node.ValueInt);
                return true;
            }

            return false;
        }
    }
}
