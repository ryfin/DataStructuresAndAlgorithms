using System;
using System.Collections.Generic;

namespace DeleteNodeBST
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = 
                new TreeNode(10,
            left:  new TreeNode(5,
                left:  new TreeNode(4),
                right: new TreeNode(7,
                    left: new TreeNode(6),
                    right: new TreeNode(8))),
            right: new TreeNode(15,
                left:  new TreeNode(13, 
                    left: new TreeNode(12),
                    right: new TreeNode(14)),
                right: new TreeNode(20)));

            PrintLevelOrder(root);
            var upd = DeleteNode(root, 10);
            Console.WriteLine();
            PrintLevelOrder(upd);
        }

        static void PrintLevelOrder(TreeNode root)
        {
            TreeNode current = null;
            Queue<TreeNode> items = new Queue<TreeNode>();
            items.Enqueue(root);
            while (items.Count > 0)
            {
                current = items.Dequeue();
                Console.Write($"{current.val}  ");
                if (current.left != null)
                {
                    items.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    items.Enqueue(current.right);
                }
            }
        }

        //Utility function to delete node
        static TreeNode DeleteRootNode(TreeNode root)
        {
            //Check for empty node, in that case return null
            if(root == null)
            {
                return null;
            }
            //Two ifs bellow checks presense of children at target node
            //Case 1: node doesn't have children, first if will return null as root.right == null
            //Case 2: node has one child, in that case we will not null child and replace target's parent link with not null child
            if(root.left == null)
            {
                return root.right;
            }
            if(root.right == null)
            {
                return root.left;
            }

            //Case 3: node has two children, if so we need to find in-order successor node, delete them from the tree, and replace target with found node
            //In-order successor in this case will be minimum element in right subtree of target
            TreeNode node = GetMin(root.right);
            //Delete successor
            DeleteNode(root, node.val);
            //Assign children links of target node to successor 
            node.left = root.left;
            node.right = root.right;
            
            //return successor to replace target at target's parent
            return node;
        }

        static TreeNode DeleteNode(TreeNode root, int val)
        {
            TreeNode parent = null;
            TreeNode toDelete = SearchNode(root, val, out parent);
            
            //target for deletin is root, update root
            if(parent == null)
            {
                root = DeleteRootNode(toDelete);

                return root;
            }
            if(parent.left == toDelete)
            {
                parent.left = DeleteRootNode(toDelete);
            }
            else
            {
                parent.right = DeleteRootNode(toDelete);
            }

            return root;
        }

        private static TreeNode GetMin(TreeNode root)
        {
            TreeNode current = root;
            while (current.left != null)
            {
                current = current.left;
            }

            return current;
        }

        static TreeNode SearchNode(TreeNode root, int val, out TreeNode parent)
        {
            TreeNode current = root;
            parent = null;
            while (current != null)
            {
                if (current.val == val)
                {
                    return current;
                }

                parent = current;

                if (val > current.val)
                {
                    current = current.right;
                }
                else if (val < current.val)
                {
                    current = current.left;
                }
            }

            return null;
        }
    }
}
