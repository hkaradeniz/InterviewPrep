namespace InterviewPrep.TreesAndGraphs
{
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
