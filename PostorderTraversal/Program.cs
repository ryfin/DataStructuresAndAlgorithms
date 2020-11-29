using System;
using System.Collections.Generic;

namespace PostorderTraversal
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
        }

        static IList<int> PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            var result = new List<int>();

            PostOrder(root, result);

            return result;
        }

        static IList<int> PostOrderIterativly(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            Stack<TreeNode> first = new Stack<TreeNode>();
            Stack<TreeNode> second = new Stack<TreeNode>();
            first.Push(root);
            while (first.Count > 0)
            {
                TreeNode current = first.Pop();
                second.Push(current);
                if (current.left != null)
                {
                    first.Push(current.left);
                }
                if(current.right != null)
                {
                    first.Push(current.right);
                }
            }
            var result = new List<int>();
            while (second.Count > 0)
            {
                TreeNode current = second.Pop();
                result.Add(current.val);
            }

            return result;
        }

        static void PostOrder(TreeNode root, List<int> result)
        {
            if (root.left != null)
            {
                PostOrder(root.left, result);
            }
            if (root.right != null)
            {
                PostOrder(root.right, result);
            }
            result.Add(root.val);
        }
    }
}
