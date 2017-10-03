namespace InterviewPrep.TreesAndGraphs
{
    /*?
     * Cracking the Coding Interview, 6th Edition
     * To create a tree of minimal height, we need to match the number of nodes in the left subtree to the number
        of nodes in the right subtree as much as possible. This means that we want the root to be the middle of the
        array, since this would mean that half the elements would be less than the root and half would be greater
        than it.
        We proceed with constructing our tree in a similar fashion. The middle of each subsection of the array
        becomes the root of the node. The left half of the array will become our left subtree, and the right half of
        the array will become the right subtree.

        The algorithm is as follows:
        1. Get the middle element from the current subarray and insert it to the tree
        2. Recurse left
        3. Recurse right

        Complexity: O(N log N)
            Traverse the array N
            Inserting an elemen to a BST log N
            N * Log N
     */
    class MinimalTree
    {
        MyTree.MyTree tree;

        public MinimalTree()
        {
            tree = new MyTree.MyTree();
        }
        public void CreateMinimalTree(int[] arr)
        {
            CreateMinimalTree(arr, 0, arr.Length - 1);
            PrintTree();
        }

        /* TreesAndGraphs.MinimalTree mt = new TreesAndGraphs.MinimalTree();
            mt.CreateMinimalTree(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }); */
        private void CreateMinimalTree(int[] arr, int left, int right)
        {
            if (right < left)
                return;

            int mid = left + (right - left) / 2;
            tree.InsertNumber(arr[mid]);
            CreateMinimalTree(arr, left, mid - 1);
            CreateMinimalTree(arr, mid+1, right);
        }

        private void PrintTree()
        {
            tree.PrintBST();
        }
    }
}
