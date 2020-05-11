using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2020Challenge
{
//In a binary tree, the root node is at depth 0, and children of each depth k node are at depth k+1.
//Two nodes of a binary tree are cousins if they have the same depth, but have different parents.
//We are given the root of a binary tree with unique values, and the values x and y of two different nodes in the tree.
//Return true if and only if the nodes corresponding to the values x and y are cousins.

//Example 1:
//Input: root = [1, 2, 3, 4], x = 4, y = 3
//Output: false

//Example 2:
//Input: root = [1, 2, 3, null, 4, null, 5], x = 5, y = 4
//Output: true

//Example 3:
//Input: root = [1, 2, 3, null, 4], x = 2, y = 3
//Output: false

//Note:
//The number of nodes in the tree will be between 2 and 100.
//Each node has a unique integer value from 1 to 100.
    public class CousinsInaBinaryTree
    {
        //Conceptual approach: O(n) time | O(1) space additional space OR O(logn) call stack space
        public bool IsCousins(TreeNode root, int x, int y)
        {
            return Level(root, x, 0) == Level(root, y, 0) && IsSibling(root, x, y) == false;
        }

        private int Level(TreeNode root, int x, int level)
        {
            if (root == null) return -1;
            if (root.val == x) return level;
            int l = Level(root.left, x, level + 1);
            if (l != -1)
            {
                return l;
            }
            else
            {
                return Level(root.right, x, level + 1);
            }
        }

        private bool IsSibling(TreeNode root, int x, int y)
        {
            if (root == null) return false;

            if ((root.left != null && root.right != null) && ((root.left.val == x && root.right.val == y) || (root.left.val == y && root.right.val == x)))
            {
                return true;
            }
            else
            {
                return (IsSibling(root.left, x, y) || IsSibling(root.right, x, y));
            }
        }

        // O(n) time | O(n) space
        public bool IsCousinsUsingBFS(TreeNode root, int x, int y)
        {
            if (root.val == x || root.val == y || root == null) return false;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int genPop = 1;
            while (queue.Count > 0)
            {
                if (genPop == 0)
                {
                    genPop = queue.Count;
                }
                TreeNode current = queue.Dequeue();
                genPop--;
                int target = -1;

                if (current.left != null)
                {
                    if (current.left.val == x)
                    {
                        target = y;
                    }
                    else if (current.left.val == y)
                    {
                        target = x;
                    }
                    else
                    {
                        queue.Enqueue(current.left);
                    }
                }

                if (current.right != null)
                {
                    if (current.right.val == target) return false;

                    if (current.right.val == x)
                    {
                        target = y;
                    }
                    else if (current.right.val == y)
                    {
                        target = x;
                    }
                    else
                    {
                        queue.Enqueue(current.right);
                    }
                }

                if (target != -1)
                {
                    while (genPop > 0)
                    {
                        TreeNode temp = queue.Dequeue();
                        genPop--;
                        if (temp.left != null && temp.left.val == target) return true;
                        if (temp.right != null && temp.right.val == target) return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
