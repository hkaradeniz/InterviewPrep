using System.Collections.Generic;

namespace InterviewPrep.MyTree
{
    class DiagonalSum
    {
        /* Print all diagonal's sums for a given binary tree? */
        /* Solution: Keep a Diagonal level variable. Every time you go left keep it the same. When you take right increase it one
        This will define the diagonal levels. Store them in a dictionary. */

        public void PrintDiagonalSum(MyTree tree)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            ComputeDiagonalSum(tree.Root, dict, 0);
            PrintDiagonalSum(dict);
        }

        private void ComputeDiagonalSum(TreeNode node, Dictionary<int, int> dict, int diagonalValue)
        {
            if (node == null) return;

            if (!dict.ContainsKey(diagonalValue))
                dict.Add(diagonalValue, 0);

            dict[diagonalValue] += node.ValueInt;

            ComputeDiagonalSum(node.LeftChild, dict, diagonalValue);
            ComputeDiagonalSum(node.RightChild, dict, diagonalValue + 1);
        }

        private void PrintDiagonalSum(Dictionary<int, int> dict)
        {
            foreach (var level in dict)
            {
                System.Console.WriteLine($"Level {level.Key}: {level.Value}");
            }
        }
    }
}
