namespace InterviewPrep.MyTree
{
    class CreateBST
    {
        // Create a balanced Binary Search Tree (BST) from a sorted array
        /* 
         Test: 
          MyTree.CreateBST cb = new MyTree.CreateBST();
          cb.CreateBSTfromSortedArray(new int[] {1,2,3,4,5,6,7,8,9 });
         */
        public TreeNode CreateBSTfromSortedArray(int[] arr)
        {
            MyTree mt = new MyTree();
            return CreateBSTRecursive(arr, 0, arr.Length - 1, mt);
        }

        private TreeNode CreateBSTRecursive(int[] arr, int left, int right, MyTree mt)
        {
            if (left > right)
                return null;

            int mid = left + (right - left) / 2;
            mt.Insert(arr[mid]);
            CreateBSTRecursive(arr, left, mid - 1, mt);
            CreateBSTRecursive(arr, mid+1, right, mt);

            return mt.Root;
        }
    }
}
