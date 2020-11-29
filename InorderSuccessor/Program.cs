using System;

namespace InorderSuccessor
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
            TreeNode root = new TreeNode(5,
                left: new TreeNode(3,
                    left: new TreeNode(2),
                    right: new TreeNode(4)),
                right: new TreeNode(7,
                    left: new TreeNode(6),
                    right: new TreeNode(8)));
            TreeNode node = root.left.right;

            Console.WriteLine($"node is: {node.val}, successor is: {GetInorderSuccessor(node, root).val} ");
            Console.WriteLine($"node is: {root.val}, successor is: {GetInorderSuccessor(root, root).val} ");
        }

        static TreeNode GetInorderSuccessor(TreeNode node, TreeNode root)
        {
            if(node.right!= null)
            {
                return GetMin(node.right);
            }

            TreeNode current = root;
            TreeNode successor = null;
            while(current != null)
            {
                if(node.val < current.val)
                {
                    successor = current;
                    current = current.left;
                }
                else if(node.val > current.val)
                {
                    current = current.right;
                }
                else
                {
                    break;
                }
            }

            return successor;
        }

        static TreeNode GetMin(TreeNode root)
        {
            TreeNode current = root;
            while(current.left != null)
            {
                current = current.left;
            }

            return current;
        }
    }
}
