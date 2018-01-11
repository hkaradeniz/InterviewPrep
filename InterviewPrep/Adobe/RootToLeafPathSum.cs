using InterviewPrep.MyTree;

namespace InterviewPrep.Adobe
{
    /* Root to leaf path sum */
    /* Given a Binary Tree and a sum s, your task is to check whether there is a root 
        to leaf path in that tree with the following sum . */
    /* https://practice.geeksforgeeks.org/problems/root-to-leaf-path-sum/1 */
    /* Test Data:
        MyTree.MyTree mt = new MyTree.MyTree();

        mt.Insert(500);
        mt.Insert(300);
        mt.Insert(200);
        mt.Insert(400);
        mt.Insert(1000);
        mt.Insert(600);
        Adobe.RootToLeafPathSum rs = new Adobe.RootToLeafPathSum();
        Console.WriteLine(rs.IsThereSum(mt.Root, 1000));
     */
    class RootToLeafPathSum
    {
        public bool IsThereSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            return Calculate(root, sum);
        }

        private bool Calculate(TreeNode node, int sum)
        {
            if(node == null)
            { return false; }

            // Let's check if this is a leaf node
            if (node.LeftChild == null && node.RightChild == null)
            {
                return sum - node.ValueInt == 0;
            }

            if (Calculate(node.LeftChild, sum - node.ValueInt))
                return true;

            if (Calculate(node.RightChild, sum - node.ValueInt))
                return true;

            return false;
        }
    }
}
