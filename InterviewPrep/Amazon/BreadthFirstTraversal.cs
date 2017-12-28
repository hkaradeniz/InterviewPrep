using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    /* Level order traversal */
    /* Level order traversal of a tree is breadth first traversal for the tree */
    /* https://practice.geeksforgeeks.org/problems/level-order-traversal/1 */
    /* Trees can be traversed in level-order, where we visit every node on a 
    level before going to a lower level. This search is referred to as breadth-first search (BFS), 
    as the search tree is broadened as much as possible on each depth before going to the next depth. */

    class BreadthFirstTraversal
    {
        public void TraverseBreadthFirst(MyTree.TreeNode node)
        {
            if (node == null) return;

            Queue<MyTree.TreeNode> queue = new Queue<MyTree.TreeNode>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                MyTree.TreeNode current = queue.Dequeue();

                Console.Write($" { current.ValueInt } ");

                if (current.LeftChild != null)
                    queue.Enqueue(node.LeftChild);

                if (current.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }
        }
    }
}
