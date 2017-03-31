namespace InterviewPrep.MyTree
{
    class TreeNode
    {
        // Depending on value type, you may use String or Int
        public int ValueInt { get; set; }
        public string ValueStr { get; set; }

        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public TreeNode(int num)
        {
            ValueInt = num;
        }

        public TreeNode(string str)
        {
            ValueStr = str;
        }

        public void DisplayNum()
        {
            System.Console.WriteLine("Value: " + ValueInt);
        }

        public void DisplayStr()
        {
            System.Console.WriteLine("Value: " + ValueStr);
        }
    }
}
